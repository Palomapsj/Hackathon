namespace Care.Api.Business.Models
{
    public class AddressModel
    {
        public Guid Id { get; set; }
        public string AddressPostalCode { get; set; }
        public string? AddressComplement { get; set; }
        public string AddressName { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressNumber { get; set; }
        public string AddressDistrict { get; set; }
        public string? FullAddress { get; set; }        
    }
}
