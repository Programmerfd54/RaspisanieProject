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
    /// Логика взаимодействия для RaspisanieStud.xaml
    /// </summary>
    public partial class RaspisanieStud : Window
    {
        public string TeacherFullName { get; set; }

        private int teacherId;
        private int userId;
        user215_dbEntities2 db;
        public RaspisanieStud(int teacherId, int userId)
        {
            InitializeComponent();
            this.teacherId = teacherId;
            this.userId = userId;

            fioras.Content = "Расписание: " + TeacherFullName;

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaspisaniePrep rw = new RaspisaniePrep(userId);
            rw.Show();
            this.Close();
        }

        private void pon_Click(object sender, RoutedEventArgs e)
        {
            Monday rw = new Monday(userId, teacherId ,1);
            rw.Show();
            this.Close();
        }

        private void vtor_Click(object sender, RoutedEventArgs e)
        {
            Monday rw = new Monday(userId, teacherId, 2);
            rw.Show();
            this.Close();
        }

        private void sred_Click(object sender, RoutedEventArgs e)
        {
            Monday rw = new Monday(userId, teacherId, 3);
            rw.Show();
            this.Close();
        }

        private void chetv_Click(object sender, RoutedEventArgs e)
        {
            Monday rw = new Monday(userId, teacherId, 4);
            rw.Show();
            this.Close();
        }

        private void frid_Click(object sender, RoutedEventArgs e)
        {
            Monday rw = new Monday(userId, teacherId, 5);
            rw.Show();
            this.Close();
        }

        private void sub_Click(object sender, RoutedEventArgs e)
        {
            Monday rw = new Monday(userId,teacherId, 6);
            rw.Show();
            this.Close();

        }
    }
}
