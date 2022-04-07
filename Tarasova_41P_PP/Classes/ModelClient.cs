using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarasova_41P_PP.Classes;

namespace Tarasova_41P_PP
{
    public partial class Client
    {
        public static List<DateTime> GetClient()
        {
            List<DateTime> Zanyato = new List<DateTime>();
            foreach (Client cl in BaseConnect.BaseModel.Client.ToList())
            {
                Zanyato.Add((DateTime)cl.Date);
            }
            return Zanyato;
        }
    }
}
