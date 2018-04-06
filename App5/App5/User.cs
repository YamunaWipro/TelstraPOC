using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace App5
{
    public class User
    {
       
       
        public string UserName { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return string.Format("[User: UserName={0},Password={1}]",UserName,Password);
        }
    }
}