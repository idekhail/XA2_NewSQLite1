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
    [Activity(Label = "CreateActivity")]
    public class CreateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_create);

            var username = FindViewById<EditText>(Resource.Id.username);
            var password = FindViewById<EditText>(Resource.Id.password);
            
            var create = FindViewById<Button>(Resource.Id.create);
            var cancel = FindViewById<Button>(Resource.Id.cancel);

            create.Click += delegate
            {
                if (!string.IsNullOrEmpty(username.Text) && !string.IsNullOrEmpty(password.Text))
                {
                    var user = new UserOperations.Users()
                    {
                        Username = username.Text,
                        Password = password.Text,
                    };
                    var sq = new UserOperations();
                    sq.InsertUser(user);

                    Intent i = new Intent(this, typeof(LoginActivity));
                    StartActivity(i);
                }
                else                
                    Toast.MakeText(this, " UserName or Password is empty", ToastLength.Short).Show();
                
            };

            cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };
        }
    }
}