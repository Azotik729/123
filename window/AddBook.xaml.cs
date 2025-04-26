using Library.Models;
using Library.Request;
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
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {

        private readonly User user_;
        private readonly HttpClient client_;
        private readonly string baseUrl;
        public AddBook(User user, HttpClient client, string baseUrl)
        {
            InitializeComponent();
            user_ = user;
            client_ = client;
            this.baseUrl = baseUrl;
        }
        //private async void api(BookRequest book)
        //{
        //    var x = await FillDataGrid();
        //    NameBookTextBox.Text = book.Name;
        //    WriterBookTextBook.Text = Convert.ToString(book.idWriter);
        //    DataPostBookTextBox.Text = book.dataPost;
        //    PriceBookTextBox.Text = Convert.ToString(book.price);
        //}
        public async Task<List<Book>> FillDataGrid(BookRequest book)
        {
            var response = await client_.GetAsync($"{baseUrl}/Book");
            var content = await response.Content.ReadAsStringAsync();
            var books = JsonSerializer.Deserialize<List<Book>>(content);
            NameBookTextBox.Text = book.Name;
            WriterBookTextBook.Text = Convert.ToString(book.idWriter);
            DataPostBookTextBox.Text = book.dataPost;
            PriceBookTextBox.Text = Convert.ToString(book.price);
            return books;
        }

        private async void AddBookButton_Click(object sender, RoutedEventArgs e) 
        {
            var book = new BookRequest(NameBookTextBox.Text, Convert.ToInt32(WriterBookTextBook.Text), DataPostBookTextBox.Text, Convert.ToDecimal(PriceBookTextBox.Text));

            var userJson = JsonSerializer.Serialize(book);
            var content = new StringContent(userJson, Encoding.UTF8, "application/json");
            var response = await client_.PostAsync($"{baseUrl}/Book", content);
            if (response.IsSuccessStatusCode)
            { 
                MessageBox.Show("Книга обновлена!");
            }

        }
    }
 }
