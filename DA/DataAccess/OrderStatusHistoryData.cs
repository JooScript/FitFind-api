using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class OrderStatusHistoryData : IOrderStatusHistoryData
    {
ECommerceContext ctx;
        public OrderStatusHistoryData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbOrderStatusHistory>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbOrderStatusHistories.AsNoTracking();

                var orderStatusHistories = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (orderStatusHistories);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbOrderStatusHistory> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("OrderStatusHistory ID must be greater than 0.", nameof(id));
    }

    try
    {
    var orderStatusHistory = ctx.TbOrderStatusHistories.FirstOrDefault(a => a.Id == id);
                return orderStatusHistory;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbOrderStatusHistory orderStatusHistory)
        {
 orderStatusHistory.Id = 0;
            try
            {
                await ctx.TbOrderStatusHistories.AddAsync(orderStatusHistory).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return orderStatusHistory.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbOrderStatusHistory orderStatusHistory)
        {
           if (orderStatusHistory.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(orderStatusHistory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbOrderStatusHistory? orderStatusHistory = await GetById(id);
              

                if (orderStatusHistory == null)
                {
                    return false;
                }

                  orderStatusHistory.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsOrderStatusHistoryExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_OrderStatusHistoriesCount]";

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