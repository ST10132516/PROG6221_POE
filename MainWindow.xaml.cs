using System;
using System.Windows;

namespace SaneleGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateRecipe_Click(object sender, RoutedEventArgs e)
        {
            CreateRecipeWindow createRecipeWindow = new CreateRecipeWindow();
            createRecipeWindow.ShowDialog();
        }

        private void SelectRecipe_Click(object sender, RoutedEventArgs e)
        {
            SelectRecipeWindow selectRecipeWindow = new SelectRecipeWindow();
            selectRecipeWindow.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
