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
    /// Логика взаимодействия для RaspisanieOSN.xaml
    /// </summary>
    public partial class RaspisanieOSN : Window
    {
        private int userId;
        private int selectedDay;

        public RaspisanieOSN(int userId, int day)
        {
            InitializeComponent();
            this.userId = userId;
            this.selectedDay = day; // Сохраняем выбранный день
            SetDayLabel();
            Load();
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


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaspisanieKoncretno rw = new RaspisanieKoncretno(userId);
            rw.Show();
            this.Close();
        }

        private int GetStudentGroupId(int studentId)
        {
            // Получите студента по его идентификатору studentId
            var student = Helper.context.KUR_Stud.FirstOrDefault(s => s.id_stud == studentId);

            if (student != null)
            {
                // Если студент найден, верните id_group этого студента
                return student.id_group ?? 0; // Используйте 0 или другое значение по умолчанию, если id_group может быть null
            }

            // Верните значение по умолчанию, если студент не найден
            return 0; // Используйте 0 или другое значение по умолчанию
        }





        private void Load()
        {
            int studentGroupId = GetStudentGroupId(userId);


            var scheduleData = Helper.context.KUR_RASPISANIEe
     .Where(item => item.id_dnya == selectedDay && item.id_groupp == studentGroupId)
     .ToList();

            var prepIds = scheduleData.Select(item => item.id_prepod);
            var predmetIds = scheduleData.Select(item => item.id_predmet);

            var preps = Helper.context.KUR_Prep.Where(p => prepIds.Contains(p.id_Prep)).ToList();
            var predmets = Helper.context.KUR_pred.Where(pred => predmetIds.Contains(pred.id_predmet)).ToList();

            var scheduleViewModels = scheduleData.Select(item => new ScheduleViewModel
            {
                Nachalo = item.Nachalo,
                Para = item.Para,
                Predmet = predmets.FirstOrDefault(p => p.id_predmet == item.id_predmet)?.naim,
                Prepodavatel = preps.FirstOrDefault(p => p.id_Prep == item.id_prepod)?.FIO,
                Kabinet = item.Kabinet
            }).ToList();

            datas.ItemsSource = scheduleViewModels;

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
