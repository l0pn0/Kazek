using Kazek.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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

namespace Kazek.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage(LoginPage loginPage)
        {
            InitializeComponent();
        }

        public bool IsLoginUnique(string log)
        {
            using (var context = new Kazino339Entities4())
            {
                bool exists = context.User.Any(u => u.username == log);
                return !exists;
            }
        }

        private void RegCl(object sender, RoutedEventArgs e)
        {
            string login = Login.Text;
            string email = Email.Text;
            string pass = Password.Password;
            string reenPass = reenPassword.Password;
            if (login == null || email == null || pass == null || pass == "" || reenPass == null || reenPass =="")
            {
                MessageBox.Show("Заполните все данные!");
            }
            else if (pass != reenPass)
            {
                MessageBox.Show("Неправильно введен пароль или его повтор!");
            }
            else if (IsLoginUnique(login))
            {
                var regTemp = new User { username = login, email = email, password = pass, value = 0, date_create = DateTime.Today };
                Us.db.User.Add(regTemp);
                Us.db.SaveChanges();
                Login.Clear();
                Email.Clear();
                Password.Clear();
                reenPassword.Clear();
                NavigationService.GoBack();
            } else
            {
                MessageBox.Show("Логин уже занят, попробуйте другой!");
            }
        }
    }
}
