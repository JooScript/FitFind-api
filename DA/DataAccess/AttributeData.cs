using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class AttributeData : IAttributeData
    {
ECommerceContext ctx;
        public AttributeData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbAttribute>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbAttributes.AsNoTracking();

                var attributes = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (attributes);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbAttribute> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("Attribute ID must be greater than 0.", nameof(id));
    }

    try
    {
    var attribute = ctx.TbAttributes.FirstOrDefault(a => a.Id == id);
                return attribute;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbAttribute attribute)
        {
 attribute.Id = 0;
            try
            {
                await ctx.TbAttributes.AddAsync(attribute).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return attribute.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbAttribute attribute)
        {
           if (attribute.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(attribute).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbAttribute? attribute = await GetById(id);
              

                if (attribute == null)
                {
                    return false;
                }

                  attribute.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsAttributeExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_AttributesCount]";

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