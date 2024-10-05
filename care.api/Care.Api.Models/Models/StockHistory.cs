using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Models.Models
{
    public class StockHistory : BaseEntity
    {

        public static int EntityTypeCode => 905;
        public static string EntityName => "StockHistory";

        
        public Guid TypeOfTransactionStringMapId { get; set; }
        public decimal Quantity { get; set; }
        public string? LogisticsCode { get; set; }
        public Guid StockId { get; set; }
        public Guid LogisticsStuffId { get; set; }


        public Guid? HealthProgramId { get; set; }

        public Guid? DeletedBy { get; set; }

        public string? DeletedByName { get; set; }

        public string? ReasonStateCode { get; set; }

        public string? ReasonDeleted { get; set; }

        public string? FriendlyCode { get; set; }

        public string? ImportCode { get; set; }

        public string? InternalControl { get; set; }

        public string Name { get; set; }

        public string? ReceiptInvoice { get; set; }
    }
}
