using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudWebApi.Data;
using CrudWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : Controller
    {
        private readonly AppDbContexto _context;

        public ContactosController(AppDbContexto contexto)
        {
            _context = contexto;
        }

        //Peticion get todos los contactos: api/contactos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContactoItems()
        {
            return await _context.ContactoItems.ToListAsync();
        }

        //Peticion get solo un contacto:: api/contactos/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Contacto>> GetContactoItems(int id)
        {
            var contactoItems = await _context.ContactoItems.FindAsync(id);

            if(contactoItems ==  null)
            {
                return NotFound();
            }

            return contactoItems;
        }

        //Peticion post: api/contactos
        [HttpPost]
        public async Task<ActionResult<Contacto>> PostContactoItem(Contacto item)
        {
            _context.ContactoItems.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetContactoItems), new { id = item.Id }, item);
        }

        //Peticion put: api/contactos/2
        [HttpPut("{id}")]
        public async Task<ActionResult> PutContactoItem(int id,Contacto item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //Peticion delete: api/contactos/3
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContactoItem(int id)
        {
            var contactoItem = await _context.ContactoItems.FindAsync(id);

            if(contactoItem == null)
            {
                return NotFound();
            }

            _context.ContactoItems.Remove(contactoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }//Fin
}
