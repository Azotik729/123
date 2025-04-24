using Library.Models;
using Library.Request;
using LykovFront;
using LykovFront.window;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace front.window
{
    /// <summary>
    /// Логика взаимодействия для SearcReader.xaml
    /// </summary>
    public partial class SearcReader : Window
    {
        private readonly User user;
        private readonly HttpClient client;
        private readonly string baseUrl;
        public SearcReader(User user, HttpClient client, string baseUrl)
        {
            InitializeComponent();
            this.user = user;
            this.client = client;
            this.baseUrl = baseUrl;
            FillCombo();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new Worker(user,client,baseUrl);
            this.Close();
            window.Show();

        }
        private async void FillCombo()
        {
            const string baseUrl = "http://localhost:5292/api/User";
            HttpClient apiClient = new HttpClient();
            var response = await apiClient.GetAsync(baseUrl);

            var users = JsonSerializer.Deserialize<List<User>>(await response.Content.ReadAsStringAsync());
            First.ItemsSource = users;
        }
        private async void FillBook() 
        {
            const string baseUrl = "http://localhost:5292/api/Chapter";
            HttpClient apiClient = new HttpClient();
            var response = await apiClient.GetAsync(baseUrl);

            var users = JsonSerializer.Deserialize<List<Chapter>>(await response.Content.ReadAsStringAsync());
            Second.ItemsSource = users;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var user = First.SelectedItem as User;
            if (user != null)
            {
                
            }
        }

        private void Second_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cahpter = Second.SelectedItem as Chapter;
        }
    }
}
