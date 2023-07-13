using CoreLogic.Data;
using CoreLogic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services;

   public class UserService
    {

    MyContext ctx;

    //public string name;
    public UserService()
    {
        ctx = new MyContext();
    }
    public List<User> GetAll()
        {
            var users = ctx.Users.ToList();
            return users;
        }

    public User Get(string userName)
    {
        return ctx.Users.SingleOrDefault(x => x.UserName == userName);
    }

	public User GetUserById(int id)
	{
		return ctx.Users.SingleOrDefault(x => x.Id == id);
        
	}
  
    public void Register(User user)
    {
        ctx.Users.Add(user);
        ctx.SaveChanges();
    }

	public object Get(object userName)
	{
		throw new NotImplementedException();
	}

    public int GetUserId(string username)
    {
        var user = ctx.Users.SingleOrDefault(x => x.UserName == username);
        if (user != null)
        {
            return user.Id;
        }
        else
        {
            // Return a default or error value when the user is not found
            return -1;
        }
    }

}


