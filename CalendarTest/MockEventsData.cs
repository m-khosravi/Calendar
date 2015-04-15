using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SavannahState.Calendar;

namespace CalendarTest
{
    class MockEventsData
    {

        private List<CalEvent> _events = new List<CalEvent>();
        
        public MockEventsData()
        {
            CalEvent calEvent = new CalEvent()
            {
                CalendarId = 1722,
                Title = "Second Session Registration - Summer Classes only",
                Description = "<p><strong><font size=\"5\">Note:</font></strong></p><p>It is requested that all students see their advisor or contact the departmental officeÂ to receive his/her PIN numbers.Â  If students are unable to register via the web, he/she can bring the advisement/planning sheet to the Office of the Registrar in Colston Administration Building for assistance.</p><p /><p>The staff in the office of Admissions will be in place to assist students with registration and direct students to the appropriate area.</p>",
                StartDate = new DateTime(2010, 6, 17),
                EndDate = new DateTime(2010, 6, 17),
                StartTime = "8:00 AM",
                EndTime = "5:00 PM",
                ContactName = "Office of the Registrar",
                ContactDetails = "aa@savannahstate.edu",
                EventType = "calendar",
                Status = "ended",
                Url = "http://www.yahoo.com"
            };
            _events.Add(calEvent);

            calEvent = new CalEvent()
            {
                CalendarId = 1723,
                Title = "Admissions Event",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque nibh velit, facilisis et auctor eu, pretium at purus. Sed faucibus finibus nisl, a consectetur lectus fringilla vitae. Ut rhoncus interdum ante, sit amet tincidunt felis. Aliquam erat volutpat. Curabitur nec ultricies libero. Fusce accumsan gravida maximus. Sed egestas, ligula eu pharetra iaculis, quam dolor iaculis orci, ut tincidunt metus leo vitae lectus. Integer sagittis sed libero sit amet porta. Duis commodo bibendum nunc. Fusce fringilla, purus vitae sodales sodales, tortor nisl maximus neque, nec malesuada justo dui vitae massa.",
                StartDate = new DateTime(2015, 1, 23),
                EndDate = new DateTime(2015, 1, 25),
                StartTime = "7:00 PM",
                EndTime = "9:00 PM",
                ContactName = "Shatealy Johnson",
                ContactDetails = "johnsons@savannahstate.edu",
                EventType = "calendar",
                Status = "ended",
                Url = ""
            };
            _events.Add(calEvent);

            calEvent = new CalEvent()
            {
                CalendarId = 1724,
                Title = "Grades Due",
                Description = "Suspendisse fermentum nibh ac cursus pretium. Vivamus neque urna, cursus vitae blandit ut, condimentum quis dui. Donec nec sollicitudin odio, id gravida lorem. Aliquam erat volutpat. Curabitur id turpis elementum libero volutpat lacinia. Vivamus fermentum nulla maximus ante volutpat, sit amet molestie tellus mollis. Duis pharetra tincidunt dolor quis congue. Nunc diam lacus, rhoncus in tristique ornare, mollis nec sem. Suspendisse dictum orci imperdiet ullamcorper pretium. Nulla sollicitudin libero massa, ut placerat justo laoreet pulvinar. Morbi luctus at massa vel sodales. Aenean bibendum lobortis mauris. Etiam at dignissim massa. Nulla sit amet condimentum sapien.",
                StartDate = new DateTime(2015, 4, 23),
                EndDate = new DateTime(2015, 4, 23),
                StartTime = "7:00 PM",
                EndTime = "9:00 PM",
                ContactName = "Shatealy Johnson",
                ContactDetails = "johnsons@savannahstate.edu",
                EventType = "calendar",
                Status = "live",
                Url = "http://www.google.com"
            };
            _events.Add(calEvent);

            calEvent = new CalEvent()
            {
                CalendarId = 1725,
                Title = "Commencement",
                Description = "In turpis purus, mattis pulvinar dictum ut, ornare eget augue. Curabitur lobortis sapien orci, non bibendum nunc ornare id. Nam eleifend sollicitudin ex, sit amet dignissim dui venenatis et. Quisque non ex et tellus iaculis rhoncus. Fusce convallis pellentesque tellus, id tempus risus tempor vel. Etiam varius, libero eu luctus cursus, risus tellus dictum leo, id ornare est velit sit amet tortor. Morbi tristique odio id eros convallis, sodales sodales sem auctor. Pellentesque condimentum in dolor quis bibendum. Sed egestas pulvinar aliquam. Maecenas mollis in neque vel dictum.",
                StartDate = new DateTime(2015, 8, 23),
                EndDate = new DateTime(2015, 8, 23),
                StartTime = "7:00 PM",
                EndTime = "9:00 PM",
                ContactName = "Shatealy Johnson",
                ContactDetails = "johnsons@savannahstate.edu",
                EventType = "calendar",
                Status = "live",
                Url = ""
            };
            _events.Add(calEvent);
        }

        public List<CalEvent> Load() {
            return _events;
        }

    }
}
