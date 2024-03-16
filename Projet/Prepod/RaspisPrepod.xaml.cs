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
    /// Логика взаимодействия для RaspisPrepod.xaml
    /// </summary>
    public partial class RaspisPrepod : Window
    {
        private int userId;
        public RaspisPrepod(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrepMon rw = new PrepMon(userId, 1);
            rw.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PrepMon rw = new PrepMon(userId, 2);
            rw.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            PrepMon rw = new PrepMon(userId, 3);
            rw.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            PrepMon rw = new PrepMon(userId, 4);
            rw.Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            PrepMon rw = new PrepMon(userId, 5);
            rw.Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            PrepMon rw = new PrepMon(userId, 6);
            rw.Show();
            this.Close();

        }
        // back
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            KabinetPrep rw = new KabinetPrep(userId);
            rw.Show();
            this.Close();

        }
    }
}
