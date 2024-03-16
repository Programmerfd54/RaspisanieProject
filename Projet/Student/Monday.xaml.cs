using Kursach.Student;
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

namespace Projet
{
    /// <summary>
    /// Логика взаимодействия для Monday.xaml
    /// </summary>
    public partial class Monday : Window
    {

        private int teacherId;
        private int userId; 
        private int selectedDay;
        user215_dbEntities2 db;
       
        public Monday( int userId, int teacherId, int day)
        {
            InitializeComponent();
            this.teacherId = teacherId;
            this.userId = userId;
            this.selectedDay = day;
            SetDayLabel();
            Load();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaspisanieStud rw = new RaspisanieStud(userId, teacherId);   
            rw.Show();
            this.Close();
        }

        private void SetDayLabel()
        {
            string dayName = GetDayName(selectedDay);
            nameday.Content = dayName; // Устанавливаем название дня в Label
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


        private int GetStudentGroupId(int teacherId)
        {
            var prep = Helper.context.KUR_Prep.FirstOrDefault(s => s.id_Prep == teacherId);

            if (prep != null)
            {
                return prep.id_Prep; // Если преподаватель найден, верните его id_Prep
            }

            return 0;
        }


        private void Load()
        {
            var studentGroupId = GetStudentGroupId(teacherId);

            var scheduleData = Helper.context.KUR_RASPISANIEe
          .Where(item => item.id_dnya == selectedDay && item.id_prepod == teacherId)
          .ToList();

            var groupIds = scheduleData.Select(item => item.id_groupp);

            var groups = Helper.context.KUR_Gruppa.Where(g => groupIds.Contains(g.id_Gruppa)).ToList();

            var scheduleViewModels = scheduleData.Select(item => new ScheduleViewModel
            {
                Nachalo = item.Nachalo,
                Para = item.Para,
                Group = groups.FirstOrDefault(g => g.id_Gruppa == item.id_groupp)?.naim,
                Kabinet = item.Kabinet
            }).ToList();

            datas.ItemsSource = scheduleViewModels;

        }
        public class ScheduleViewModel
        {
            public string Nachalo { get; set; }
            public string Para { get; set; }
            public string Group { get; set; }
            public string Kabinet { get; set; }
        }

        private void datas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
