using GYF_Stock_Management.Data;
using GYF_Stock_Management.DTO;
using GYF_Stock_Management.Interfaces;
using GYF_Stock_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYF_Stock_Management.Repositories
{
    public class SalesRepository: ISalesRepository
    {
        private readonly dbContext _context;
        private readonly ILogger<SalesRepository> _logger;
        public SalesRepository(dbContext context, ILogger<SalesRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        /// <summary>
        /// Metodo que hace la logica para encontrar ambos productos en base al presupuesto. 
        /// </summary>
        /// <param name="budget">Presupuesto</param>
        /// <returns></returns>
        public async Task<ProductsSaleDTO> ListProductsSale(int budget)
        {
            try
            {
                _logger.LogInformation("Starts ListProductsSale from SalesRepository");

                var resultado =  
                    from productA in _context.Products
                    join productB in _context.Products on productA.Categories.ID == 1 equals productB.Categories.ID == 2
                    where productA.Price + productB.Price <= budget
                    orderby productA.Price + productB.Price descending
                    select new ProductsSaleDTO
                    {
                        ProductA = productA.ID,
                        PriceA = productA.Price,
                        CategoryA = productA.Categories.Description,
                        UploadDateA = productA.Upload_Date,
                        ProductB = productB.ID,
                        PriceB = productB.Price,
                        CategoryB = productB.Categories.Description,
                        UploadDateB = productB.Upload_Date,
                        Total = productA.Price + productB.Price
                    };

                _logger.LogInformation("Finish ListProductsSale from SalesRepository without errors");
                return await resultado?.FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(string.Format("Finish ListProductsSale from SalesRepository with errors", ex.Message));
                return null;
            }
            
        }
       
    }
}
