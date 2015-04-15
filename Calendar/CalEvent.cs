using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannahState.Calendar
{
    public class CalEvent
    {
        public Int32 CalendarId { get; set; }//cal_item_id
        public String Title { get; set; }//description - name
        public DateTime StartDate { get; set; }//starting_date
        public DateTime EndDate { get; set; }//ending_date
        public String StartTime { get; set; }//starting_time
        public String EndTime { get; set; }//ending_time
        public String Description { get; set; }//long_description
        public String CategoryId { get; set; }
        public String CategoryName { get; set; }
        public String ContactName { get; set; }//contact_name
        public String ContactDetails { get; set; }//contact_info
        public String AdditionalDetails { get; set; }

        public String EventType { get; set; }//DB or EventBrite
        public String Url { get; set; }

        public String Status { get; set; }//from EventBrite cancelled, live, started, ended, completed. From DB live or ended based on time

        public CalEvent()
        {
            Status = "not live";
        }
    }
}
