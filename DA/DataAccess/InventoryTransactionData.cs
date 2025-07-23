using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class InventoryTransactionData : IInventoryTransactionData
    {
ECommerceContext ctx;
        public InventoryTransactionData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbInventoryTransaction>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbInventoryTransactions.AsNoTracking();

                var inventoryTransactions = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (inventoryTransactions);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbInventoryTransaction> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("InventoryTransaction ID must be greater than 0.", nameof(id));
    }

    try
    {
    var inventoryTransaction = ctx.TbInventoryTransactions.FirstOrDefault(a => a.Id == id);
                return inventoryTransaction;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbInventoryTransaction inventoryTransaction)
        {
 inventoryTransaction.Id = 0;
            try
            {
                await ctx.TbInventoryTransactions.AddAsync(inventoryTransaction).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return inventoryTransaction.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbInventoryTransaction inventoryTransaction)
        {
           if (inventoryTransaction.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(inventoryTransaction).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbInventoryTransaction? inventoryTransaction = await GetById(id);
              

                if (inventoryTransaction == null)
                {
                    return false;
                }

                  inventoryTransaction.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsInventoryTransactionExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_InventoryTransactionsCount]";

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