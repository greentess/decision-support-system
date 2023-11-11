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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (log.Text == "admin" && pas.Password == "admin")
            {
                Window11 win1 = new Window11();
                this.Close();
                win1.Show();
                System.Windows.Application.Current.MainWindow = win1;
                System.Windows.Application.Current.MainWindow.Width = 689;
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
                pas.Password = "";
                log.Text = "";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Данная программа позволяет оптимально распределить ограниченные бюджетные средства так, чтобы получить наибольшую выгоду от покупки различной рекламы. Для этого пользователю необходимо указать выделенный на маркетинговую деятельность бюджет и заполнить таблицу всех вариантов рекламы с названиями, стоимостью  и средними охватами. Далее следует нажать на кнопку «Рассчитать». Сформированная рядом таблица будет содержать такой набор рекламы, покупка которой принесет наибольшие охваты для ювелирного магазина при минимальных затратах бюджетных средств.", "Справка о программе");
        }

    }
}
