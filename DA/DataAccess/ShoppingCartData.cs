using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class ShoppingCartData : IShoppingCartData
    {
ECommerceContext ctx;
        public ShoppingCartData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbShoppingCart>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbShoppingCarts.AsNoTracking();

                var shoppingCarts = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (shoppingCarts);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbShoppingCart> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("ShoppingCart ID must be greater than 0.", nameof(id));
    }

    try
    {
    var shoppingCart = ctx.TbShoppingCarts.FirstOrDefault(a => a.Id == id);
                return shoppingCart;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbShoppingCart shoppingCart)
        {
 shoppingCart.Id = 0;
            try
            {
                await ctx.TbShoppingCarts.AddAsync(shoppingCart).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return shoppingCart.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbShoppingCart shoppingCart)
        {
           if (shoppingCart.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(shoppingCart).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbShoppingCart? shoppingCart = await GetById(id);
              

                if (shoppingCart == null)
                {
                    return false;
                }

                  shoppingCart.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsShoppingCartExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_ShoppingCartsCount]";

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