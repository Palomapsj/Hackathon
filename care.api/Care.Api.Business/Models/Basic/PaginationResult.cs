namespace Care.Api.Business.Models.Basic
{
    public class PaginationResult<T>
    {
        public int TotalSize { get; set; }
        public T Data { get; set; }
        public object Results { get; set; }
        public object TotalCount { get; set; }
    }
}
