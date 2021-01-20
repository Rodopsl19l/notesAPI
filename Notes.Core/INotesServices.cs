using Notes.DB;
using System;
using System.Collections.Generic;
using System.Text;

namespace Notes.Core
{
    public interface INotesServices
    {
        List<Note> GetNotes();
        Note GetNoteById(int id);
        Note CreateNote(Note note);
        void DeleteNote(int id);
        void EditNote(Note note);
    }
}
