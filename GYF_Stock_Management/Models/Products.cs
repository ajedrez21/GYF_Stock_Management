using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GYF_Stock_Management.Models
{
    public class Products
    {
        [Key]
        public int ID { get; set; }
        public int Price { get; set; }
        
        public DateTime Upload_Date { get; set; }
        [ForeignKey("Category")]
        public virtual Categories Categories { get; set; }
    }
}
