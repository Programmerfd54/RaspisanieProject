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
    /// Логика взаимодействия для Kabinet.xaml
    /// </summary>
    public partial class Kabinet : Window
    {
        private int userId;

        user215_dbEntities2 db;
        public Kabinet(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaspisanieKoncretno rw = new RaspisanieKoncretno(userId);
            rw.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RaspisaniePrep rw = new RaspisaniePrep(userId);
            rw.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
