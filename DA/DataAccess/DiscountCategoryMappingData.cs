using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class DiscountCategoryMappingData : IDiscountCategoryMappingData
    {
ECommerceContext ctx;
        public DiscountCategoryMappingData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbDiscountCategoryMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbDiscountCategoryMappings.AsNoTracking();

                var discountCategoryMappings = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (discountCategoryMappings);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbDiscountCategoryMapping> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("DiscountCategoryMapping ID must be greater than 0.", nameof(id));
    }

    try
    {
    var discountCategoryMapping = ctx.TbDiscountCategoryMappings.FirstOrDefault(a => a.Id == id);
                return discountCategoryMapping;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbDiscountCategoryMapping discountCategoryMapping)
        {
 discountCategoryMapping.Id = 0;
            try
            {
                await ctx.TbDiscountCategoryMappings.AddAsync(discountCategoryMapping).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return discountCategoryMapping.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbDiscountCategoryMapping discountCategoryMapping)
        {
           if (discountCategoryMapping.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(discountCategoryMapping).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbDiscountCategoryMapping? discountCategoryMapping = await GetById(id);
              

                if (discountCategoryMapping == null)
                {
                    return false;
                }

                  discountCategoryMapping.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsDiscountCategoryMappingExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_DiscountCategoryMappingsCount]";

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