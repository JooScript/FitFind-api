using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsDiscount : IDiscount
    {
        DiscountData oDiscountData;

        public ClsDiscount(ECommerceContext context)
        {
            oDiscountData = new DiscountData(context);
        }
               public async Task<TbDiscount> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var discount = await oDiscountData.GetById(id);
                return discount;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbDiscount discount)
        {
              long discountId = -1;
            try
            {
                discountId = await oDiscountData.Add(discount);
                return discountId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbDiscount discount)
        {
            try
            {
                return await oDiscountData.Update(discount);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbDiscount discount) => discount.Id <= 0 ? await Add(discount) != -1 : await Update(discount);
        public async Task<List<TbDiscount>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oDiscountData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oDiscountData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oDiscountData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oDiscountData.Delete(id);
        }

    }
}