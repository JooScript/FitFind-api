using ECommerce.Models;
    public interface IProductTranslationMapping
    {
public Task<TbProductTranslationMapping> GetById(long id);
public Task<List<TbProductTranslationMapping>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbProductTranslationMapping productTranslationMapping);
public Task<bool> Update(TbProductTranslationMapping productTranslationMapping);
public Task<bool> Save(TbProductTranslationMapping productTranslationMapping);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }