using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsCategory : ICategory
    {
        CategoryData oCategoryData;

        public ClsCategory(ECommerceContext context)
        {
            oCategoryData = new CategoryData(context);
        }
               public async Task<TbCategory> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var category = await oCategoryData.GetById(id);
                return category;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbCategory category)
        {
              long categoryId = -1;
            try
            {
                categoryId = await oCategoryData.Add(category);
                return categoryId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbCategory category)
        {
            try
            {
                return await oCategoryData.Update(category);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbCategory category) => category.Id <= 0 ? await Add(category) != -1 : await Update(category);
        public async Task<List<TbCategory>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oCategoryData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oCategoryData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oCategoryData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oCategoryData.Delete(id);
        }

    }
}