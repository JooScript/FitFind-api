using ECommerce.Models;
    public interface IDiscountProductMappingData
    {
public Task<TbDiscountProductMapping> GetById(long id);
public Task<List<TbDiscountProductMapping>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbDiscountProductMapping discountProductMapping);
public Task<bool> Update(TbDiscountProductMapping discountProductMapping);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }