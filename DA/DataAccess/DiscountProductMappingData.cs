using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class DiscountProductMappingData : IDiscountProductMappingData
    {
ECommerceContext ctx;
        public DiscountProductMappingData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbDiscountProductMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbDiscountProductMappings.AsNoTracking();

                var discountProductMappings = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (discountProductMappings);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbDiscountProductMapping> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("DiscountProductMapping ID must be greater than 0.", nameof(id));
    }

    try
    {
    var discountProductMapping = ctx.TbDiscountProductMappings.FirstOrDefault(a => a.Id == id);
                return discountProductMapping;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbDiscountProductMapping discountProductMapping)
        {
 discountProductMapping.Id = 0;
            try
            {
                await ctx.TbDiscountProductMappings.AddAsync(discountProductMapping).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return discountProductMapping.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbDiscountProductMapping discountProductMapping)
        {
           if (discountProductMapping.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(discountProductMapping).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbDiscountProductMapping? discountProductMapping = await GetById(id);
              

                if (discountProductMapping == null)
                {
                    return false;
                }

                  discountProductMapping.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsDiscountProductMappingExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_DiscountProductMappingsCount]";

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