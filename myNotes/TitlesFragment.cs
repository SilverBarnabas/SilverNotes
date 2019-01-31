using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using myNotes;

namespace FragmentSample
{
    public class TitlesFragment : ListFragment
    {
        int selectedNoteId;
        bool showingTwoFragments;
        DatabaseHelper databaseHelper = new DatabaseHelper();

        public TitlesFragment()
        {

        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            databaseHelper.CreateDatabaseWithTable();
            var titles = databaseHelper.GetAllNotes().ToList().Select(p => p.Title).ToArray();

            base.OnActivityCreated(savedInstanceState);
            ListAdapter = new ArrayAdapter<string>(Activity,
                Android.Resource.Layout.SimpleListItemActivated1, titles);

            if (savedInstanceState != null)
            {
                selectedNoteId = savedInstanceState.GetInt("current_note_id", 0);
            }

            var quoteContainer = Activity.FindViewById(2131230861);
            showingTwoFragments = quoteContainer != null &&
                quoteContainer.Visibility == ViewStates.Visible;

            if (showingTwoFragments)
            {
                ListView.ChoiceMode = ChoiceMode.Single;
                ShowPlayNote(selectedNoteId);
            }
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("current_note_id", selectedNoteId);
        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            ShowPlayNote(position);
        }

        private void ShowPlayNote(int NoteId)
        {
            selectedNoteId = NoteId;
            if (showingTwoFragments)
            {
                ListView.SetItemChecked(selectedNoteId, true);
                var PlayNoteFragment = FragmentManager.FindFragmentById(2131230861)
                    as PlayNoteFragment;

                if (PlayNoteFragment == null || PlayNoteFragment.NoteId != NoteId)
                {
                    var container = Activity.FindViewById(2131230861);
                    var quoteFrag = PlayNoteFragment.NewInstance(selectedNoteId);

                    FragmentTransaction ft = FragmentManager.BeginTransaction();
                    ft.Replace(2131230861, quoteFrag);
                    ft.Commit();
                }
            }
            else
            {
                var intent = new Intent(Activity, typeof(PlayNoteActivity));
                intent.PutExtra("current_note_id", NoteId);
                StartActivity(intent);
            }
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}