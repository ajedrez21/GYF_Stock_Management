using GYF_Stock_Management.Data;
using GYF_Stock_Management.DTO;
using GYF_Stock_Management.Interfaces;
using GYF_Stock_Management.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GYF_Stock_Management.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISalesRepository _salesRepository;
        private readonly ILogger<SalesController> _logger;
        public SalesController(ISalesRepository salesRepository, ILogger<SalesController> logger)
        {
            _salesRepository = salesRepository;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Este metodo se utiliza para buscar los productos para venderle al cliente, segun su presupuesto
        /// </summary>
        /// <param name="budget">Corresponde al parametro presupuesto que ingresan desde la vista</param>
        /// <returns>Devuelve, en caso de encontrar, dos productos, uno correspondiente a cada categoria. En  caso de no cumplir con la condicion no devuelve nada</returns>
        public async Task<IActionResult> ListProducts(int budget)
        {
            _logger.LogInformation("Starts ListProducts from SalesController");
            ProductsSaleDTO result = null;
            try
            {
                _logger.LogInformation("Call to method ListProductsSale");
                result = await _salesRepository.ListProductsSale(budget);
                _logger.LogInformation("Finish repository method without errors");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(string.Format("Finish repository method with errors", ex.Message));
                Console.WriteLine(ex.Message);
            }
            return View("~/Views/Sales/Index.cshtml", result);
        }
    }
}
