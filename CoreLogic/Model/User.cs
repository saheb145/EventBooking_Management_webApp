using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Model;

    public class User
    {
     //public User() => BookEvents = new HashSet<BookEvent>();
        public User()
        { 
           BookEvents = new HashSet<BookEvent>();
        }
		
    public int Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    //public HashSet<BookEvent> BookEvents { get; }

    public ICollection<BookEvent> BookEvents { get; set; }
    }

