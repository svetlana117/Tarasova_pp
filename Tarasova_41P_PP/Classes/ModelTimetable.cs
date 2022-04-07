using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarasova_41P_PP.Classes;

namespace Tarasova_41P_PP
{
    public partial class TimeTable
    {
        public static List<DateTime> GetTimeTable()
        {
            List<DateTime> Raspisanie = new List<DateTime>();
            foreach (TimeTable tt in BaseConnect.BaseModel.TimeTable.ToList())
            {
                Raspisanie.Add((DateTime)tt.Date);
            }
            return Raspisanie;
        }
    }
}
