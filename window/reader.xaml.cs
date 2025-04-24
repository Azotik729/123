using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace LykovFront.window
{
    /// <summary>
    /// Логика взаимодействия для reader.xaml
    /// </summary>
    public partial class SearchReader : Window
    {
        private readonly User user_;
        private readonly HttpClient client_;
        private readonly string baseUrl;

        public SearchReader(User user, HttpClient client, string baseUrl)
        {
            InitializeComponent();
            user_ = user;
            client_ = client;
            this.baseUrl = baseUrl;


        }
        private async void api()
        {
            var x = await FillDataGrid();
            grid.ItemsSource = x;
   

        }

        private async Task<List<Book>> FillDataGrid()
        {
            var response = await client_.GetAsync($"{baseUrl}/Book/IdUser");
            var content = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<Book>>(content);
            return books;
        }

        private async Task ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(searcTextBox.Text))
            {
                var book = await FillDataGrid();
            }
        }

        private async Task<Book?> FillDataGrid(User user)
        {
            var response = await client_.GetAsync($"{baseUrl}/Book/IdUser");
            var content = await response.Content.ReadAsStringAsync();
            var book = JsonSerializer.Deserialize<Book>(content);
            return book;
        }

        private void grid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonReader_Click(object sender, RoutedEventArgs e)
        {
            var wdn = new Card(user_,client_,baseUrl);
            wdn.Show();
            this.Close();
        }
    }
}
