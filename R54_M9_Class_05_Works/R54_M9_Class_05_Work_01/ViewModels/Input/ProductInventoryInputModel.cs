using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace R54_M9_Class_05_Work_01.ViewModels.Input
{
    public class ProductInventoryInputModel
    {
        public string? Key { get; set; }
        public int ProductInventoryId { get; set; }

        [Required, Column(TypeName = "date"), DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required, ForeignKey("Product")]
        public int ProductId { get; set; }
    }
}
