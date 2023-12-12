using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Client>> GetClients()
        {
            var clients = new List<Client>
            {
                new Client { Id = 1, Name = "John Doe" }
            };

            return Ok(clients);
        }
    }
}
