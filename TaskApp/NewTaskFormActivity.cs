using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TaskApp
{
    [Activity(Label = "NewTaskFormActivity")]
    public class NewTaskFormActivity : Activity
    {
        readonly string tag = "CEGG";
        int intPercentage = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.new_task_form_activity);

            Log.Debug(tag, "OnCreate() method");

            //                                                       // To register the click for buttons.
            Button buttonCancel = FindViewById<Button>(Resource.Id.ButtonCancel);
            buttonCancel.Click += (sender, args) =>
            {
                CancelNewTask(sender, args);
            };

            Button buttonSave = FindViewById<Button>(Resource.Id.ButtonSave);
            buttonSave.Click += (sender, args) =>
            {
                SaveNewTask(sender, args);
            };

            TextView textPercentage = FindViewById<TextView>(Resource.Id.TextViewPercentage);
            string srtPercentage = "0%";
            bool boolDone = false;

            SeekBar seekBarPercentage = FindViewById<SeekBar>(Resource.Id.SeekBarPercentage);
            seekBarPercentage.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) =>
            {
                Log.Debug(tag, "como esta done " + boolDone);
                if (boolDone)
                {
                    srtPercentage = string.Format("{0}%", e.Progress);
                    textPercentage.Text = string.Format("100%");
                }
                else
                {
                    srtPercentage = string.Format("{0}%", e.Progress * 10.0);
                    textPercentage.Text = srtPercentage;
                }
            };

            Switch switchDone = FindViewById<Switch>(Resource.Id.SwitchDone);
            switchDone.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) =>
            {
                if (e.IsChecked)
                {
                    boolDone = true;
                    textPercentage.Text = string.Format("100%");
                }
                else
                {
                    boolDone = false;
                    textPercentage.Text = srtPercentage;
                }
            };


        }

        private void CancelNewTask(object sender, EventArgs args)
        {
            Log.Debug(tag, "click ButtonCancel");

            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void SaveNewTask(object sender, EventArgs args)
        {
            Log.Debug(tag, "click ButtonSave");

            Task task = new Task();

            TextView shortDescription = FindViewById<TextView>(Resource.Id.EditTextShort);
            task.shortDescription = shortDescription.Text;

            TextView longDescription = FindViewById<TextView>(Resource.Id.EditTextLong);
            task.longDescription = longDescription.Text;


            task.percentage = this.intPercentage;

            Log.Debug(tag, "TASK: " + task.ToString());

            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
        
    }


}