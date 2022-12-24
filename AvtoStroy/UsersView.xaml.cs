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
using AvtoStroy.DataSet1TableAdapters;
using System.Data;

namespace AvtoStroy
{
    /// <summary>
    /// Логика взаимодействия для UsersView.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {

        void ErrorMassegeBox(string msg) => MessageBox.Show(msg, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);


        public UsersView()
        {
            InitializeComponent();
            
        }

        
        
    }
}
