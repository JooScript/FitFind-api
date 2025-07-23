using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsSubscription : ISubscription
    {
        SubscriptionData oSubscriptionData;

        public ClsSubscription(ECommerceContext context)
        {
            oSubscriptionData = new SubscriptionData(context);
        }
               public async Task<TbSubscription> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var subscription = await oSubscriptionData.GetById(id);
                return subscription;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbSubscription subscription)
        {
              long subscriptionId = -1;
            try
            {
                subscriptionId = await oSubscriptionData.Add(subscription);
                return subscriptionId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbSubscription subscription)
        {
            try
            {
                return await oSubscriptionData.Update(subscription);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbSubscription subscription) => subscription.Id <= 0 ? await Add(subscription) != -1 : await Update(subscription);
        public async Task<List<TbSubscription>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oSubscriptionData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oSubscriptionData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oSubscriptionData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oSubscriptionData.Delete(id);
        }

    }
}