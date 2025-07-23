using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsInvoice : IInvoice
    {
        InvoiceData oInvoiceData;

        public ClsInvoice(ECommerceContext context)
        {
            oInvoiceData = new InvoiceData(context);
        }
               public async Task<TbInvoice> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var invoice = await oInvoiceData.GetById(id);
                return invoice;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbInvoice invoice)
        {
              long invoiceId = -1;
            try
            {
                invoiceId = await oInvoiceData.Add(invoice);
                return invoiceId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbInvoice invoice)
        {
            try
            {
                return await oInvoiceData.Update(invoice);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbInvoice invoice) => invoice.Id <= 0 ? await Add(invoice) != -1 : await Update(invoice);
        public async Task<List<TbInvoice>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oInvoiceData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oInvoiceData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oInvoiceData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oInvoiceData.Delete(id);
        }

    }
}