using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SavannahState.Calendar;
using System.Collections.Generic;

namespace CalendarTest
{
    [TestClass]
    public class CalendarRepositoryTest
    {
        [TestMethod]
        public void GetEventById_valid()
        {
            IEventRepository repo = new CalendarRepository(new MockEventsData().Load());
            CalEvent actual = repo.GetEventById("1724");
            CalEvent expected = new CalEvent()
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

            Assert.AreEqual(expected.CalendarId, actual.CalendarId, "CalendarId not equal");
            Assert.AreEqual(expected.Title, actual.Title, "Title not equal");
            Assert.AreEqual(expected.StartDate, actual.StartDate, "StartDate not equal");
            Assert.AreEqual(expected.EndDate, actual.EndDate, "EndDate not equal");
            Assert.AreEqual(expected.ContactName, actual.ContactName, "ContactName not equal");
            Assert.AreEqual(expected.EventType, actual.EventType, "EventType not equal");
            Assert.AreEqual(expected.Status, actual.Status, "Status not equal");
        }

        [TestMethod]
        public void GetEventById_invalid()
        {
            IEventRepository repo = new CalendarRepository(new MockEventsData().Load());
            CalEvent actual = repo.GetEventById("172444444");
            CalEvent expected = new CalEvent()
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
            Assert.AreNotEqual(expected.CalendarId, actual.CalendarId, "CalendarId is equal");
        }

        [TestMethod]
        public void SearchByKeyword_returns_1_result()
        {
            IEventRepository repo = new CalendarRepository(new MockEventsData().Load());
            List<CalEvent> actual = repo.Search("Grades Due");
            CalEvent calEvent = new CalEvent()
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

            List<CalEvent> expected = new List<CalEvent>();
            expected.Add(calEvent);

            Assert.AreEqual(expected[0].CalendarId, actual[0].CalendarId, "CalendarId not equal");
            Assert.AreEqual(expected[0].Title, actual[0].Title, "Title not equal");
            Assert.AreEqual(expected[0].StartDate, actual[0].StartDate, "StartDate not equal");
            Assert.AreEqual(expected[0].EndDate, actual[0].EndDate, "EndDate not equal");
            Assert.AreEqual(expected[0].ContactName, actual[0].ContactName, "ContactName not equal");
            Assert.AreEqual(expected[0].EventType, actual[0].EventType, "EventType not equal");
            Assert.AreEqual(expected[0].Status, actual[0].Status, "Status not equal");
        }

        [TestMethod]
        public void SearchByKeyword_returns_no_results()
        {
            IEventRepository repo = new CalendarRepository(new MockEventsData().Load());
            List<CalEvent> actual = repo.Search("Nothing");
            Int32 expected = 0;
            Assert.AreEqual(expected, actual.Count, "Search result found");
        }

        [TestMethod]
        public void SearchRange_returns_3_results()
        {
            IEventRepository repo = new CalendarRepository(new MockEventsData().Load());
            List<CalEvent> actual = repo.Search("", "", DateTime.Now.AddYears(-1), DateTime.Now.AddYears(1), false, 0);
            List<CalEvent> expected = new MockEventsData().Load();

            Assert.AreEqual(expected[1].CalendarId, actual[0].CalendarId, "CalendarId not equal in first");
            Assert.AreEqual(expected[1].Title, actual[0].Title, "Title not equal in first");
            Assert.AreEqual(expected[1].StartDate, actual[0].StartDate, "StartDate not equal in first");
            Assert.AreEqual(expected[1].EndDate, actual[0].EndDate, "EndDate not equal in first");
            Assert.AreEqual(expected[1].ContactName, actual[0].ContactName, "ContactName not equal in first");
            Assert.AreEqual(expected[1].EventType, actual[0].EventType, "EventType not equal in first");
            Assert.AreEqual(expected[1].Status, actual[0].Status, "Status not equal in first");

            Assert.AreEqual(expected[2].CalendarId, actual[1].CalendarId, "CalendarId not equal in second");
            Assert.AreEqual(expected[2].Title, actual[1].Title, "Title not equal in second");
            Assert.AreEqual(expected[2].StartDate, actual[1].StartDate, "StartDate not equal in second");
            Assert.AreEqual(expected[2].EndDate, actual[1].EndDate, "EndDate not equal in second");
            Assert.AreEqual(expected[2].ContactName, actual[1].ContactName, "ContactName not equal in second");
            Assert.AreEqual(expected[2].EventType, actual[1].EventType, "EventType not equal in second");
            Assert.AreEqual(expected[2].Status, actual[1].Status, "Status not equal in second");

            Assert.AreEqual(expected[3].CalendarId, actual[2].CalendarId, "CalendarId not equal in third");
            Assert.AreEqual(expected[3].Title, actual[2].Title, "Title not equal in third");
            Assert.AreEqual(expected[3].StartDate, actual[2].StartDate, "StartDate not equal in third");
            Assert.AreEqual(expected[3].EndDate, actual[2].EndDate, "EndDate not equal in third");
            Assert.AreEqual(expected[3].ContactName, actual[2].ContactName, "ContactName not equal in third");
            Assert.AreEqual(expected[3].EventType, actual[2].EventType, "EventType not equal in third");
            Assert.AreEqual(expected[3].Status, actual[2].Status, "Status not equal in third");
        }

        [TestMethod]
        public void SearchRange_returns_no_results()
        {
            IEventRepository repo = new CalendarRepository(new MockEventsData().Load());
            List<CalEvent> actual = repo.Search("", "", DateTime.Now.AddYears(-10), DateTime.Now.AddYears(-9), false, 0);
            Int32 expected = 0;
            Assert.AreEqual(expected, actual.Count, "Search result found");
        }

        [TestMethod]
        public void SearchOnlyActive_returns_3_results()
        {
            IEventRepository repo = new CalendarRepository(new MockEventsData().Load());
            List<CalEvent> actual = repo.Search("", "", DateTime.Now.AddYears(-1), DateTime.Now.AddYears(1), true, 0);
            List<CalEvent> expected = new MockEventsData().Load();

            Assert.AreEqual(expected[2].CalendarId, actual[0].CalendarId, "CalendarId not equal in first");
            Assert.AreEqual(expected[2].Title, actual[0].Title, "Title not equal in first");
            Assert.AreEqual(expected[2].StartDate, actual[0].StartDate, "StartDate not equal in first");
            Assert.AreEqual(expected[2].EndDate, actual[0].EndDate, "EndDate not equal in first");
            Assert.AreEqual(expected[2].ContactName, actual[0].ContactName, "ContactName not equal in first");
            Assert.AreEqual(expected[2].EventType, actual[0].EventType, "EventType not equal in first");
            Assert.AreEqual(expected[2].Status, actual[0].Status, "Status not equal in first");

            Assert.AreEqual(expected[3].CalendarId, actual[1].CalendarId, "CalendarId not equal in second");
            Assert.AreEqual(expected[3].Title, actual[1].Title, "Title not equal in second");
            Assert.AreEqual(expected[3].StartDate, actual[1].StartDate, "StartDate not equal in second");
            Assert.AreEqual(expected[3].EndDate, actual[1].EndDate, "EndDate not equal in second");
            Assert.AreEqual(expected[3].ContactName, actual[1].ContactName, "ContactName not equal in second");
            Assert.AreEqual(expected[3].EventType, actual[1].EventType, "EventType not equal in second");
            Assert.AreEqual(expected[3].Status, actual[1].Status, "Status not equal in second");
        }

        [TestMethod]
        public void Search_returns_1_result()
        {
            IEventRepository repo = new CalendarRepository(new MockEventsData().Load());
            List<CalEvent> actual = repo.Search("Grades Due", "", DateTime.Now.AddYears(-1), DateTime.Now.AddYears(1), true, 0);
            CalEvent calEvent = new CalEvent()
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

            List<CalEvent> expected = new List<CalEvent>();
            expected.Add(calEvent);

            Assert.AreEqual(expected[0].CalendarId, actual[0].CalendarId, "CalendarId not equal");
            Assert.AreEqual(expected[0].Title, actual[0].Title, "Title not equal");
            Assert.AreEqual(expected[0].StartDate, actual[0].StartDate, "StartDate not equal");
            Assert.AreEqual(expected[0].EndDate, actual[0].EndDate, "EndDate not equal");
            Assert.AreEqual(expected[0].ContactName, actual[0].ContactName, "ContactName not equal");
            Assert.AreEqual(expected[0].EventType, actual[0].EventType, "EventType not equal");
            Assert.AreEqual(expected[0].Status, actual[0].Status, "Status not equal");
        }

        [TestMethod]
        public void Search_returns_no_results()
        {
            IEventRepository repo = new CalendarRepository(new MockEventsData().Load());
            List<CalEvent> actual = repo.Search("Nothing", "", DateTime.Now.AddYears(-1), DateTime.Now.AddYears(1), true, 0);
            Int32 expected = 0;
            Assert.AreEqual(expected, actual.Count, "Search result found");
        }

        [TestMethod]
        public void SearchDB_returns_1_result()
        {
            IEventRepository repo = new CalendarRepository(new EventsData().Load());
            List<CalEvent> actual = repo.Search("","",DateTime.MinValue,DateTime.MinValue,true,20);
            CalEvent calEvent = new CalEvent()
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

            List<CalEvent> expected = new List<CalEvent>();
            expected.Add(calEvent);

            Assert.AreEqual(expected[0].CalendarId, actual[0].CalendarId, "CalendarId not equal");
            Assert.AreEqual(expected[0].Title, actual[0].Title, "Title not equal");
            Assert.AreEqual(expected[0].StartDate, actual[0].StartDate, "StartDate not equal");
            Assert.AreEqual(expected[0].EndDate, actual[0].EndDate, "EndDate not equal");
            Assert.AreEqual(expected[0].ContactName, actual[0].ContactName, "ContactName not equal");
            Assert.AreEqual(expected[0].EventType, actual[0].EventType, "EventType not equal");
            Assert.AreEqual(expected[0].Status, actual[0].Status, "Status not equal");
        }

    }
}
