using ECommerce.Models;
    public interface IAttributeData
    {
public Task<TbAttribute> GetById(long id);
public Task<List<TbAttribute>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbAttribute attribute);
public Task<bool> Update(TbAttribute attribute);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }