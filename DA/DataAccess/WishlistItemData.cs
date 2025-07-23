using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class WishlistItemData : IWishlistItemData
    {
ECommerceContext ctx;
        public WishlistItemData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbWishlistItem>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbWishlistItems.AsNoTracking();

                var wishlistItems = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (wishlistItems);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbWishlistItem> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("WishlistItem ID must be greater than 0.", nameof(id));
    }

    try
    {
    var wishlistItem = ctx.TbWishlistItems.FirstOrDefault(a => a.Id == id);
                return wishlistItem;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbWishlistItem wishlistItem)
        {
 wishlistItem.Id = 0;
            try
            {
                await ctx.TbWishlistItems.AddAsync(wishlistItem).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return wishlistItem.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbWishlistItem wishlistItem)
        {
           if (wishlistItem.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(wishlistItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbWishlistItem? wishlistItem = await GetById(id);
              

                if (wishlistItem == null)
                {
                    return false;
                }

                  wishlistItem.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsWishlistItemExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_WishlistItemsCount]";

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