using GYF_Stock_Management.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYF_Stock_Management.Interfaces
{
    public interface ISalesRepository
    {
        public Task<ProductsSaleDTO> ListProductsSale(int price);
    }
}
