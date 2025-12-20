using AutoMapper;
using ECommerce.Bl.Contracts.Auth;
using ECommerce.Bl.Contracts.Business;
using ECommerce.Bl.Contracts.Events;
using ECommerce.Bl.Dtos.Business;
using ECommerce.Bl.Services.Base;
using ECommerce.Da.Contracts;
using ECommerce.Domains.Models;

namespace ECommerce.Bl.Services.Auditing;

public class AuditLogService(ITableQryRepo<TbAuditLog> repoQuery, ITableCmdRepo<TbAuditLog> repoCommand, IMapper mapper, IUserQryService userServiceQuery, ICrudPublisher publisher) : BaseService<TbAuditLog, AuditLogDto>(repoQuery, repoCommand, mapper, userServiceQuery, publisher), IAuditLog
{ }