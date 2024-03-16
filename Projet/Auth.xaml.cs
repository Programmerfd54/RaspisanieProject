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
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        user215_dbEntities2 db;
        public Auth()
        {
            InitializeComponent();
            db = new user215_dbEntities2();
        }

        private void Avtor_Click(object sender, RoutedEventArgs e)
        {
            var user = db.KUR_Stud.FirstOrDefault(item => item.logi == login.Text && item.pass == pass.Text);

            var prep = db.KUR_Prep.FirstOrDefault(item => item.logi == login.Text && item.pass == pass.Text);


            if (login.Text == "" && pass.Text == "")
            {
                MessageBox.Show("Пустые поля", "Ошибка!");
                return;
            }
            else if (user != null)
            {

                int userId = user.id_stud;

                Kabinet physicalWindow = new Kabinet(userId);
                physicalWindow.Show();

            }
            else if (prep != null)
            {

                int userId = prep.id_Prep; // Используйте prep для получения id преподавателя
                KabinetPrep physicalWindow = new KabinetPrep(userId);
                physicalWindow.Show();
                this.Close();

            }


            else
            {
                MessageBox.Show("Ошибка логина/пароля");
                return;
            }
        }
    }
}
