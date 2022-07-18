using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class PaginationReqDTO
    {
        public int Page { get; set; } = 0;
        public int Limit { get; set; } = 10;
    }
}
