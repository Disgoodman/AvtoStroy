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

            DB.employessTableAdapter.Fill(DB.dataSet.Employess);

            DB.postAdapter.Fill(DB.dataSet.posts);

            postsCB.ItemsSource = DB.dataSet.posts.DefaultView;
            postsCB.DisplayMemberPath = "name";
            postsCB.SelectedValuePath = "id";
            postsCB.SelectedIndex = 0;

            dg.ItemsSource = DB.dataSet.Employess.DefaultView;
            dg.SelectedValuePath = "id";
        }

        void UpdateTable()
        {
            int sel = dg.SelectedIndex;
            DB.employessTableAdapter.Fill(DB.dataSet.Employess);
            if (dg.Items.Count > sel)
                dg.SelectedIndex = sel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            bool pathronymicExist = !String.IsNullOrWhiteSpace(middlenameTB.Text);
            int id = (int)DB.employeeAdapter.InsertEmployee(
                surnameTB.Text.Trim(),
                nameTB.Text.Trim(),
                pathronymicExist ? middlenameTB.Text.Trim() : null,
                idPasTB.Text,
                numberPasTB.Text
                );
            UpdateTable();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            bool pathronymicExist = !String.IsNullOrWhiteSpace(middlenameTB.Text);
            DataRowView selectedRow = (DataRowView)dg.SelectedItem;
            int employeeId = (int)selectedRow.Row[DB.dataSet.Employess.id_employeeColumn.Ordinal];

            int sr = DB.employeeAdapter.UpdateEmployee(
                surnameTB.Text.Trim(),
                nameTB.Text.Trim(),
                pathronymicExist ? middlenameTB.Text.Trim() : null,

                idPasTB.Text,
                numberPasTB.Text,
                employeeId
                );
            UpdateTable();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)dg.SelectedItem;
            int employeeId = (int)selectedRow.Row[DB.dataSet.Employess.id_employeeColumn.Ordinal];
            int id = (int)DB.employeeAdapter.DeleteEmployee(employeeId);
            UpdateTable();
        }

        private void data_SelectedCellChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataRowView selecetedRow = dg.SelectedItem;
            if (selecetedRow == null) return;

            surnameTB.Text = selecetedRow.Row[DB.dataSet.Employess.last_nameColumn.Ordinal].ToString();
            nameTB.Text = selecetedRow.Row[DB.dataSet.Employess.first_nameColumn.Ordinal].ToString();
            middlenameTB.Text = selecetedRow.Row[DB.dataSet.Employess.middle_nameColumn.Ordinal].ToString();
            idPasTB.Text = selecetedRow.Row[DB.dataSet.Employess.series_passportColumn.Ordinal].ToString();
            numberPasTB.Text = selecetedRow.Row[DB.dataSet.Employess.number_passportColumn.Ordinal].ToString();
            postsCB.SelectedValue = selecetedRow.Row[DB.dataSet.Employess.id_postColumn.Ordinal];
        }


    }
}
