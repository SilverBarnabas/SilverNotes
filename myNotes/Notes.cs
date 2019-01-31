using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using SQLite;

namespace myNotes
{
    public class Note
    {
        [PrimaryKey, Column("_id")]
        public int ID { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Content { get; set; }
        [MaxLength(255)]
        public DateTime CreationTime { get; set; }
    }
}