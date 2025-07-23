using ECommerce.Da;

namespace ECommerce.DTO
{
    public class MethodDTO
    {
        public long Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string? Description
        {
            get;
            set;
        }

        public bool? Is_active
        {
            get;
            set;
        }

        public decimal? Cost
        {
            get;
            set;
        }

        public string? Calculation_method
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }


}}