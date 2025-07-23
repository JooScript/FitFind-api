using ECommerce.Models;
    public interface IPaymentData
    {
public Task<TbPayment> GetById(long id);
public Task<List<TbPayment>> GetAll(int pageNumber = 1, int pageSize = 50);
public Task<long> Add(TbPayment payment);
public Task<bool> Update(TbPayment payment);
public Task<bool> IsExists(long id);
public Task<long> Count();
public Task<bool> Delete(long id);

    }