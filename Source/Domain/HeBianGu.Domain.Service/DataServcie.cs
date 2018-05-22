using HeBianGu.Base.WcfManager;
using HeBianGu.General.WcfLibrary.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Domain.Service
{
    public class DataServcie
    {
        public static DataServcie Instance = new DataServcie();

        SystemBrowserClient _systemBrowserClient = new SystemBrowserClient(WcfConfiger.Instance.IP, WcfConfiger.Instance.Port);

        public List<string> GetDrivers()
        {
            return _systemBrowserClient.GetDrivers();
        }

        public List<string> GetFolder(string parent)
        {
          return  _systemBrowserClient.GetFolder(parent);

        }

        public List<string> GetFiles(string folder)
        {
          return  _systemBrowserClient.GetFiles(folder);
        }

       
    }
}
