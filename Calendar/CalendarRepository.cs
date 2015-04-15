using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannahState.Calendar
{
    public class CalendarRepository: IEventRepository
    {
        private const Int32 _defaultNumberOfEvents = 200;
        private List<CalEvent> _events;
        public CalendarRepository(List<CalEvent> events) {
            this._events = events;
        }

        public List<CalEvent> GetEvents()
        {
            return _events;
        }

        public CalEvent GetEventById(String id)
        {
            CalEvent calEvent;
            calEvent = _events.Find(e => e.CalendarId == Convert.ToInt32(id));
            if(calEvent == null){
                calEvent = new CalEvent();
            }
            return calEvent;
        }

        public List<CalEvent> Search(String keyword)
        {
            return Search(keyword, "", DateTime.MinValue, DateTime.MinValue, false, 0);
        }

        public List<CalEvent> Search(String keyword, String category, DateTime dateStart, DateTime dateEnd, Boolean onlyActive, Int32 numberOfEvents)
        {
            List<CalEvent> filteredEvents = _events;

            if (numberOfEvents == 0) {
                numberOfEvents = _defaultNumberOfEvents;
            }

            if (onlyActive)
            {
                filteredEvents = filteredEvents.FindAll(e => e.EndDate >= DateTime.Now).ToList();
            } else {
                if (dateStart != DateTime.MinValue && dateEnd != DateTime.MinValue)
                {
                    filteredEvents = filteredEvents.FindAll(e => e.EndDate < dateEnd && e.StartDate >= dateStart).ToList();
                }
            }

            if (!String.IsNullOrEmpty(keyword)) {
                filteredEvents = filteredEvents.FindAll(e => e.Title.Contains(keyword) || e.Description.Contains(keyword)).ToList();
            }

            if (!String.IsNullOrEmpty(category))
            {
                filteredEvents = filteredEvents.FindAll(e => e.Category == category).ToList();
            }

            var newlist = filteredEvents.OrderBy(e => e.StartDate).ToList();
            return newlist.Take(numberOfEvents).ToList();
        }
    }
}
