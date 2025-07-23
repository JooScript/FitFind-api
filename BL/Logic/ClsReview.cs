using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsReview : IReview
    {
        ReviewData oReviewData;

        public ClsReview(ECommerceContext context)
        {
            oReviewData = new ReviewData(context);
        }
               public async Task<TbReview> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var review = await oReviewData.GetById(id);
                return review;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbReview review)
        {
              long reviewId = -1;
            try
            {
                reviewId = await oReviewData.Add(review);
                return reviewId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbReview review)
        {
            try
            {
                return await oReviewData.Update(review);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbReview review) => review.Id <= 0 ? await Add(review) != -1 : await Update(review);
        public async Task<List<TbReview>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oReviewData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oReviewData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oReviewData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oReviewData.Delete(id);
        }

    }
}