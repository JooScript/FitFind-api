using ECommerce.Bl.Contracts.Base;
using ECommerce.Bl.Dtos.Business;
using ECommerce.Domains.Models;

namespace ECommerce.Bl.Contracts.Business;

public interface IAuditLog : IBaseService<TbAuditLog, AuditLogDto>
{
  
}