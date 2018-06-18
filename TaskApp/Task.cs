using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TaskApp
{
    class Task
    {
        public String shortDescription;
        public String longDescription;
        public int percentage;

        public Task()
        {

        }

        public override String ToString()
        {
            return string.Format("Short description: {0}, percentage: {1}",
                                 this.shortDescription, this.percentage);
        }
    }
}