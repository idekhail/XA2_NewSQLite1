using SQLite;

using System.Collections.Generic;
using System.IO;

namespace XA2_NewSQLite1
{
    internal class UserOperations
    {
        //database path
        private readonly string dbPath = Path.Combine(System.Environment.GetFolderPath(
            System.Environment.SpecialFolder.Personal), "xa2ns1.db3");

        //Constructor     
        public UserOperations()
        {
            //Creating database, if it doesn't already exist 
            if (!File.Exists(dbPath))
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Users>();
                //db.CreateTable<Students>();
            }
        }
 // Table Operations [CRUD]
        // User Insert
        public void InsertUser(Users user)
        {
            var db = new SQLiteConnection(dbPath);
            db.Insert(user);
        }
        // User Upbdate
        public void UpdateUser(Users user)
        {
            var db = new SQLiteConnection(dbPath);
            db.Update(user);
        }

        // User Delete
        public void DeleteUser(Users user)
        {
            var db = new SQLiteConnection(dbPath);
            db.Delete(user);
        }
        // User Login
        public Users LoginUser(string username, string password)
        {
            var db = new SQLiteConnection(dbPath);

            return db.Table<Users>().Where(i => i.Username == username && i.Password == password).FirstOrDefault();
        }
        
        // Get User By Id
        public Users GetUserById(int id)
        {
            var db = new SQLiteConnection(dbPath);

            return db.Table<Users>().Where(i => i.Id == id ).FirstOrDefault();
        }

        // List of Lectures ارجاع بيانات مقرر جميع سجلات الشعب للمقرر الواحد على شكل   
        public List<Users> GetAllUsers()
        {
            var db = new SQLiteConnection(dbPath);
            return db.Table<Users>().ToList();
        }


        [Table("Users")]
        public class Users
        {
            [PrimaryKey, AutoIncrement]   // , Column("_uid")
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
          //  public string Name { get; set; }
        }


    }
}