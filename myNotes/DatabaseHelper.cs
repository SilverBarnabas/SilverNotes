using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace myNotes
{
    public class DatabaseHelper
    {
        SQLiteConnection db;
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myNotes2.db3");

        public void CreateDatabaseWithTable()
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Note>();
        }

        public TableQuery<Note> GetAllNotes()
        {
            db = new SQLiteConnection(dbPath);
            return db.Table<Note>();
        }

        public void AddNote(string title, string content)
        {
            Note newNote = new Note();
            newNote.Title = title;
            newNote.ID = (GetAllNotes().ToList().Count() + 1);
            newNote.CreationTime = DateTime.Now;
            newNote.Content = content;
            db.Insert(newNote);
        }

        public void DeleteNote(int id)
        {
            db = new SQLiteConnection(dbPath);
            Note noteToDelete = new Note();
            noteToDelete.ID = id;
            db.Delete(noteToDelete);
        }
        public void EditNote(int id, string title, string content)
        {
            db = new SQLiteConnection(dbPath);
            var allnotes = GetAllNotes();
            var query = from ord in allnotes
                        where ord.ID == id
                        select ord;
            foreach (Note note in query)
            {
                note.ID = id;
                note.Title = title;
                note.Content = content;
                note.CreationTime = DateTime.Now;
                db.Update(note);
            }
        }
    }
}