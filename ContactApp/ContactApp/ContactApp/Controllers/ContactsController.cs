using ContactApp.Data;
using ContactApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Controllers
{

    //Deklaracja kontrolera
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        //Konstuktor

        private readonly DataContext _context;

        public ContactsController(DataContext context)
        {
            _context = context;
        }

        //Pobieranie listy wszystkich kontaktów
        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return Ok(contacts);
        }

        //Pobieranie kontaktów o podanycm ID 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        //Tworzenie nowego kontaktu
        [HttpPost]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
        }

        //Aktualizacja kontaktu
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            contact.BirthDate = contact.BirthDate.Date;

            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //Usunięcie kontaktu
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
