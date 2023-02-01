using Login.Data;
using Login.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Login.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsContoller : ControllerBase
    {
        private readonly LoginDataDBContext _context;
        public LoginsContoller(LoginDataDBContext context) => _context = context;

        [HttpGet]
        public async Task<IEnumerable<LoginData>> Get()
        => await _context.LoginDatas.ToListAsync();

        [HttpGet("id")]
        [ProducesResponseType(typeof(LoginData), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByd(int id)
        {
            var loginData = await _context.LoginDatas.FindAsync(id);   
            return loginData == null ? NotFound() : Ok(loginData);  
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(LoginData loginData)
        {
            await _context.LoginDatas.AddAsync(loginData);  
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByd), new {id = loginData.Id}, loginData );
        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, LoginData loginData)
        {
            if (id != loginData.Id) return BadRequest();    

            _context.Entry(loginData).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var loginDataToDelete = await _context.LoginDatas.FindAsync(id);    
            if (loginDataToDelete == null) return NotFound();

            _context.LoginDatas.Remove(loginDataToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
    }
}
