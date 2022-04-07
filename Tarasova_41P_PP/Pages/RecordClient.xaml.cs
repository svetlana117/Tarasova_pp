using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для RecordClient.xaml
    /// </summary>
    public partial class RecordClient : Window
    {
        services srv;
        Client client;

        List<string> raspisanie = new List<string>();
        List<string> zanyto = new List<string>();
        List<string[]> FreeDateTime = new List<string[]>();

        List<DateTime> RaspisanieDate = new List<DateTime>();

        public RecordClient(services s)
        {
            InitializeComponent();
            client = new Client();
            client.ServicesCode = s.ServicesCode;
            DatePicker.DisplayDateStart = DateTime.Now;
            DatePicker.DisplayDateEnd = DateTime.Now.AddDays(30);
            for (int i = 0; i < 31; i++)
            {
                DatePicker.BlackoutDates.Add(new CalendarDateRange(DateTime.Parse(DateTime.Now.AddDays(i).ToShortDateString()), DateTime.Parse(DateTime.Now.AddDays(i).ToShortDateString())));
            }
            foreach (string str in raspisanie)
            {
                string[] a = new string[2];
                a = str.Split(' ');
                if (!zanyto.Contains(str))
                {
                    FreeDateTime.Add(str.Split(' '));
                    DatePicker.BlackoutDates.Remove(DatePicker.BlackoutDates.FirstOrDefault(x => x.Start == DateTime.Parse(a[0] + " 00:00:00")));
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextBoxName.Text != "" && TextBoxSurname.Text != "" && TextBoxPatronymic.Text != "" && TextBoxPassport.Text != "" && TextBoxPolicy.Text != "" && TextBoxSnils.Text != "" && TextBoxEmail.Text != "" && DatePicker.SelectedDate.ToString() != "" && TextBoxEmail.Text != "")
                {
                    client.Name = TextBoxName.Text;
                    client.Surname = TextBoxSurname.Text;
                    client.Patronymic = TextBoxPatronymic.Text;
                    client.Passport = TextBoxPassport.Text;
                    client.Policy = TextBoxPolicy.Text;
                    client.Snils = TextBoxSnils.Text;
                    client.Email = TextBoxEmail.Text;
                    client.Date = DatePicker.SelectedDate;
                    BaseConnect.BaseModel.Client.Add(client);
                    BaseConnect.BaseModel.SaveChanges();
                    MessageBox.Show("Запись прошла успешно");
                }
                else
                {
                    MessageBox.Show("Поля не могут быть пустыми!");
                }
            }
            catch { }
        }
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (string[] a in FreeDateTime)
            {
                ComboBox.Items.Add(a[1]);
            }
        }
    }
}
