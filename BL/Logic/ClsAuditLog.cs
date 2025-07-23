using ECommerce.Da;
using ECommerce.Models;
using Utilities;

namespace ECommerce.Bl
{
    public class ClsAuditLog : IAuditLog
    {
        AuditLogData oAuditLogData;

        public ClsAuditLog(ECommerceContext context)
        {
            oAuditLogData = new AuditLogData(context);
        }
               public async Task<TbAuditLog> GetById(long id)
        {
            if (id <= 0 || id == null)
            {
                return null;
            }

            try
            {
                var auditLog = await oAuditLogData.GetById(id);
                return auditLog;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return null;
            }
        }

              public async Task<long> Add(TbAuditLog auditLog)
        {
              long auditLogId = -1;
            try
            {
                auditLogId = await oAuditLogData.Add(auditLog);
                return auditLogId;
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return -1;
            }
        }

            public async Task<bool> Update(TbAuditLog auditLog)
        {
            try
            {
                return await oAuditLogData.Update(auditLog);
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                return false;
            }
        }

 public async Task<bool> Save(TbAuditLog auditLog) => auditLog.Id <= 0 ? await Add(auditLog) != -1 : await Update(auditLog);
        public async Task<List<TbAuditLog>> GetAll(int pageNumber = 1, int pageSize = 50)
        {
            try
            {
                return await oAuditLogData.GetAll( pageNumber,  pageSize );
            }
            catch (Exception ex)
            {
                Helper.ErrorLogger(ex);
                throw;
            }
        }

        public async Task<bool> IsExists(long id)
        {
            return await oAuditLogData.IsExists(id);
        }

        public async Task<long> Count()
        {
            return await oAuditLogData.Count();
        }

        public async Task<bool> Delete(long id)
        {
            return await oAuditLogData.Delete(id);
        }

    }
}