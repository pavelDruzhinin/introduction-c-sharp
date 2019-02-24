using System.Windows;
using System.Windows.Controls;

namespace TestWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Page
    {
        public ExpenseItHome()
        {
            InitializeComponent();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {
            var expenseReportPage = new ExpenseReportPage(this.peopleListBox.SelectedItem);

            if (this.NavigationService != null)
                this.NavigationService.Navigate(expenseReportPage);
        }
    }
}
