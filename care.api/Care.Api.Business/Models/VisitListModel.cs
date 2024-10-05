namespace Care.Api.Business.Models
{
	public class VisitListModel
	{
		public Guid? VisitId { get; set; }
		public string? Name { get; set; }
		public DateTime? ScheduleDateStart { get; set; }
		public string? FriendlyCode { get; set; }
		public string? CustomString1 { get; set; }		

	}
}
