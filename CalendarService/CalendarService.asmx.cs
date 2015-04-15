using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using SavannahState.Calendar;

namespace SavannahState
{
    [WebService(Namespace = "http://www.savannahstate.edu", Description = "Returns all social media posts.")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CalendarService : System.Web.Services.WebService
    {
        private IEventRepository _eventRepo;

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public CalEvent GetEventById(String id)
        {
            Context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            Context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            Context.Response.AddHeader("Access-Control-Max-Age", "1");
            if (!String.IsNullOrEmpty(id))
            {
                return _eventRepo.GetEventById(id);
            }
            else {
                return null;
            }

        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public List<CalEvent> Search(String keyword, String category, DateTime dateStart, DateTime dateEnd, Boolean onlyActive, Int32 numberOfEvents)
        {
            Context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            Context.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type");
            Context.Response.AddHeader("Access-Control-Max-Age", "1");
            return _eventRepo.Search(keyword,category,dateStart,dateEnd,onlyActive,numberOfEvents);
        }

        public CalendarService()
        {
            _eventRepo = new CalendarRepository(new EventsData().Load());
        }
    }
}
