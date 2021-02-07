
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RepairShop.Server.DataBase;
using RepairShop.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using RepairShop.Shared.Models;

namespace RepairShop.Server.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]

    public class CheckInOutController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public CheckInOutController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("CheckInCustomer")]
        public IActionResult AddCheckInToCustomer(AddCheckInToCustomerDto dto)
        {
            var customer = _dbContext.CustomerDataT
                .Where(x => x.Id == dto.CustomerDataId)
                .Include(x => x.TvCheckIns)
                .FirstOrDefault();
            if (customer == null) return NotFound();
            var newcheckin = new TvCheckIn
            {
                Failure = dto.Failure,
                Returned = dto.Returned,
                DateIn = dto.DateIn,
                
            };
            customer.TvCheckIns=customer.TvCheckIns.Append(newcheckin).ToList();
            _dbContext.SaveChanges();
            return Ok();
        }
        
        
        [HttpPost("CheckOutCustomer")]
        public IActionResult CheckOutCustomer(CustomerCheckOutDto checkOutDto)
        {
            //find customer with checkins with checkouts
            var customer = _dbContext.CustomerDataT
                .Where(x => x.Id == checkOutDto.CustomerId)
                .Include(x => x.TvCheckIns)
                
                .ThenInclude(x => x.TvCheckOut)
                
                .FirstOrDefault();
                
            if (customer == null)
            {
                return NotFound();
            }
            var res = customer.TvCheckIns
                
                .FirstOrDefault(x => x.Id == checkOutDto.TvCheckInId && x.TvCheckOut ==null);
            
            if (res == null)
            {
                return NotFound();
            }
            var newcheckout = new TvCheckOut
            {
                Id = 0,
                Repaired = checkOutDto.Repaired,
                FeePaid = checkOutDto.FeePaid,
                OutDate = checkOutDto.OutDate,
                TvCheckIn = null,
                TvCheckInId = 0
            };

            res.TvCheckOut = newcheckout;
            _dbContext.SaveChanges();
            
            return Ok();

        }

    }
}