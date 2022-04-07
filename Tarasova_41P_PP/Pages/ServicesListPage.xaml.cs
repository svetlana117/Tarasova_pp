using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tarasova_41P_PP.Classes;
using Tarasova_41P_PP.Pages;

namespace Tarasova_41P_PP.Pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesListPage.xaml
    /// </summary>
    public partial class ServicesListPage : Page
    {
        List<services> ListServices = services.GetServices();

        public ServicesListPage()
        {
            InitializeComponent();
            ListBoxServices.ItemsSource = ListServices;

            List<medIndustry> listMedindustry = BaseConnect.BaseModel.medIndustry.ToList();
            List<string> listMedind = new List<string>();
            foreach (medIndustry medind in listMedindustry)
            {
                listMedind.Add(medind.MedindustryName);
            }
            ComboBoxFilter.ItemsSource = listMedind;
        }
        
        private void TextFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
        private void Filter()
        {
            ListServices = services.GetServices();
            if (TextFilter.Text != null)
            {
                ListServices = BaseConnect.BaseModel.services.Where(x => x.ServicesName.Contains(TextFilter.Text) || x.doctors.DoctorName.Contains(TextFilter.Text)).ToList();
            }
            

            try
            {
                if (ComboBoxSort != null)
                    switch (ComboBoxSort.SelectedIndex)
                    {
                        case 0:
                            {
                                ListServices = ListServices.OrderBy(x => x.Price).ToList();
                                ListServices.Reverse();
                                break;
                            }
                        case 1:
                            {
                                ListServices = ListServices.OrderBy(x => x.Price).ToList();

                                break;
                            }
                        case 2:
                            {
                                ListServices = ListServices.OrderBy(x => x.medIndustry.MedindustryName).ToList();
                                ListServices.Reverse();
                                break;
                            }
                        case 3:
                            {
                                ListServices = ListServices.OrderBy(x => x.medIndustry.MedindustryName).ToList();
                                break;
                            }
                    }
            }
            catch (Exception e)
            { }

            try
            {
                if (ComboBoxFilter!=null)
                {
                    if (ComboBoxFilter.SelectedValue != null)
                    {
                        ListServices = ListServices.Where(x => x.medIndustry.MedindustryName.Contains(ComboBoxFilter.SelectedValue.ToString())).ToList();

                    }
                }
            }
            catch (Exception e)
            { }

            ListBoxServices.ItemsSource = ListServices;
        }

        private void ComboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void ComboBoxFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnRecord_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            services s = BaseConnect.BaseModel.services.FirstOrDefault(x=>x.ServicesCode.ToString() == btn.Uid);
            RecordClient rc = new RecordClient(s);
            if (rc.ShowDialog() == true)
            {
                
            }
            //Filter();
        }
    }
}
