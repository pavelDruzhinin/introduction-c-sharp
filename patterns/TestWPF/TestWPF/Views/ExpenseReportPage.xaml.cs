using System.Windows.Controls;

namespace TestWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для ExpenseReportPage.xaml
    /// </summary>
    public partial class ExpenseReportPage : Page
    {
        public ExpenseReportPage()
        {
            InitializeComponent();
        }

        public ExpenseReportPage(object data)
            : this()
        {
            this.DataContext = data;
        }
    }
}
