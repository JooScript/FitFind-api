using ECommerce.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Utilities;

namespace ECommerce.Da
{
    public class ProductSupplierData : IProductSupplierData
    {
ECommerceContext ctx;
        public ProductSupplierData(ECommerceContext context)
        {
            ctx = context;
        }
public async Task<List<TbProductSupplier>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {              
                var query = ctx.TbProductSuppliers.AsNoTracking();

                var productSuppliers = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync().ConfigureAwait(false);

                return (productSuppliers);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

public async Task<TbProductSupplier> GetById(long id)
{
    if (id <= 0)
    {
        throw new ArgumentException("ProductSupplier ID must be greater than 0.", nameof(id));
    }

    try
    {
    var productSupplier = ctx.TbProductSuppliers.FirstOrDefault(a => a.Id == id);
                return productSupplier;
    }
    catch (Exception ex)
    {
        Helper.ErrorLogger(ex);
        throw;
    }
}

public async Task<long> Add(TbProductSupplier productSupplier)
        {
 productSupplier.Id = 0;
            try
            {
                await ctx.TbProductSuppliers.AddAsync(productSupplier).ConfigureAwait(false);
                await ctx.SaveChangesAsync().ConfigureAwait(false);
                return productSupplier.Id;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

public async Task<bool> Update(TbProductSupplier productSupplier)
        {
           if (productSupplier.Id <= 0)
            {
                return false;
            }

            try
            {
                ctx.Entry(productSupplier).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
 TbProductSupplier? productSupplier = await GetById(id);
              

                if (productSupplier == null)
                {
                    return false;
                }

                  productSupplier.IsDeleted = true;
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
                await ctx.Database.ExecuteSqlRawAsync("EXEC @ReturnVal = [dbo].[SP_IsProductSupplierExists] @Id", returnParameter, parameter);
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
            const string sqlQuery = "EXEC [dbo].[SP_ProductSuppliersCount]";

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