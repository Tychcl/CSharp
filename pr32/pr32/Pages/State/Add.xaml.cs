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

namespace pr32.Pages.State
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        private Classes.State changeState;

        public Add(Classes.State state = null)
        {
            InitializeComponent();

            // Если передан объект для редактирования
            if (state != null)
            {
                this.changeState = state;
                this.tbName.Text = state.Name;
                this.tbSubname.Text = state.Subname;
                this.tbDescription.Text = state.Description;
                addBtn.Content = "Изменить";
            }
        }

        // Обработчик добавления/изменения состояния
        private void AddState(object sender, RoutedEventArgs e)
        {
            // Проверка обязательных полей
            if (string.IsNullOrEmpty(tbName.Text))
            {
                MessageBox.Show("Пожалуйста, укажите наименование состояния.", "Предупреждение");
                return;
            }

            if (string.IsNullOrEmpty(tbSubname.Text))
            {
                MessageBox.Show("Пожалуйста, укажите сокращённое наименование состояния.", "Предупреждение");
                return;
            }

            try
            {
                if (this.changeState == null)
                {
                    // Создание нового состояния
                    var newState = new Classes.State()
                    {
                        Name = tbName.Text,
                        Subname = tbSubname.Text,
                        Description = tbDescription.Text
                    };

                    newState.Save();
                    MessageBox.Show($"Состояние {newState.Name} успешно добавлено.", "Уведомление");
                    MainWindow.mainWindow.OpenPage(new Pages.State.Add(newState));
                }
                else
                {
                    // Редактирование существующего состояния
                    changeState.Name = tbName.Text;
                    changeState.Subname = tbSubname.Text;
                    changeState.Description = tbDescription.Text;

                    changeState.Save(true);
                    MessageBox.Show($"Состояние {changeState.Name} успешно изменено.", "Уведомление");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка");
            }
        }
    }
}
