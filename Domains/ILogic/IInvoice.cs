using ECommerce.Models;
    public interface IInvoice
    {
public Task<TbInvoice> GetById(long id);
public Task<List<TbInvoice>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbInvoice invoice);
public Task<bool> Update(TbInvoice invoice);
public Task<bool> Save(TbInvoice invoice);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }