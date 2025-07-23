using ECommerce.Models;
    public interface IAttributeValueData
    {
public Task<TbAttributeValue> GetById(long id);
public Task<List<TbAttributeValue>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbAttributeValue attributeValue);
public Task<bool> Update(TbAttributeValue attributeValue);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }