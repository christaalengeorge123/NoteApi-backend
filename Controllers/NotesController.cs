using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NoteAPI.Models;


namespace noteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NoteContext _context;

        public NotesController(NoteContext context)
        {
            _context = context;
        }
        [HttpGet]

        public ActionResult<IEnumerable<Note>> GetNoteItems()
        {
            return _context.NoteItems;
        }
        /* public ActionResult<IEnumerable<string>> GetString()
         {
             return new string[] { "this", "is", "hard", "coded" };
         }
         */

    }
}

