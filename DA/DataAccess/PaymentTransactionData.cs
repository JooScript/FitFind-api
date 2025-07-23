using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class PaymentTransactionData : IPaymentTransactionData
    {
ECommerceContext ctx;
        public PaymentTransactionData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbPaymentTransaction>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbPaymentTransactions.AsNoTracking();

                var paymentTransactions = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (paymentTransactions);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbPaymentTransaction> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("PaymentTransaction ID must be greater than 0.", nameof(id));
    }

    try
    {
    var paymentTransaction = ctx.TbPaymentTransactions.FirstOrDefault(a => a.Id == id);
                return paymentTransaction;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbPaymentTransaction paymentTransaction)
        {
 paymentTransaction.Id = 0;
            try
            {
                await ctx.TbPaymentTransactions.AddAsync(paymentTransaction).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return paymentTransaction.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbPaymentTransaction paymentTransaction)
        {
           if (paymentTransaction.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(paymentTransaction).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbPaymentTransaction? paymentTransaction = await GetById(id);
              

                if (paymentTransaction == null)
                {
                    return false;
                }

                  paymentTransaction.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsPaymentTransactionExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_PaymentTransactionsCount]";

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