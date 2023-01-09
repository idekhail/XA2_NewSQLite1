using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XA2_NewSQLite1
{
    [Activity(Label = "ShowActivity")]
    public class ShowActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_show);

            var uid = FindViewById<TextView>(Resource.Id.uid);
            var username = FindViewById<TextView>(Resource.Id.username);
            var password = FindViewById<TextView>(Resource.Id.password);
            var show = FindViewById<TextView>(Resource.Id.show);

            var update = FindViewById<Button>(Resource.Id.update);
            var logout = FindViewById<Button>(Resource.Id.logout);
            var all = FindViewById<Button>(Resource.Id.all);

            UserOperations.Users user;

            string id = Intent.GetStringExtra("Id");
            var sq = new UserOperations();
            if (id != null)
            {
                user = sq.GetUserById(Convert.ToInt32(id));
                uid.Text = user.Id + "";
                username.Text = user.Username;
                password.Text = user.Password;

                update.Click += delegate
                {
                    Intent i = new Intent(this, typeof(UpdateActivity));
                    i.PutExtra("Id", user.Id + "");
                    StartActivity(i);
                };
            }
            all.Click += delegate
            {
                var tables = sq.GetAllUsers();
                string data = "";
                foreach (var s in tables)
                    data += s.Id + "\t" + s.Username + "\t" + s.Password + "\n";
                show.Text = data;
            };

            logout.Click += delegate
            {
                user = null;
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };
        }
    }
}