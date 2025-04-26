using Library.Models;
using Library.Request;
using System;
using System.Buffers.Text;
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
    /// Логика взаимодействия для UpdateBook.xaml
    /// </summary>
    public partial class UpdateBook : Window
    {
        private readonly User user_;
        private readonly HttpClient client_;
        private readonly string baseUrl;
        public UpdateBook(User user, HttpClient client, string baseUrl)
        {
            InitializeComponent();
            user_ = user;
            client_ = client;
            this.baseUrl = baseUrl;
        }
 
        // public  async void addbook( BookRequest book)
        //{
        //    book.Name = NameBookTextBox.Text;
        //    book.idWriter = Convert.ToInt32( WriterBookTextBook.Text) ;
        //    book.dataPost = DataPostBookTextBox.Text ;
        //    book.price = Convert.ToDecimal (PriceBookTextBox.Text) ;
        //    //NameBookTextBox.Text = book.Name;
        //    //WriterBookTextBook.Text = Convert.ToString( book.IdWriter);
        //    //DataPostBookTextBox.Text = book.DataPost;
        //    //PriceBookTextBox.Text = Convert.ToString( book.Price);
        //    return ;
           
        //}

        private async void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            var book = new BookRequest(NameBookTextBox.Text,Convert.ToInt32 (WriterBookTextBook.Text),DataPostBookTextBox.Text, Convert.ToDecimal(PriceBookTextBox.Text));
         
            var userJson = JsonSerializer.Serialize(book);
            var content = new StringContent(userJson, Encoding.UTF8, "application/json");
            var response = await client_.PostAsync($"{baseUrl}/Book", content);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Книга добавлена!");
            }
        }
    }
    }

