using CoreLogic.Data;
using CoreLogic.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLogic.Services
{
    public class BookEventService
    {


        private readonly MyContext _ctx;

		public BookEventService()
		{
			_ctx = new MyContext();
		}
		

		

		public List<BookEvent> GetAllEventDetails()
        {
			

			var bookevent =_ctx.BookEvents.ToList();
             return bookevent;
        }
        public void AddBookEvent(BookEvent bookEvent)
        {
           
            _ctx.BookEvents.Add(bookEvent);
            _ctx.SaveChanges();
        }
        public BookEvent GetBookEvent(int? id)
        {
            //one more method have to apply here by its own
            return _ctx.BookEvents.Include(c =>c.User).Single(p => p.Id == id);

        }

        public void DeleteBookEvent(BookEvent bookEvent)
        {
           

            _ctx.BookEvents.Remove(bookEvent);
            _ctx.SaveChanges();
        }

     

		public List<BookEvent> GetEventByUid(int userId)
		{
			return _ctx.BookEvents.Where(x => x.UserId == userId).ToList();
		}

		public void DeleteEvent(int eventId)
		{
			var eventToDelete = _ctx.BookEvents.FirstOrDefault(e => e.Id == eventId);

			if (eventToDelete != null)
			{
				_ctx.BookEvents.Remove(eventToDelete);
				_ctx.SaveChanges();
			}
		}
        public void UpdateEvent(BookEvent bookEvent)
        {
            if (bookEvent != null && _ctx.BookEvents.Any(bk => bk.Id == bookEvent.Id))
            {
                var existingEvent = _ctx.BookEvents.FirstOrDefault(e => e.Id == bookEvent.Id);
                existingEvent.NoofGuest = bookEvent.NoofGuest;
                existingEvent.EventType = bookEvent.EventType;
                existingEvent.Venue = bookEvent.Venue;
                existingEvent.BookingDate = bookEvent.BookingDate;
                _ctx.SaveChanges();
            }
        }


    }
}
