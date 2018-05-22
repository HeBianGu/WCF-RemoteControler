#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 长虹智慧健康有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2018/5/22 16:10:51 
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
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfLibrary.Service
{
    public partial class ExcuteClientService : WcfClientBase
    {
        public ExcuteClientService(string ip, string port)
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

        /// <summary> 地址 </summary>
        public string ExcuteServiceAddress
        {
            get
            {
                return string.Format(WcfConfiger.RomoteFormat, this.IP, this.Port, "ExcuteService");
            }

        }

        /// <summary> 地址 </summary>
        public string ImageSenderAddress
        {
            get
            {
                return string.Format(WcfConfiger.RomoteFormat, this.IP, this.Port, "StreamPrivider");
            }

        }

        /// <summary> 运行Cmd命令 </summary>
        public void ExecuteCmd(string cmdString)
        {
            using (ChannelFactory<IExcuteService> channelFactory = new ChannelFactory<IExcuteService>(WSHttpBinding, ExcuteServiceAddress))
            {
                IExcuteService proxy = channelFactory.CreateChannel();

                proxy.ExecuteCmd(cmdString);
            }
        }

        /// <summary> 运行Cmd命令 </summary>
        public string ExecuteCmdOutPut(string cmdString)
        {
            using (ChannelFactory<IExcuteService> channelFactory = new ChannelFactory<IExcuteService>(WSHttpBinding, ExcuteServiceAddress))
            {
                IExcuteService proxy = channelFactory.CreateChannel();

                return proxy.ExecuteCmdOutPut(cmdString);
            }
        }

        /// <summary> 执行二进制序列化的无参数委托 </summary>
        public void ExecuteAction(string act)
        {
            using (ChannelFactory<IExcuteService> channelFactory = new ChannelFactory<IExcuteService>(WSHttpBinding, ExcuteServiceAddress))
            {
                IExcuteService proxy = channelFactory.CreateChannel();

                proxy.ExecuteAction(act);
            }
        }

        //public List<string> GetDrivers()
        //{
        //    return Directory.GetLogicalDrives().ToList();
        //}

        //public List<string> GetFolder(string parent)
        //{
        //    try
        //    {
        //        return Directory.GetDirectories(parent).ToList();
        //    }
        //    catch
        //    {
        //        return new List<string>();
        //    }

        //}

        //public List<string> GetFiles(string folder)
        //{
        //    return Directory.GetFiles(folder).ToList();
        //}

    }


}
