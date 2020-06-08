using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        [HttpPost]
        public ActionResult<Note> PostNoteItem(Note note)
        {
            _context.NoteItems.Add(note);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetNoteItems), new Note { Id = note.Id, Title = note.Title, Content = note.Content }, note);
        }
        [HttpPut("{id}")]
        public ActionResult PutNoteItem(int id, Note note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }

            _context.Entry(note).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult<Note> DeleteNoteItem(int id)
        {
            var noteItem = _context.NoteItems.Find(id);
            if (noteItem == null)
            {
                return NotFound();

            }
            _context.NoteItems.Remove(noteItem);
            _context.SaveChanges();
            return noteItem;
        }
        [HttpGet("{id}")]
        public ActionResult<Note> GetNoteItem(int id)
        {
            var noteItem = _context.NoteItems.Find(id);
            if (noteItem == null)
            {
                return NotFound();
            }
            return noteItem;
        }
    }
}

