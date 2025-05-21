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

namespace pr32.Pages.State.Elements
{
    /// <summary>
    /// Логика взаимодействия для State.xaml
    /// </summary>
    public partial class State : UserControl
    {
        private Classes.State state;

        // Ссылка на главную страницу
        private Pages.State.Main main;

        public State(Classes.State state, Pages.State.Main main)
        {
            InitializeComponent();

            // Сохраняем переданные данные
            this.state = state;
            this.main = main;

            // Заполняем поля данными из объекта
            tbName.Text = this.state.Name;
            tbSubname.Text = this.state.Subname;
            tbDescription.Text = this.state.Description;
        }

        // Обработчик изменения состояния
        private void EditState(object sender, RoutedEventArgs e)
        {
            // Открываем страницу редактирования с текущим состоянием
            MainWindow.mainWindow.OpenPage(new Pages.State.Add(state));
        }

        // Обработчик удаления состояния
        private void DeleteState(object sender, RoutedEventArgs e)
        {
            // Запрос подтверждения удаления
            if (MessageBox.Show($"Удалить состояние: {this.state.Name}?", "Уведомление",
                              MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Проверяем, есть ли связанные записи
                var recordsWithThisState = Classes.Record.AllRecords()
                    .Where(x => x.idState == state.Id)
                    .Count();

                if (recordsWithThisState > 0)
                {
                    MessageBox.Show($"Состояние {this.state.Name} невозможно удалить. " +
                                   "Сначала удалите связанные пластинки.", "Уведомление");
                }
                else
                {
                    // Удаляем состояние
                    this.state.Delete();

                    // Удаляем текущий элемент из интерфейса
                    main.stateParent.Children.Remove(this);

                    MessageBox.Show($"Состояние {this.state.Name} успешно удалено.", "Уведомление");
                }
            }
        }
    }
}
