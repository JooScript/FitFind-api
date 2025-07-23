using ECommerce.Models;
    public interface ITaxRate
    {
public Task<TbTaxRate> GetById(long id);
public Task<List<TbTaxRate>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbTaxRate taxRate);
public Task<bool> Update(TbTaxRate taxRate);
public Task<bool> Save(TbTaxRate taxRate);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }