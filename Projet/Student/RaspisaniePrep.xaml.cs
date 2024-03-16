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
    public partial class RaspisaniePrep : Window
    {
        private int userId;
        user215_dbEntities2 db;
        public RaspisaniePrep(int userId)
        {
            InitializeComponent();
            db = new user215_dbEntities2();
            this.userId = userId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Kabinet rw = new Kabinet(userId);
            rw.Show();
            this.Close();
        }
        private int FindTeacherIdByFullName(string fullName)
        {
            using (var context = new user215_dbEntities2()) // Замените на ваш контекст базы данных
            {
                // Поиск преподавателя по ФИО (предполагается, что у вас есть поле FIO для хранения ФИО преподавателя)
                var teacher = context.KUR_Prep.FirstOrDefault(t => t.FIO == fullName);

                if (teacher != null)
                {
                    return teacher.id_Prep; // Предполагается, что в вашей модели данных есть поле Id, содержащее идентификатор преподавателя
                }
            }

            return 0; // Преподаватель не найден, вернем 0
        }
        private void FindTeacherButton_Click(object sender, RoutedEventArgs e)
        {

            string TeacherFullName = teacherNameTextBox.Text; // Получите ФИО преподавателя из текстового поля
            int teacherId = FindTeacherIdByFullName(TeacherFullName);
            MessageBox.Show("Препод: " + TeacherFullName); // Отладочное сообщение

            if (teacherId != 0)
            {
                // Преподаватель найден, выполните переход на другую форму (например, RaspisanieStud)

                RaspisanieStud raspisanieStudForm = new RaspisanieStud(teacherId, userId);
                raspisanieStudForm.TeacherFullName = TeacherFullName; // Установите значение TeacherFullName
                raspisanieStudForm.Show();
                this.Close();

            }
            else
            {
               
                MessageBox.Show("Преподаватель не найден!");
            }
        }
    }
}
