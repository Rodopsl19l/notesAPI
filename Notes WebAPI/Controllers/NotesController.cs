﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notes.Core;
using Notes.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes_WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly ILogger<NotesController> _logger;
        private INotesServices _notesServices;

        public NotesController(ILogger<NotesController> logger, INotesServices notesServices)
        {
            _logger = logger;
            _notesServices = notesServices;
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_notesServices.GetNotes());
        }

        [HttpGet("{id}", Name = "GetNoteById")]
        public IActionResult GetNoteById(int id)
        {
            return Ok(_notesServices.GetNoteById(id));
        }


        [HttpPost]
        public IActionResult CreateNote(Note note)
        {
            var newNote = _notesServices.CreateNote(note);

            return CreatedAtRoute("GetNoteById", new { newNote.Id }, newNote);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            _notesServices.DeleteNote(id);

            return Ok();
        }

        [HttpPut]
        public IActionResult EditNote([FromBody] Note note)
        {
            _notesServices.EditNote(note);

            return Ok();
        }
    }
}