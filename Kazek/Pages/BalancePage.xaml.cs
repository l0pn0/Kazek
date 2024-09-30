using Kazek.DB;
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

namespace Kazek.Pages
{
    /// <summary>
    /// Логика взаимодействия для BalancePage.xaml
    /// </summary>
    public partial class BalancePage : Page
    {
        public BalancePage(ProfilePage profilePage)
        {
            InitializeComponent();

        }

        private void Depos(object sender, RoutedEventArgs e)
        {
            var TransTemp = new Transactions { id_user = Us.LoggedUser.id_user, amount = decimal.Parse(Amount.Text), time_stamp = DateTime.Now };
            if (!(long.Parse(NomKart.Text) > 1000000000000000) || !(long.Parse(NomKart.Text) < 10000000000000000) || !(NomKart.Text != null) || !(NomKart.Text != ""))
            {
                MessageBox.Show("Номер карты неверный!");
            }
            else if (!(int.Parse(cvvp.Text) > 99 || !(int.Parse(cvvp.Text) < 1000)))
            {
                MessageBox.Show("Неверный CVV!");
            } else if (FLname == null || FLname.Text == "")
            {
                MessageBox.Show("Введите Имя и Фамилию!");
            }
            else if(DateTime.Parse(Validity.Text) < DateTime.Today)
            {
                MessageBox.Show("Срок действии карты истек!");
            }
            else
            {
                MessageBox.Show($"Счет пополнен на {Amount.Text}");
                Us.LoggedUser.value += int.Parse(Amount.Text);
                Us.db.Transactions.Add(TransTemp);
                Us.db.SaveChanges();
                cvvp.Clear();
                FLname.Clear();
                Validity.Text = "";
                Amount.Clear();
                NomKart.Clear();
                NavigationService.Navigate(new MainPage());
            }
        }
    }
}
