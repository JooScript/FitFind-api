using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsUserActivity : IUserActivity
    {
        UserActivityData oUserActivityData;

        public ClsUserActivity(ECommerceContext context)
        {
            oUserActivityData = new UserActivityData(context);
        }
               public async Task<TbUserActivity> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var userActivity = await oUserActivityData.GetById(id);
                return userActivity;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbUserActivity userActivity)
        {
              long userActivityId = -1;
            try
            {
                userActivityId = await oUserActivityData.Add(userActivity);
                return userActivityId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbUserActivity userActivity)
        {
            try
            {
                return await oUserActivityData.Update(userActivity);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbUserActivity userActivity) => userActivity.Id <= 0 ? await Add(userActivity) != -1 : await Update(userActivity);
        public async Task<List<TbUserActivity>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oUserActivityData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oUserActivityData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oUserActivityData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oUserActivityData.Delete(id);
        }

    }
}