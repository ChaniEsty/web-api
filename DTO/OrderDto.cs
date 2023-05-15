using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int Ordersum { get; set; }
        
        public virtual ICollection<OrderItem> OrderItems { get; } = new List<OrderItem>();

    }
}
