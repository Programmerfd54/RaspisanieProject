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
    /// Логика взаимодействия для PrepMon.xaml
    /// </summary>
    public partial class PrepMon : Window
    {
        private int teacherId;
        private int userId;
        private int selectedDay;

        public PrepMon(int userId, int day)
        {
            InitializeComponent();
            this.userId = userId;
            this.selectedDay = day;
            Load();
            SetDayLabel();
            this.teacherId = GetTeacherId(userId);

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
            RaspisPrepod rw = new RaspisPrepod(userId);
            rw.Show();
            this.Close();
        }

        private int GetTeacherId(int userId)
        {
            var teacher = Helper.context.KUR_Prep.FirstOrDefault(p => p.id_Prep == userId);
            return teacher?.id_Prep ?? 0;
        }
        private void Load()
        {
            try
            {
                var scheduleData = new List<ScheduleViewModel>();

                using (var context = new user215_dbEntities2())
                {
                    var teacher = context.KUR_Prep.FirstOrDefault(p => p.id_Prep == userId);

                    if (teacher != null)
                    {
                        var teacherId = teacher.id_Prep;
                        var day = selectedDay; // Преобразуем selectedDay в DayOfWeek (0 - Воскресенье, 1 - Понедельник, и так далее)

                        // Получим расписание для конкретного дня недели (teacherId - идентификатор преподавателя, day - день недели)
                        var teacherSchedule = context.KUR_RASPISANIEe
                        .Where(item => item.id_prepod == teacherId && item.id_dnya == day)
                        .ToList();

                        // Для каждого элемента расписания, получим информацию о группе и сформируем ScheduleViewModel
                        scheduleData = teacherSchedule.Select(item => new ScheduleViewModel
                        {
                            Nachalo = item.Nachalo,
                            Para = item.Para,
                            Group = context.KUR_Gruppa.FirstOrDefault(g => g.id_Gruppa == item.id_groupp)?.naim,
                            Kabinet = item.Kabinet
                        }).ToList();
                    }
                }

                datas.ItemsSource = scheduleData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при загрузке расписания: " + ex.Message);
            }

        }
        public class ScheduleViewModel
        {
            public string Nachalo { get; set; }
            public string Para { get; set; }
            public string Group { get; set; }
            public string Kabinet { get; set; }
        }
    }
}
