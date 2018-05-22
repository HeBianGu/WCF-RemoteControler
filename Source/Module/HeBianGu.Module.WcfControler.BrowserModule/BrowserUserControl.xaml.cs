using HeBianGu.Domain.Service;
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

namespace HeBianGu.Module.WcfControler.BrowserModule
{
    /// <summary>
    /// BrowserUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class BrowserUserControl : UserControl
    {
        public BrowserUserControl()
        {
            InitializeComponent();

            this.Loaded +=(s, e) =>
                                {

                                   var collection=  DataServcie.Instance.GetDrivers();

                                    foreach (var item in collection)
                                    {
                                        this.list.Items.Add(item);
                                    }

                                    var collection1 = DataServcie.Instance.GetFiles(@"F:\GitHub\WpfProgram\Product\Dll");

                                    foreach (var item in collection1)
                                    {
                                        this.list.Items.Add(item);
                                    }
                                };


        }
    }
}
