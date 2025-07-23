using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsImage : IImage
    {
        ImageData oImageData;

        public ClsImage(ECommerceContext context)
        {
            oImageData = new ImageData(context);
        }
               public async Task<TbImage> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var image = await oImageData.GetById(id);
                return image;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbImage image)
        {
              long imageId = -1;
            try
            {
                imageId = await oImageData.Add(image);
                return imageId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbImage image)
        {
            try
            {
                return await oImageData.Update(image);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbImage image) => image.Id <= 0 ? await Add(image) != -1 : await Update(image);
        public async Task<List<TbImage>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oImageData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oImageData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oImageData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oImageData.Delete(id);
        }

    }
}