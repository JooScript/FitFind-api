using ECommerce.Models;
    public interface IPaymentTransaction
    {
public Task<TbPaymentTransaction> GetById(long id);
public Task<List<TbPaymentTransaction>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbPaymentTransaction paymentTransaction);
public Task<bool> Update(TbPaymentTransaction paymentTransaction);
public Task<bool> Save(TbPaymentTransaction paymentTransaction);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }