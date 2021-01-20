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

namespace Bot.Views.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlInfo.xaml
    /// </summary>
    public partial class UserControlInfo : UserControl
    {
        public UserControlInfo()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Window parentwin = Window.GetWindow(this);
            parentwin.Close();
        }
    }
}
