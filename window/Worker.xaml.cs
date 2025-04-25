using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Intrinsics.X86;
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

namespace LykovFront.window
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Worker : Window
    {
        private readonly User user;
        private readonly HttpClient client;
        private readonly string baseUrl;

        public Worker(User user, HttpClient client, string baseUrl)
        {
            InitializeComponent();
            this.user = user;
            this.client = client;
            this.baseUrl = baseUrl;
        }

        private void ReaderButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new reader(user, client, baseUrl);
            window.Show();
            this.Close();

        }
    }
}
