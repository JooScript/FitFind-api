using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsPayment : IPayment
    {
        PaymentData oPaymentData;

        public ClsPayment(ECommerceContext context)
        {
            oPaymentData = new PaymentData(context);
        }
               public async Task<TbPayment> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var payment = await oPaymentData.GetById(id);
                return payment;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbPayment payment)
        {
              long paymentId = -1;
            try
            {
                paymentId = await oPaymentData.Add(payment);
                return paymentId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbPayment payment)
        {
            try
            {
                return await oPaymentData.Update(payment);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbPayment payment) => payment.Id <= 0 ? await Add(payment) != -1 : await Update(payment);
        public async Task<List<TbPayment>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oPaymentData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oPaymentData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oPaymentData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oPaymentData.Delete(id);
        }

    }
}