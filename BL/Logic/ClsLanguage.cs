using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsLanguage : ILanguage
    {
        LanguageData oLanguageData;

        public ClsLanguage(ECommerceContext context)
        {
            oLanguageData = new LanguageData(context);
        }
               public async Task<TbLanguage> GetById(int id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var language = await oLanguageData.GetById(id);
                return language;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<int> Add(TbLanguage language)
        {
              int languageId = -1;
            try
            {
                languageId = await oLanguageData.Add(language);
                return languageId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbLanguage language)
        {
            try
            {
                return await oLanguageData.Update(language);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbLanguage language) => language.Id <= 0 ? await Add(language) != -1 : await Update(language);
        public async Task<List<TbLanguage>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oLanguageData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(int id)
        {
            return await oLanguageData.IsExists(id);
        }

        public async Task<int> Count()
        {
            return await oLanguageData.Count();
        }

        public async Task<bool> Delete(int id)
        {
            return await oLanguageData.Delete(id);
        }

    }
}