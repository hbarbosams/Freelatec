using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ErrorViewModel
    {
        public string requestId { get; set; }

        public bool showRequestId => !string.IsNullOrEmpty(requestId);
    }
}
