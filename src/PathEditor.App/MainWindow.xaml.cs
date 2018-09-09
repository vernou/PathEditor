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
using PathEditor.Core;
using PathEditor.Core.EnvironmentVariablePath;
using PathEditor.Core.Paper;

namespace PathEditor.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel(new EnvironmentVariablePathInMemory());
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var paper = new WihoutFakeBreakLine(new AutoBreakLine(new TextOf(((TextBox)sender).Text, ((TextBox)sender).SelectionStart)));
            ((TextBox) sender).Text = paper.Text;
            ((TextBox) sender).SelectionStart = paper.Cursor;
        }
    }
}