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

namespace myNotes
{
    [Activity(Label = "CreateNoteActivity")]
    public class CreateNoteActivity : Activity
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CreateNote);
            Button btn = FindViewById<Button>(Resource.Id.button_save);
            btn.Click += SaveButton_Clicked;
        }
        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            EditText title = FindViewById<EditText>(Resource.Id.txtNote_edit);
            EditText note = FindViewById<EditText>(Resource.Id.txtNoteGlimpse_edit);

            databaseHelper.AddNote(title.Text, note.Text);
            StartActivity(typeof(MainActivity));

        }
    }
}