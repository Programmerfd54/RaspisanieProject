using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Window
    {
        user215_dbEntities2 db;
        public Reg()
        {
            InitializeComponent();
            db = new user215_dbEntities2();
            Load();
        }
        public Reg(KUR_Stud user)
        {
            InitializeComponent();
            Load();
            DataContext = user;
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {

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

        private int selectedGroupId;

        private void group_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*var selectedGroup = (KUR_Gruppa)group.SelectedItem; // Предполагается, что Group - класс для группы

            if (selectedGroup != null)
            {
                selectedGroupId = selectedGroup.id_Gruppa; // Сохраните ID группы
            }*/
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Fioo.Text == "" || logi.Text == "" || pass.Text == "" || repass.Text == "")
            {
                MessageBox.Show("Пустые данные", "Ошибка!");
                return;
            }
            if (db.KUR_Stud.Select(item => item.logi).Contains(logi.Text))
            {
                MessageBox.Show("Такой логин существует в системе");
                return;
            }
            else if (pass.Text != repass.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }
            var selectedOtdelenie = (KUR_Otdelenie)otd.SelectedItem;
            var selectedGroup = (KUR_Gruppa)group.SelectedItem;
            if (selectedOtdelenie == null || selectedGroup == null)
            {
                MessageBox.Show("Пожалуйста, выберите отделение и группу.", "Ошибка!");
                return;
            }
            KUR_Stud newStudent = new KUR_Stud
            {
                FIO = Fioo.Text,
                logi = logi.Text,
                pass = pass.Text,
                id_otdelenie = selectedOtdelenie.id_otdelenie,
                id_group = selectedGroup.id_Gruppa
            };

            // Добавление нового студента в базу данных
            db.KUR_Stud.Add(newStudent);

            try
            {
                db.SaveChanges(); // Сохранение изменений в базе данных

                MessageBox.Show("Регистрация успешно завершена!");
                Auth auth = new Auth();
                this.Close();
                auth.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка при регистрации: " + ex.Message, "Ошибка");
            }
        }
        private void Load()
        {
            otd.ItemsSource = Helper.context.KUR_Otdelenie.ToList();
            group.ItemsSource = Helper.context.KUR_Gruppa.ToList();

        }
    }
}
