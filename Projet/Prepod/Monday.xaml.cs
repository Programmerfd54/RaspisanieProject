using System;
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
using System.Windows.Shapes;

namespace Projet.Prepod
{
    /// <summary>
    /// Логика взаимодействия для Monday.xaml
    /// </summary>
    public partial class Monday : Window
    {
        private int userId;
        private int selectedDay;
        private int groupId;

        private List<ScheduleViewModel> scheduleData;
        public Monday(int userId, int day, List<ScheduleViewModel> scheduleData)
        {
            InitializeComponent();
            this.userId = userId;
            this.selectedDay = day;
            this.scheduleData = scheduleData;
            SetDayLabel();
            Load();
        }
        private void SetDayLabel()
        {
            string dayName = GetDayName(selectedDay);
            dAYNAME.Content = dayName; // Устанавливаем название дня в Label
        }
        private string GetDayName(int id_dnya)
        {
            string[] dayNames = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };

            if (id_dnya >= 1 && id_dnya <= 7)
            {
                return dayNames[id_dnya - 1];
            }

            return "Неверный день";
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaspisanieStud rw = new RaspisanieStud(userId);
            rw.Show();
            this.Close();
        }

        private void Load()
        {

            datas.ItemsSource = scheduleData;

        }
        public class ScheduleViewModel
        {
            public string Nachalo { get; set; }
            public string Para { get; set; }
            public string Predmet { get; set; }
            public string Prepodavatel { get; set; }
            public string Kabinet { get; set; }
        }
    }
}
