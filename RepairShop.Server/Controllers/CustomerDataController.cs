using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepairShop.Server.DataBase;
using RepairShop.Shared.DTOs;
using RepairShop.Shared.Extensions;
using RepairShop.Shared.Models;

namespace RepairShop.Server.Controllers
{ 
    
    [ApiController]
    [Route("api/[controller]")]
 
    public class CustomerDataController: ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CustomerDataController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        
        [HttpGet]
        public async Task<IEnumerable<DisplayCustomerDto>> GetAllCustomers()
        {
            List<CustomerData> customers = 
                await _dbContext.GetAllCustomerTvsAndCheckins().ToListAsync();

            List<DisplayCustomerDto> displayCustomerDtos =  
                customers.Select(c => c.ToDto()).ToList();
  
            return displayCustomerDtos;
        }

        [HttpPost]
        public IActionResult AddCustomerData(AddCustomerDto customerDto)
        {

            TvCheckIn tvCheckIn = new TvCheckIn
            {
                Failure = customerDto.Failure,
                CustomerData = null, 
                CustomerDataId = 0, 
                DateIn = customerDto.DateIn, 
                Id = 0,
                Returned = customerDto.Returned, 
                TvCheckOut = null
            };

            CustomerData customerData = new CustomerData
            {
                Id = 0, Name = customerDto.Name, 
                PhoneNumber = customerDto.PhoneNumber, 
                TvBrand = customerDto.TvBrand, 
                TvCheckIns = new []{tvCheckIn},
                TvInch = customerDto.TvInch
            };
            
            
            _dbContext.Add(customerData);
            _dbContext.SaveChanges();
            return Ok();
        }
        
        
        
    }
    
}