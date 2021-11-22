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

namespace QuateProject
{
    /// <summary>
    /// Логика взаимодействия для Best.xaml
    /// </summary>
    public partial class Best : Window
    {
        DataClass db = new DataClass();
        public Best()
        {
            InitializeComponent();
            db.CreateStrConnection();
            dgQuote.ItemsSource = db.ReadQuote();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
