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

        //Peticion get solo un contacto
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
    }
}
