using CoreLogic.Data;
using CoreLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services;

    public class AdminService
    {
        private readonly MyContext _ctx;

        public AdminService()
        {
            _ctx = new MyContext();
        }

    public Admin Get(string userName)
    {
        return _ctx.Admin.SingleOrDefault(x => x.UserName == userName);
    }
    public List<BookEvent> GetAllEventDetails()
    {


        var bookevent = _ctx.BookEvents.ToList();
        return bookevent;
    }
}

