using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class LanguageData : ILanguageData
    {
ECommerceContext ctx;
        public LanguageData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbLanguage>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbLanguages.AsNoTracking();

                var languages = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (languages);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbLanguage> GetById(int id)
{
    if (id <= 0)
    {
        throw new ArgumentException("Language ID must be greater than 0.", nameof(id));
    }

    try
    {
    var language = ctx.TbLanguages.FirstOrDefault(a => a.Id == id);
                return language;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<int> Add(TbLanguage language)
        {
 language.Id = 0;
            try
            {
                await ctx.TbLanguages.AddAsync(language).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return language.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbLanguage language)
        {
           if (language.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(language).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

public async Task<bool> Delete(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            try
            {
 TbLanguage? language = await GetById(id);
              

                if (language == null)
                {
                    return false;
                }

                  language.IsDeleted = true;
                await ctx.SaveChangesAsync().ConfigureAwait(false);
       

                return true;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

               public async Task<bool> IsExists(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            var parameter = new SqlParameter("@Id", id);

            var returnParameter = new SqlParameter
            {
                ParameterName = "@ReturnVal",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output
            };

            try
            {
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsLanguageExists] @Id", returnParameter, parameter);
                return (int)returnParameter.Value == 1;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

     public async Task<int> Count()
        {
            const string sqlQuery = "EXEC [dbo].[SP_LanguagesCount]";

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