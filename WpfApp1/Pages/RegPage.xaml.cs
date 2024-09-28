using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public User NewUser = new User();
        public RegPage()
        {
            InitializeComponent();

        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (string.IsNullOrEmpty(NameTextBox.Text))
                {
                    errors.AppendLine("Заполните имя");
                }
                if (RoleComboBox.SelectedItem == null)
                {
                    errors.AppendLine("Выберете роль");
                }
                if (string.IsNullOrEmpty(LoginTextBox.Text))
                {
                    errors.AppendLine("Заполните логин");
                }
                if (string.IsNullOrEmpty(PasswordBox.Password))
                {
                    errors.AppendLine("Заполните пароль");
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error); return;
                }
                NewUser.Name = NameTextBox.Text;
                NewUser.Login = LoginTextBox.Text;
                NewUser.Password = PasswordBox.Password;
                var SearchRole = (from Item in HomeEntities.GetContext().Role where Item.Name == RoleComboBox.Text select Item).FirstOrDefault();
                NewUser.RoleId = SearchRole.Id;
                HomeEntities.GetContext().User.Add(NewUser);
                HomeEntities.GetContext().SaveChanges();
                MessageBox.Show("Польззователь успешно зарегистрирован", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            } 
           
        }
    }
}
