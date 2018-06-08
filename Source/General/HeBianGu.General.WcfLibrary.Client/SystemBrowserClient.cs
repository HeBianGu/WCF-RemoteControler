#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 长虹智慧健康有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2018/5/22 17:42:10 
 * 文件名：Class1 
 * 说明：
 * 
 * 
 * 修改者：           时间：               
 * 修改说明：
 * ========================================================================
*/
#endregion
using HeBianGu.Base.WcfManager;
using HeBianGu.General.WcfLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfLibrary.Client
{
    public class SystemBrowserClient : WcfClientBase
    {
        public SystemBrowserClient(string ip, string port)
        {
            this.IP = ip;
            this.Port = port;
        }

        /// <summary> 客户端的配置 </summary>
        public WcfConfiger WcfConfiger = WcfConfiger.Instance;

        private WSHttpBinding _wsHttpBinding;
        /// <summary> 说明 </summary>
        public WSHttpBinding WSHttpBinding
        {
            get
            {
                if (_wsHttpBinding == null)
                {
                    _wsHttpBinding = new WSHttpBinding();
                    _wsHttpBinding.MaxBufferPoolSize = int.MaxValue;
                    _wsHttpBinding.MaxReceivedMessageSize = int.MaxValue;
                    _wsHttpBinding.ReceiveTimeout = new TimeSpan(1, 0, 0);
                    _wsHttpBinding.Security = new System.ServiceModel.WSHttpSecurity();
                    _wsHttpBinding.Security.Mode = SecurityMode.None;
                }
                return _wsHttpBinding;
            }
        }

        //private BasicHttpBinding _wsHttpBinding;
        ///// <summary> 说明 </summary>
        //public BasicHttpBinding WSHttpBinding
        //{
        //    get
        //    {
        //        if (_wsHttpBinding == null)
        //        {
        //            _wsHttpBinding = new BasicHttpBinding();
        //            _wsHttpBinding.MaxBufferPoolSize = int.MaxValue;
        //            _wsHttpBinding.MaxReceivedMessageSize = int.MaxValue;
        //            _wsHttpBinding.ReceiveTimeout = new TimeSpan(1, 0, 0);
        //            _wsHttpBinding.Security = new System.ServiceModel.BasicHttpSecurity();
        //            _wsHttpBinding.Security.Mode = BasicHttpSecurityMode.None;
        //        }
        //        return _wsHttpBinding;
        //    }
        //}

        

        /// <summary> 地址 </summary>
        public string ExcuteServiceAddress
        {
            get
            {
                return string.Format(WcfConfiger.RomoteFormat, this.IP, this.Port, "SystemBrowserService");
            }

        }

        public List<string> GetDrivers()
        {
            using (ChannelFactory<ISystemBrowserService> channelFactory = new ChannelFactory<ISystemBrowserService>(WSHttpBinding, ExcuteServiceAddress))
            {
                ISystemBrowserService proxy = channelFactory.CreateChannel();

                return proxy.GetDrivers();
            }
        }

        public List<string> GetFolder(string parent)
        {
            using (ChannelFactory<ISystemBrowserService> channelFactory = new ChannelFactory<ISystemBrowserService>(WSHttpBinding, ExcuteServiceAddress))
            {
                ISystemBrowserService proxy = channelFactory.CreateChannel();

                return proxy.GetFolder(parent);
            }

        }

        public List<string> GetFiles(string folder)
        {
            using (ChannelFactory<ISystemBrowserService> channelFactory = new ChannelFactory<ISystemBrowserService>(WSHttpBinding, ExcuteServiceAddress))
            {
                ISystemBrowserService proxy = channelFactory.CreateChannel();

                return proxy.GetFiles(folder);
            }
        }
    }
}
