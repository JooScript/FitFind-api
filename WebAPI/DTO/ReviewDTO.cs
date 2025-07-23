using ECommerce.Da;

namespace ECommerce.DTO
{
    public class ReviewDTO
    {
        public long Id
        {
            get;
            set;
        }

        public long? Product_Id
        {
            get;
            set;
        }

        public string? User_Id
        {
            get;
            set;
        }

        public int Rating
        {
            get;
            set;
        }

        public string? Title
        {
            get;
            set;
        }

        public string? Comment
        {
            get;
            set;
        }

        public DateTimeOffset? Review_date
        {
            get;
            set;
        }

        public bool? Is_approved
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