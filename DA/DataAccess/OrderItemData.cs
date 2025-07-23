using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class OrderItemData : IOrderItemData
    {
ECommerceContext ctx;
        public OrderItemData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbOrderItem>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbOrderItems.AsNoTracking();

                var orderItems = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (orderItems);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbOrderItem> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("OrderItem ID must be greater than 0.", nameof(id));
    }

    try
    {
    var orderItem = ctx.TbOrderItems.FirstOrDefault(a => a.Id == id);
                return orderItem;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbOrderItem orderItem)
        {
 orderItem.Id = 0;
            try
            {
                await ctx.TbOrderItems.AddAsync(orderItem).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return orderItem.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbOrderItem orderItem)
        {
           if (orderItem.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(orderItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

public async Task<bool> Delete(long id)
        {
            if (id <= 0)
            {
                return false;
            }

            try
            {
 TbOrderItem? orderItem = await GetById(id);
              

                if (orderItem == null)
                {
                    return false;
                }

                  orderItem.IsDeleted = true;
                await ctx.SaveChangesAsync().ConfigureAwait(false);
       

                return true;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

               public async Task<bool> IsExists(long id)
        {
            if (id <= 0)
            {
                return false;
            }

            var parameter = new SqlParameter("@Id", id);

            var returnParameter = new SqlParameter
            {
                ParameterName = "@ReturnVal",
                SqlDbType = System.Data.SqlDbType.BigInt,
                Direction = System.Data.ParameterDirection.Output
            };

            try
            {
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsOrderItemExists] @Id", returnParameter, parameter);
                return (long)returnParameter.Value == 1;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

     public async Task<long> Count()
        {
            const string sqlQuery = "EXEC [dbo].[SP_OrderItemsCount]";

            try
            {
                using var conn = ctx.Database.GetDbConnection();
                await conn.OpenAsync();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = sqlQuery;
                cmd.CommandType = System.Data.CommandType.Text;

                var result = await cmd.ExecuteScalarAsync();
                return Convert.ToInt32(result);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }
    }
}