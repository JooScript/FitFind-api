using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class ProductTagMappingData : IProductTagMappingData
    {
ECommerceContext ctx;
        public ProductTagMappingData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbProductTagMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbProductTagMappings.AsNoTracking();

                var productTagMappings = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (productTagMappings);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbProductTagMapping> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("ProductTagMapping ID must be greater than 0.", nameof(id));
    }

    try
    {
    var productTagMapping = ctx.TbProductTagMappings.FirstOrDefault(a => a.Id == id);
                return productTagMapping;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbProductTagMapping productTagMapping)
        {
 productTagMapping.Id = 0;
            try
            {
                await ctx.TbProductTagMappings.AddAsync(productTagMapping).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return productTagMapping.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbProductTagMapping productTagMapping)
        {
           if (productTagMapping.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(productTagMapping).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbProductTagMapping? productTagMapping = await GetById(id);
              

                if (productTagMapping == null)
                {
                    return false;
                }

                  productTagMapping.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsProductTagMappingExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_ProductTagMappingsCount]";

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