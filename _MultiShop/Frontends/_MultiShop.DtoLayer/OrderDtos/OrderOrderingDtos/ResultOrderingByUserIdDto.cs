using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _MultiShop.DtoLayer.OrderDtos.OrderOrderingDtos
{
    public class ResultOrderingByUserIdDto
    {
        public int OrderingID { get; set; }
        public string UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
