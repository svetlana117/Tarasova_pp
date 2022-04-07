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
        public static List<DateTime> GetTimeTable(int i)
        {
            List<DateTime> Raspisanie = new List<DateTime>();
            foreach (TimeTable tt in BaseConnect.BaseModel.TimeTable.Where(x=>x.Status==0 && x.ServicesCode==i).ToList())
            {
                Raspisanie.Add((DateTime)tt.Date);
            }
            return Raspisanie;
        }
    }
}
