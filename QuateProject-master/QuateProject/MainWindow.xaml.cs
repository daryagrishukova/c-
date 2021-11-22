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
using System.Net;
using Newtonsoft.Json;

namespace QuateProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClass db = new DataClass();
        public MainWindow()
        {
            InitializeComponent();
            db.CreateStrConnection();
        }

        private void btnGetQuate_Click(object sender, RoutedEventArgs e)
        {
            // Объявляем экземпляр класса Цитат
            Quote qoute = new Quote();

            // Отправляем запрос для получения случайной цитаты
            // И сохраняем полученный результат в наш ранее созданный объект
            qoute = qoute.GetQuote();

            // Выводим поле текст цитаты в label на форме
            lblQuate.Text = qoute.quoteText;
            lblAutor.Text = qoute.quoteAuthor;
            if (String.IsNullOrEmpty(lblAutor.Text))
                lblAutor.Text = "Нет автора";
            lblLink.Text = qoute.quoteLink;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Best best = new Best();
            best.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            db.AddQuote(lblQuate.Text, lblAutor.Text, lblLink.Text);
        }
    }
    
}
