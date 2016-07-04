using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication2.Windows
{
    /// <summary>
    /// Interaction logic for RoutedEvent.xaml
    /// </summary>
    public partial class RoutedEventWindow : Window
    {
        public RoutedEventWindow()
        {
            InitializeComponent();
        }

        private void btnB_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click B panel button!", 
                "System Information", 
                MessageBoxButton.OK, 
                MessageBoxImage.Information);

            MessageBox.Show(string.Format("send type is {0}", sender.GetType().Name));

            Button sourceButton = (Button)sender;
            MessageBox.Show(string.Format("source button is {0}", sourceButton.Name),
                "System Information",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void spG_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click G panel button!",
                "System Information",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            MessageBox.Show(string.Format("send type is {0}", sender.GetType().Name));
            MessageBox.Show(string.Format("e.source type is {0}", e.Source.GetType().Name));
        }

        private void btnC1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click C panel button C1!",
                "System Information",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void btnC2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click C panel button C2!",
                "System Information",
                MessageBoxButton.OK,
                MessageBoxImage.Information);

            e.Handled = true;
        }

        private void spC_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click C panel button!",
                "System Information",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
