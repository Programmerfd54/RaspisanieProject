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
    /// Логика взаимодействия для KabinetPrep.xaml
    /// </summary>
    public partial class KabinetPrep : Window
    {
       
        private int userId;

        public KabinetPrep(int userId)
        {
            InitializeComponent();
            this.userId = userId;


        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaspisPrepod rw = new RaspisPrepod(userId);
            rw.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RaspisanieStud rw = new RaspisanieStud(userId);
            rw.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
