namespace Care.Api.Models.Models
{
    public class Stock : BaseEntity
    {


        public Guid LogisticsStuffId { get; set; }
        public decimal Quantity { get; set; }
        public decimal FinalQuantity { get; set; }
        public decimal NotificationQuantity { get; set; }
        public string Lot { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int DaysBeforeExpire { get; set; }
        public Guid LogisticsResponsibleId { get; set; }
        public string ReceiptInvoice { get; set; }


        public Guid? HealthProgramId { get; set; }
        

        public Guid? DeletedBy { get; set; }

        public string? DeletedByName { get; set; }

        public string? ReasonStateCode { get; set; }

        public string? ReasonDeleted { get; set; }

        public string FriendlyCode { get; set; }

        public string? ImportCode { get; set; }

        public string? InternalControl { get; set; }


        public string Name { get; set; }

    }
}
