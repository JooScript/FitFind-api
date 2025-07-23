using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsPaymentTransaction : IPaymentTransaction
    {
        PaymentTransactionData oPaymentTransactionData;

        public ClsPaymentTransaction(ECommerceContext context)
        {
            oPaymentTransactionData = new PaymentTransactionData(context);
        }
               public async Task<TbPaymentTransaction> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var paymentTransaction = await oPaymentTransactionData.GetById(id);
                return paymentTransaction;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbPaymentTransaction paymentTransaction)
        {
              long paymentTransactionId = -1;
            try
            {
                paymentTransactionId = await oPaymentTransactionData.Add(paymentTransaction);
                return paymentTransactionId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbPaymentTransaction paymentTransaction)
        {
            try
            {
                return await oPaymentTransactionData.Update(paymentTransaction);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbPaymentTransaction paymentTransaction) => paymentTransaction.Id <= 0 ? await Add(paymentTransaction) != -1 : await Update(paymentTransaction);
        public async Task<List<TbPaymentTransaction>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oPaymentTransactionData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oPaymentTransactionData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oPaymentTransactionData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oPaymentTransactionData.Delete(id);
        }

    }
}