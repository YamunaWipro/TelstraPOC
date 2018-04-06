using App5.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App5
{
    public class DatabaseHelper
    {
        string path;
        SQLiteConnection database;
        static object locker = new object();
        private LoginModel loginModel = new LoginModel();
        public SQLite.SQLiteConnection GetConnection()
        {
            SQLiteConnection sqlitConnection;
            var sqliteFilename = "UserDatabase.db3";
            string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(folder, sqliteFilename);
            sqlitConnection = new SQLite.SQLiteConnection(path);
            return sqlitConnection;
        }
        public DatabaseHelper()
        {
            database = GetConnection();
            // create the tables  
            database.CreateTable<User>();
            InsertData();
        }

        public void InsertData()
        {
            // User user1 = new User { UserName = "Johny", Password = "jo1234" };
            User []users = new User [5];
            users[0] = new User { UserName = "Johny", Password = "jo1234" };
            users[1] = new User { UserName = "Tommy", Password = "to1234" };
            users[2] = new User { UserName = "Ranny", Password = "ra1234" };
            users[3] = new User { UserName = "Rhony", Password = "rh1234" };
            users[4] = new User { UserName = "Joy", Password = "jo1234" };

            //User user1 = new User { UserName = "Rockie", Password = "ro123" };
             
            for(int i=0;i<5;i++)
            {
                lock (locker)
                {
                    //Update Item  
                    database.Insert(users[i]);
                }

            }
           
        }
        public IEnumerable<User> GetUsers()
        {
            lock (locker)
            {
                return (from i in database.Table<User>() select i).ToList();
            }
        }
        public string GetUser(string userName)
        {
            lock (locker)
            {
               User u=database.Table<User>().FirstOrDefault(x => x.UserName == userName);
                return u.UserName;
            }
        }
        public string GetPassword(string userName)
        {
            lock (locker)
            {
                User u = database.Table<User>().FirstOrDefault(x => x.UserName == userName);
                if (u == null)
                    return "";
                return u.Password;
            }
        }
        public void DeleteTable()
        {
            database.DropTable<User>();
        }
    } }
       