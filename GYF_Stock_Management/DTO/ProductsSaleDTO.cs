using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GYF_Stock_Management.DTO
{
    /// <summary>
    /// Corresponde al DTO que se utiliza en la vista para devolver los productos para venderle al cliente segun su presupuesto
    /// </summary>
    public class ProductsSaleDTO
    {
        public int ProductA { get; set; }
        public int ProductB { get; set; }
        public int PriceA { get; set; }
        public int PriceB { get; set; }
        public string CategoryA { get; set; }
        public string CategoryB { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime UploadDateA { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime UploadDateB { get; set; }

        [Required(ErrorMessage = "Requerido")]
        [Range(0, 1000000, ErrorMessage = "El presupuesto debe estar entre 0 y 1.000.000")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "No es un número válido")]
        public int Budget { get; set; }
        public int Total { get; set; }

    }
}
