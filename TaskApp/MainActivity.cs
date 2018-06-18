using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;
using Android.Content;

namespace TaskApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // SetContentView(Resource.Layout.new_task_form_activity);
            Button newTaskButton = FindViewById<Button>(Resource.Id.ShowNewTaskForm);
            newTaskButton.Click += (sender, args) =>
            {
                BtnLoadNewTask(sender, args);
            };

            Button newbtnLoadTaskList = FindViewById<Button>(Resource.Id.ShowTaskListForm);
            newbtnLoadTaskList.Click += (sender, args) =>
            {
                BtnLoadTaskList(sender, args);
            };
        }

        private void BtnLoadNewTask(object sender, EventArgs args)
        {
            Intent intent = new Intent(this, typeof(NewTaskFormActivity));
            StartActivity(intent);

            // throw new NotImplementedException();
        }

        private void BtnLoadTaskList(object sender, EventArgs args)
        {
            Intent intent = new Intent(this, typeof(TaskListActivity));
            StartActivity(intent);

            // throw new NotImplementedException();
        }


    }
}

