using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SavannahState.Calendar
{
    public class Utilities
    {
        public static DateTime FormatDate(String strDate, String strTime)
        {
            DateTime newDate = ConvertFromJulian(Convert.ToInt32(strDate));
            String[] timePieces = strTime.Split(':');
            String[] timeType;

            DateTime tempDate;

            if (timePieces.Length > 1)
            {
                timeType = timePieces[1].Split(' ');

                if (!String.IsNullOrEmpty(timeType[1]))
                {
                    if (timeType[1].ToUpper() == "AM")
                    {
                        tempDate = new DateTime(newDate.Year, newDate.Month, newDate.Day, Convert.ToInt32(timePieces[0]), Convert.ToInt32(timeType[0]), 0);
                    }
                    else
                    {
                        tempDate = new DateTime(newDate.Year, newDate.Month, newDate.Day, Convert.ToInt32(timePieces[0]) + 12, Convert.ToInt32(timeType[0]), 0);
                    }
                }
                else
                {
                    throw new Exception("error");
                }
            }
            else
            {
                return newDate;
            }
            return tempDate;
        }

        public static DateTime ConvertFromJulian(Int32 m_JulianDate)
        {
            long L = m_JulianDate + 68569;
            long N = (long)((4 * L) / 146097);
            L = L - ((long)((146097 * N + 3) / 4));
            long I = (long)((4000 * (L + 1) / 1461001));
            L = L - (long)((1461 * I) / 4) + 31;
            long J = (long)((80 * L) / 2447);
            int Day = (int)(L - (long)((2447 * J) / 80));
            L = (long)(J / 11);
            int Month = (int)(J + 2 - 12 * L);
            int Year = (int)(100 * (N - 49) + I + L);


            DateTime dt = new DateTime(Year, Month, Day);
            return dt;
        }

        public static double ConvertToJulian(DateTime date)
        {
            return date.ToOADate() + 2415018.5;
        }
    }
}
