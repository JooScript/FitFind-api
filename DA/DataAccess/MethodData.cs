using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class MethodData : IMethodData
    {
ECommerceContext ctx;
        public MethodData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbMethod>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbMethods.AsNoTracking();

                var methods = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (methods);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbMethod> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("Method ID must be greater than 0.", nameof(id));
    }

    try
    {
    var method = ctx.TbMethods.FirstOrDefault(a => a.Id == id);
                return method;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbMethod method)
        {
 method.Id = 0;
            try
            {
                await ctx.TbMethods.AddAsync(method).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return method.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbMethod method)
        {
           if (method.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(method).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbMethod? method = await GetById(id);
              

                if (method == null)
                {
                    return false;
                }

                  method.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsMethodExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_MethodsCount]";

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