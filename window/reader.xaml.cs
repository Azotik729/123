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
using static System.Reflection.Metadata.BlobBuilder;

namespace LykovFront.window
{
    /// <summary>
    /// Логика взаимодействия для reader.xaml
    /// </summary>
    public partial class reader : Window
    {
        private readonly User user_;
        private readonly HttpClient client_;
        private readonly string baseUrl;

        public reader(User user, HttpClient client, string baseUrl)
        {
            InitializeComponent();
            user_ = user;
            client_ = client;
            this.baseUrl = baseUrl;
            api();
            FillDataGrid();
            FillWriter();
            FillChapter();
            
        }
        private async void api()
        {
            var x = await FillDataGrid();
            grid.ItemsSource = x;
   

        }

        public async Task<List<Book>> FillDataGrid()
        {
            var response = await client_.GetAsync($"{baseUrl}/Book");
            var content = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<Book>>(content);
            grid.ItemsSource = books;
            return books;
        }

        private async void ButtonSearch_Click (object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(searcTextBox.Text))
            {
                var book = await FillDataGrid();
                var search = book.Where(p => p.name == searcTextBox.Text).ToList();
                grid.ItemsSource = search;
            }
        }

        private async Task<Book?> FillDataGrid(Book book)
        {
            var response = await client_.GetAsync($"{baseUrl}/Book");
            var content = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<Book>(content);
            return books;
        }

        private void ButtonReader_Click(object sender, RoutedEventArgs e)
        {
            var wdn = new Card(user_,client_,baseUrl);
            wdn.Show();
            this.Close();
        }

        private async void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public async Task<List<Writer>> FillWriter()
        {
            var response = await client_.GetAsync($"{baseUrl}/Writer");
            var content = await response.Content.ReadAsStringAsync();
            var writers = JsonSerializer.Deserialize<List<Writer>>(content);
            WriterComboBox.ItemsSource = writers;
            return  writers ;
        }
        private async void WriterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WriterComboBox.SelectedItem == null) return;
            var books = await FillWriter();
            grid.ItemsSource = books.Where(p => p.name == WriterComboBox.SelectedItem.ToString()).ToList();
        }

        private void Buttonexit_Click(object sender, RoutedEventArgs e)
        {
            var vdn = new Worker(user_,client_,baseUrl);
            vdn.Show();
            this.Close();

        }
        public async Task<List<Chapter>> FillChapter()
        {
            var response = await client_.GetAsync($"{baseUrl}/chapter");
            var content = await response.Content.ReadAsStringAsync();
            var chapters = JsonSerializer.Deserialize<List<Chapter>>(content);
            ChapterComboBox.ItemsSource = chapters;
            return chapters;
        }

        private async void ChapterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChapterComboBox.SelectedItem == null) return;
            var chapters = await FillChapter();
            grid.ItemsSource = chapters.Where(p => p.name == ChapterComboBox.SelectedItem.ToString()).ToList();
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var vdn = new UpdateBook(user_,client_,baseUrl);
            vdn.Show();
            this.Close();
        }
    }
    }

