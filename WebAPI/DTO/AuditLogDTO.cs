using ECommerce.Da;

namespace ECommerce.DTO
{
    public class AuditLogDTO
    {
        public long Id
        {
            get;
            set;
        }

        public string? UserId
        {
            get;
            set;
        }

        public string Action
        {
            get;
            set;
        }

        public string? Entity
        {
            get;
            set;
        }

        public long? EntityId
        {
            get;
            set;
        }

        public string? Details
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }

        public DateTimeOffset? Log_date
        {
            get;
            set;
        }


}}