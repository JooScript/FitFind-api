using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class CampaignProductMappingData : ICampaignProductMappingData
    {
ECommerceContext ctx;
        public CampaignProductMappingData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbCampaignProductMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbCampaignProductMappings.AsNoTracking();

                var campaignProductMappings = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (campaignProductMappings);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbCampaignProductMapping> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("CampaignProductMapping ID must be greater than 0.", nameof(id));
    }

    try
    {
    var campaignProductMapping = ctx.TbCampaignProductMappings.FirstOrDefault(a => a.Id == id);
                return campaignProductMapping;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbCampaignProductMapping campaignProductMapping)
        {
 campaignProductMapping.Id = 0;
            try
            {
                await ctx.TbCampaignProductMappings.AddAsync(campaignProductMapping).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return campaignProductMapping.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbCampaignProductMapping campaignProductMapping)
        {
           if (campaignProductMapping.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(campaignProductMapping).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbCampaignProductMapping? campaignProductMapping = await GetById(id);
              

                if (campaignProductMapping == null)
                {
                    return false;
                }

                  campaignProductMapping.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsCampaignProductMappingExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_CampaignProductMappingsCount]";

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