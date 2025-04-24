using LykovFront.window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
using System.Text.Json;
using Library.Models;

namespace LykovFront
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private async void button_Click_1 (object sender, RoutedEventArgs e)
        {
            const string baseUrl = "http://localhost:5292/api";
            HttpClient apiClient = new HttpClient();
            var user = new AuthorizationeRequest { Login = loginTextBox.Text, Password = passwordTextbox.Text };
            var json = System.Text.Json.JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Get, $"{baseUrl}/User")
            {
                Content = content
            };
            var response = await apiClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responsebody = await response.Content.ReadAsStringAsync();
                var users = JsonSerializer.Deserialize<List<User>>(responsebody);
                var user1 = users.FirstOrDefault(u => u.login== user.Login && u.password == user.Password) ;
                if (user1 is null) 
                {
                    MessageBox.Show("не верный логин или пороль");
                return;
                }
                if (user1.role == 1)
                {
                    var wnd = new Admin();
                    wnd.Show();
                    this.Hide();
                }
                else if (user1.role == 2)
                {
                    var wnd = new Worker(user1, apiClient, baseUrl);
                    wnd.Show();
                    this.Hide();
                }
                else if (user1.role == 3)
                {
                    var window = new SearchReader(user1, apiClient, baseUrl);
                    window.Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Неправильная роль");
                }
            }
            else
            {
                MessageBox.Show("api ответ не поступил");
            }
        }
    }
}
