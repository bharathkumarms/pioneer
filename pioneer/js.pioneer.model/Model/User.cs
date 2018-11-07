using System;
using System.Collections.Generic;
using System.Text;

namespace js.pioneer.model
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Roleid { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
