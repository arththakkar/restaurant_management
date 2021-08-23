using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.models
{
    class User
    {
        private string first_name;
        private string last_name;
        private string mobile_number;

        public User(string first_name, string last_name, string mobile_number)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.mobile_number = mobile_number;
        }

        public string FirstName
        {
            get { return this.first_name; }
            set { this.first_name = value; }
        }

        public string LastName
        {
            get { return this.last_name; }
            set { this.last_name = value; }
        }

        public string MobileNumber
        {
            get { return this.mobile_number; }
            set { this.mobile_number = value; }
        }
    }
}
