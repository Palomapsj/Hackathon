using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Care.Api.Business.Models
{
    public class DocumentLibraryFilterModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string? Title { get; set; }
        public string? Status { get; set; }
        public string? Profile { get; set; }
    }
}
