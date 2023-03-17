using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hrm.Recruiting.ApplicationCore.Model
{
    public class BlobContent
    {
        public Stream Content { get; set; }
        public string ContentType { get; set; }
    }
}
