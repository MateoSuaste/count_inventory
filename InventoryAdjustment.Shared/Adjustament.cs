using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryAdjustment.Shared;

namespace InventoryAdjustment.Shared
{
    public class Adjustament
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public string? Name { get; set; }
        public DateTime Date_created {  get; set; }
        public List<ProductAdjustament>? Products { get; set; }

        public Adjustament() 
        {
          Products = new List<ProductAdjustament>();
        }
    }

}
