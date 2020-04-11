using RCSE_Reloaded.API.Launches.Form;
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

namespace RCSE_Reloaded.ComfortUI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, ILaunchForm
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public bool CanExit => throw new NotImplementedException();

        public void DetectAndSaveFile()
        {
            throw new NotImplementedException();
        }

        public void ExceptionOccoured(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void LaunchWithArgs(string[] args)
        {
            throw new NotImplementedException();
        }

        public void SaveFile()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Editor.Height = this.Height - 43;
        }
    }
}
