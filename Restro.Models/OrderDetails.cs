using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restro.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int Qty { get; set; }
        
        public int FoodItemId { get; set; }

        public int UserId { get; set; }
    }
}
