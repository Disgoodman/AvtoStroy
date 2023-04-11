using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AvtoStroy
{
    public static class GridDef
    {
        public static string GetRowDefinitions(DependencyObject obj) => (string)obj.GetValue(RowDefinitionsProperty);
        public static void SetRowDefinitions(DependencyObject obj, string value) => obj.SetValue(RowDefinitionsProperty, value);

        public static readonly DependencyProperty RowDefinitionsProperty =
            DependencyProperty.RegisterAttached("RowDefinitions", typeof(string), typeof(GridDef), new PropertyMetadata("", OnRowChanged));


        public static string GetColumnDefinitions(DependencyObject obj) => (string)obj.GetValue(ColumnDefinitionsProperty);
        public static void SetColumnDefinitions(DependencyObject obj, string value) => obj.SetValue(ColumnDefinitionsProperty, value);

        public static readonly DependencyProperty ColumnDefinitionsProperty =
            DependencyProperty.RegisterAttached("ColumnDefinitions", typeof(string), typeof(GridDef), new PropertyMetadata("", OnColChanged));


        private static readonly GridLengthConverter gridLengthConverter = new();

        private static void OnColChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Grid grid)
            {
                grid.ColumnDefinitions.Clear();

                if (e.NewValue is String args)
                {
                    var definitions = args.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    var colDefinitions = definitions.Select(row => new ColumnDefinition
                    {
                        Width = (GridLength)gridLengthConverter.ConvertFromString(row)
                    });

                    foreach (var def in colDefinitions)
                        grid.ColumnDefinitions.Add(def);
                }
            }
        }

        private static void OnRowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Grid grid)
            {
                grid.RowDefinitions.Clear();
                if (e.NewValue is String args)
                {
                    var definitions = args.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    var rowDefinitions = definitions.Select(row => new RowDefinition
                    {
                        Height = (GridLength)gridLengthConverter.ConvertFromString(row)
                    });

                    foreach (var def in rowDefinitions)
                        grid.RowDefinitions.Add(def);
                }
            }
        }
    }
}
