using ECommerce.Models;
    public interface ILanguageData
    {
public Task<TbLanguage> GetById(int id);
public Task<List<TbLanguage>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<int> Add(TbLanguage language);
public Task<bool> Update(TbLanguage language);
public Task<bool> IsExists(int id);
public Task<int> Count();
public Task<bool> Delete(int id);

    }