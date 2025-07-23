using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class VariationAttributeMappingData : IVariationAttributeMappingData
    {
ECommerceContext ctx;
        public VariationAttributeMappingData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbVariationAttributeMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbVariationAttributeMappings.AsNoTracking();

                var variationAttributeMappings = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (variationAttributeMappings);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbVariationAttributeMapping> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("VariationAttributeMapping ID must be greater than 0.", nameof(id));
    }

    try
    {
    var variationAttributeMapping = ctx.TbVariationAttributeMappings.FirstOrDefault(a => a.Id == id);
                return variationAttributeMapping;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbVariationAttributeMapping variationAttributeMapping)
        {
 variationAttributeMapping.Id = 0;
            try
            {
                await ctx.TbVariationAttributeMappings.AddAsync(variationAttributeMapping).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return variationAttributeMapping.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbVariationAttributeMapping variationAttributeMapping)
        {
           if (variationAttributeMapping.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(variationAttributeMapping).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbVariationAttributeMapping? variationAttributeMapping = await GetById(id);
              

                if (variationAttributeMapping == null)
                {
                    return false;
                }

                  variationAttributeMapping.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsVariationAttributeMappingExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_VariationAttributeMappingsCount]";

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