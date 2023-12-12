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
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Author>> GetAuthors()
        {
            var authors = new List<Author>
            {
                new Author { Id = 1, Name = "John Doe" }
            };

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorById(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Author))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<Author>> CreateAuthor([FromBody] Author author)
        {
            if (author == null)
            {
                return BadRequest();
            }

            var addedAuthor = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Name == author.Name);

            if (addedAuthor != null)
            {
                return BadRequest("Author already exists");
            }
            else
            {
                await _dbContext.Authors.AddAsync(author);
                await _dbContext.SaveChangesAsync();

                return Created("api/author", author);
            }
        }
    }
}
