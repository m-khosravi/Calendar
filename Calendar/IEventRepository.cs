using System;
using System.Collections.Generic;
using System.Text;

namespace SavannahState.Calendar
{
    public interface IEventRepository
    {
        List<CalEvent> GetEvents();
        CalEvent GetEventById(String id);
        List<CalEvent> Search(String keyword);
        List<CalEvent> Search(String keyword, String category, DateTime dateStart, DateTime dateEnd, Boolean onlyActive, Int32 numberOfEvents);
    }
}
