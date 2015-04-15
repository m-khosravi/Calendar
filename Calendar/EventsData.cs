using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SavannahState.Calendar
{
    public class EventsData
    {
        private static List<CalEvent> _events;
        public EventsData(){
            if(_events == null){
                _events = new List<CalEvent>();
            }
        }
        public List<CalEvent> Load()
        {
            SqlConnection cnSQL = new DBConnection().GetConnection();
            SqlDataReader searchResults;
            SqlCommand selectCMD;
            cnSQL.Open();

            StringBuilder calSQL = new StringBuilder("SELECT cal_item_id,calendar_id,description,starting_date,ending_date,starting_time,ending_time,contact_name,contact_info,long_description FROM [Calendar].[dbo].[calitem] WHERE approved = 1");

            selectCMD = new SqlCommand(calSQL.ToString(), cnSQL);

            try
            {
                searchResults = selectCMD.ExecuteReader();
                if (searchResults.HasRows)
                {
                    while (searchResults.Read())
                    {
                        CalEvent calEvent = new CalEvent();
                        String strStartDate = "";
                        String strEndDate = "";
                        calEvent.CalendarId = (Int32)searchResults["cal_item_id"];

                        calEvent.Category = searchResults["calendar_id"].ToString();
                        calEvent.Title = searchResults["description"].ToString();
                        strStartDate = searchResults["starting_date"].ToString();
                        strEndDate = searchResults["ending_date"].ToString();
                        calEvent.StartTime = searchResults["starting_time"].ToString();
                        calEvent.EndTime = searchResults["ending_time"].ToString();
                        calEvent.Description = searchResults["long_description"].ToString();
                        calEvent.ContactName = searchResults["contact_name"].ToString();
                        calEvent.ContactDetails = searchResults["contact_info"].ToString();
                        calEvent.EventType = "calendar";

                        try
                        {
                            calEvent.StartDate = Utilities.FormatDate(strStartDate, calEvent.StartTime);
                            calEvent.EndDate = Utilities.FormatDate(strEndDate, calEvent.EndTime);
                        }
                        catch
                        {

                        }

                        if (calEvent.StartDate != null && calEvent.EndDate != null)
                        {
                            if (calEvent.StartDate <= DateTime.Now && calEvent.EndDate > DateTime.Now)
                            {
                                calEvent.Status = "started";
                            }
                            else
                            {
                                if (calEvent.EndDate < DateTime.Now)
                                {
                                    calEvent.Status = "ended";
                                }
                                if (calEvent.StartDate > DateTime.Now)
                                {
                                    calEvent.Status = "live";
                                }
                            }
                        }
                        _events.Add(calEvent);
                    }
                }
                searchResults.Close();
            }
            catch (Exception ex)
            {

            }
            selectCMD.Dispose();
            cnSQL.Close();
            cnSQL.Dispose();
            return _events;
        }
    }
}
