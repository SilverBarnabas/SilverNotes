using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;
using System.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace myNotes
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();
        List<string> TitleList = new List<string>(Titles);
        List<string> NoteList = new List<string>(Notes);
        protected override void OnCreate(Bundle savedInstanceState)
        {
            AppCenter.Start("f7b0e755-ddd6-4d95-ae39-182898b66142", typeof(Analytics), typeof(Crashes));
 
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            //DEBUG: Sample notes into Database
            //File.Delete(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myNotes2.db3"));
            //databaseHelper.CreateDatabaseWithTable();

            //for (int i = 0; i < TitleList.Count; i++)
            //{
            //    databaseHelper.AddNote(TitleList[i], NoteList[i]);
            //}
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.AddNote)
            {
                StartActivity(typeof(CreateNoteActivity));
                Toast.MakeText(this, "Write your note and press the button again.", ToastLength.Short).Show();
                return true;
            }
            return base.OnOptionsItemSelected(item);

        }
        public static string[] Titles = {
                                      "asd",
                                      "das",
                                      "HasdI",
                                    };


        public static string[] Notes = {
                                        "Tere opetaja"
                                    };
    }
}