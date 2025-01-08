using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using profile_service.Data;
using profile_service.Data_classes;


namespace profile_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContarctController : ControllerBase
    {

        private readonly AppDbContext _context;

        public ContarctController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contract>> contractrturn(int id)
        {
            
            return await _context.Contracts.FindAsync(id);
        }

        [HttpDelete("{id}")]

        [HttpPut("{id}")]

        [HttpPost("{id}")]

    }
}
