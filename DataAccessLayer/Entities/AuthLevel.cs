using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class AuthLevel
    {
        public int AuthLevelId { get; set; }

        public string AuthLevelName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
