using ECommerce.Models;
    public interface IDiscountCategoryMappingData
    {
public Task<TbDiscountCategoryMapping> GetById(long id);
public Task<List<TbDiscountCategoryMapping>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbDiscountCategoryMapping discountCategoryMapping);
public Task<bool> Update(TbDiscountCategoryMapping discountCategoryMapping);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }