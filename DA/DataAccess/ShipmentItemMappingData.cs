using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class ShipmentItemMappingData : IShipmentItemMappingData
    {
ECommerceContext ctx;
        public ShipmentItemMappingData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbShipmentItemMapping>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbShipmentItemMappings.AsNoTracking();

                var shipmentItemMappings = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (shipmentItemMappings);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbShipmentItemMapping> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("ShipmentItemMapping ID must be greater than 0.", nameof(id));
    }

    try
    {
    var shipmentItemMapping = ctx.TbShipmentItemMappings.FirstOrDefault(a => a.Id == id);
                return shipmentItemMapping;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbShipmentItemMapping shipmentItemMapping)
        {
 shipmentItemMapping.Id = 0;
            try
            {
                await ctx.TbShipmentItemMappings.AddAsync(shipmentItemMapping).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return shipmentItemMapping.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbShipmentItemMapping shipmentItemMapping)
        {
           if (shipmentItemMapping.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(shipmentItemMapping).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbShipmentItemMapping? shipmentItemMapping = await GetById(id);
              

                if (shipmentItemMapping == null)
                {
                    return false;
                }

                  shipmentItemMapping.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsShipmentItemMappingExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_ShipmentItemMappingsCount]";

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