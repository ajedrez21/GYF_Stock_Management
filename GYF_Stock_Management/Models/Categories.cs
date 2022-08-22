using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GYF_Stock_Management.Models
{
    public class Categories
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public List<Products> Products { get; set; }
    }
}
