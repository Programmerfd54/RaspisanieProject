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
    /// Логика взаимодействия для RaspisanieStud.xaml
    /// </summary>
    public partial class RaspisanieStud : Window
    {
        private int userId;
        private user215_dbEntities2 db;
        private int selectedDay = 0;


        public RaspisanieStud(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            db = new user215_dbEntities2();
            Load();
        }

        private void otd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (otd.SelectedItem != null)
            {
                var selectedOtdelenie = (KUR_Otdelenie)otd.SelectedItem;
                int selectedOtdelenieId = selectedOtdelenie.id_otdelenie;

                // Фильтрация групп по выбранному отделению
                group.ItemsSource = db.KUR_Gruppa.Where(g => g.id_otdel == selectedOtdelenieId).ToList();
            }
        }



        private void Load()
        {
            otd.ItemsSource = Helper.context.KUR_Otdelenie.ToList();
            group.ItemsSource = Helper.context.KUR_Gruppa.ToList();

        }


        private void LoadSchedule()
        {
            if (otd.SelectedItem != null && group.SelectedItem != null && selectedDay != 0)
            {
                var selectedGroup = (KUR_Gruppa)group.SelectedItem;
                int selectedGroupId = selectedGroup.id_Gruppa;

                var scheduleData = db.KUR_RASPISANIEe
                    .Where(item => item.id_dnya == selectedDay && item.id_groupp == selectedGroupId)
                    .ToList();

                if (scheduleData.Any())
                {
                    var scheduleDataViewModel = ConvertToMondayViewModel(scheduleData);
                    Monday rw = new Monday(userId, selectedDay, scheduleDataViewModel);
                    rw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Нет расписания для выбранной группы и дня.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите отделение, группу и день.");
            }
        }

        private List<Monday.ScheduleViewModel> ConvertToMondayViewModel(List<KUR_RASPISANIEe> scheduleData)
        {
            return scheduleData.Select(item => new Monday.ScheduleViewModel
            {
                Nachalo = item.Nachalo,
                Para = item.Para,
                Predmet = GetPredmetName(item.id_predmet),
                Prepodavatel = GetPrepodavatelName(item.id_prepod),
                Kabinet = item.Kabinet
            }).ToList();
        }

        private string GetPredmetName(int predmetId)
        {
            var predmet = Helper.context.KUR_pred.FirstOrDefault(p => p.id_predmet == predmetId);
            return predmet?.naim ?? "Не найден";
        }

        private string GetPrepodavatelName(int prepodavatelId)
        {
            var prepodavatel = Helper.context.KUR_Prep.FirstOrDefault(p => p.id_Prep == prepodavatelId);
            return prepodavatel?.FIO ?? "Не найден";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KabinetPrep rw = new KabinetPrep(userId);
            rw.Show();
            this.Close();
        }

        private void mon_Click(object sender, RoutedEventArgs e)
        {
            selectedDay = 1;
            LoadSchedule();
        }

        private void tue_Click(object sender, RoutedEventArgs e)
        {
            selectedDay = 2;
            LoadSchedule();
        }

        private void sred_Click(object sender, RoutedEventArgs e)
        {
            selectedDay = 3;
            LoadSchedule();
        }

        private void chetv_Click(object sender, RoutedEventArgs e)
        {
            selectedDay = 4;
            LoadSchedule();
        }

        private void frid_Click(object sender, RoutedEventArgs e)
        {
            selectedDay = 5;
            LoadSchedule();
        }

        private void sub_Click(object sender, RoutedEventArgs e)
        {
            selectedDay = 6;
            LoadSchedule();
        }
    }
