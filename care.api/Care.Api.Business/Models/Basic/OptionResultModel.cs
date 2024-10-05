namespace Care.Api.Business.Models.Basic
{
    public class OptionResultModel<TValue>
    {
        public required TValue Value { get; set; }
        public required string Label { get; set; }
        public string? Info { get; set; }
    }
}
