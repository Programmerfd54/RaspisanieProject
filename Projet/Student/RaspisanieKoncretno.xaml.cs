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
    /// Логика взаимодействия для RaspisanieKoncretno.xaml
    /// </summary>
    public partial class RaspisanieKoncretno : Window
    {
        private int userId;

        public RaspisanieKoncretno(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Kabinet rw = new Kabinet(userId);
            rw.Show();
            this.Close();
        }

        private void Mon_Click(object sender, RoutedEventArgs e)
        {
            RaspisanieOSN rw = new RaspisanieOSN(userId, 1);
            rw.Show();
            this.Close();
        }

        private void Tue_Click(object sender, RoutedEventArgs e)
        {
            RaspisanieOSN rw = new RaspisanieOSN(userId, 2);
            rw.Show();
            this.Close();
        }

        private void Thur_Click(object sender, RoutedEventArgs e)
        {
            RaspisanieOSN rw = new RaspisanieOSN(userId, 3);
            rw.Show();
            this.Close();
        }

        private void Twen_Click(object sender, RoutedEventArgs e)
        {
            RaspisanieOSN rw = new RaspisanieOSN(userId, 4);
            rw.Show();
            this.Close();
        }

        private void Frid_Click(object sender, RoutedEventArgs e)
        {
            RaspisanieOSN rw = new RaspisanieOSN(userId, 5);
            rw.Show();
            this.Close();
        }

        private void Sut_Click(object sender, RoutedEventArgs e)
        {
            RaspisanieOSN rw = new RaspisanieOSN(userId, 6);
            rw.Show();
            this.Close();
        }
    }
}
