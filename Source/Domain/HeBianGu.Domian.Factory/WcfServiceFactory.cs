using HeBianGu.General.WcfLibrary.Interface;
using HeBianGu.General.WcfLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Domian.Factory
{
    public class WcfServiceFactory
    {
        private WcfServiceFactory()
        {

        }

        public static WcfServiceFactory Instance = new WcfServiceFactory();

        /// <summary> 构建自动流服务 </summary>
        public Dictionary<Type, Type> CreateWorkScreamService()
        {
            Dictionary<Type, Type> serviceTypes = new Dictionary<Type, Type>();

            serviceTypes.Add(typeof(IFileTransferService), typeof(FileTransferService));

            //serviceTypes.Add(typeof(IWorkScreamService), typeof(WorkScreamService));

            return serviceTypes;
        }

        /// <summary> 构建远程控制器服务 </summary>
        public Dictionary<Type, Type> CreateMonitorService()
        {
            Dictionary<Type, Type> serviceTypes = new Dictionary<Type, Type>();

            serviceTypes.Add(typeof(IExcuteService), typeof(ExcuteService));

            serviceTypes.Add(typeof(IImageSenderService), typeof(ImageSenderService));

            serviceTypes.Add(typeof(IStreamPrivider), typeof(StreamPrivider));

            return serviceTypes;
        }


    }
}
