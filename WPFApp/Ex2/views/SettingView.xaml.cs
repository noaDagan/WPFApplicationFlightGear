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
using System.Windows.Shapes;
namespace Ex2
{
    /// <summary>
    /// Interaction logic for SettingView.xaml
    /// </summary>
    public partial class SettingView : UserControl
    {
        private viewModel.Setting_viewModel viewModels;
        public SettingView()
        {
            InitializeComponent();
            viewModels = new viewModel.Setting_viewModel(models.ApplicationSettingsModel.Instance);
            this.DataContext = viewModels;
            
        }
    }
}
