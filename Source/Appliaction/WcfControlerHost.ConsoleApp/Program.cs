using HeBianGu.Base.WcfManager;
using HeBianGu.Base.WcfManager.Privider;
using HeBianGu.Domain.Service;
using HeBianGu.Domian.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfControlerHost.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            HostService.Instance.StartConsoleHost();
        }
    }
}
