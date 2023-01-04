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
    [Activity(Label = "UpdateActivity")]
    public class UpdateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_update);

            var uid = FindViewById<TextView>(Resource.Id.uid);

            var username = FindViewById<EditText>(Resource.Id.username);
            var password = FindViewById<EditText>(Resource.Id.password);

            var update = FindViewById<Button>(Resource.Id.update);
            var delete = FindViewById<Button>(Resource.Id.delete);    
            var cancel = FindViewById<Button>(Resource.Id.cancel);


            uid.Text = Intent.GetStringExtra("Id");
            var sq = new UserOperations();
            var user = sq.GetUserById(Convert.ToInt32(uid.Text));

            username.Text = user.Username;
            password.Text = user.Password;

            update.Click += delegate
            {
                if (!string.IsNullOrEmpty(username.Text) && !string.IsNullOrEmpty(password.Text))
                {
                    user.Username = username.Text;
                    user.Password = password.Text;

                    var sq = new UserOperations();
                    sq.UpdateUser(user);
                    //user = null;
                    Intent i = new Intent(this, typeof(LoginActivity));
                    StartActivity(i);
                }
                else
                {
                    Toast.MakeText(this, " UserName or Password is empty", ToastLength.Short).Show();
                }
            };
            cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(ShowActivity));
                i.PutExtra("Id", user.Id + "");
                StartActivity(i);
            };
            delete.Click += delegate
            {
                var sq = new UserOperations();
                sq.DeleteUser(user);
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };

        }
    }
}