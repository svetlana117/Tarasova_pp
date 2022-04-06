using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarasova_41P_PP.Classes;

namespace Tarasova_41P_PP
{
    public partial class services
    {
        public string Row1 { get; set; }
        public string Row2 { get; set; }
        public string Row3 { get; set; }
        public string ImagePath { get; set; }
        public string Background { get; set; }
        public static List<services> GetServices()
        {
            List<services> ListServices = BaseConnect.BaseModel.services.ToList();
            foreach (services s in ListServices)
            {
                services servicesName = BaseConnect.BaseModel.services.FirstOrDefault(x=>x.ServicesCode == s.ServicesCode);
                s.Row1 = servicesName.ServicesName;
                services servicesDoctor = BaseConnect.BaseModel.services.FirstOrDefault(x => x.DoctorCode == s.doctors.DoctorCode);
                services servicesMedindustry = BaseConnect.BaseModel.services.FirstOrDefault(x => x.MedindustryCode == s.medIndustry.MedindustryCode);
                s.Row2 = servicesDoctor.doctors.DoctorName + " | " + s.medIndustry.MedindustryName;
                s.Row3 = servicesName.Price.ToString() +" руб.";
                s.ImagePath = @".." + s.Image;
                s.Background = "#E0FFFF";
            }
            return ListServices;
        }
    }
}
