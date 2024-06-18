using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAdjustment.Shared
{
    public class ProductAdjustament
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ExternalId { get; set; }
        public string? Description { get; set; }
        public string? BarCode { get; set; }
        public int QuantityHand { get; set; }
        public int QuantityCounted { get; set; }
        public int Difference { get; set; }

        public int AdjustamentId { get; set; }
    }
}
