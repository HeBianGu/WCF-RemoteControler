#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 长虹智慧健康有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2018/5/22 16:16:53 
 * 文件名：Class1 
 * 说明：
 * 
 * 
 * 修改者：           时间：               
 * 修改说明：
 * ========================================================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Base.WcfManager
{
    /// <summary> WCF服务引擎 </summary>
    public partial class WcfRegisterProvider
    {
        private WcfRegisterProvider()
        {

        }

        public static WcfRegisterProvider Instance = new WcfRegisterProvider();

        List<ServiceHost> serviceHosts = new List<ServiceHost>();

    }

    public partial class WcfRegisterProvider
    {
        /// <summary> 根据类型字典和端口注册服务 </summary>
        public void AddService(Dictionary<Type, Type> serviceTypes)
        {
            string endpointAddress = string.Empty;

            string tName = string.Empty;

            foreach (var item in serviceTypes)
            {
                tName = item.Key.Name.Substring(1);

                endpointAddress = string.Format(WcfConfiger.RomoteFormat, WcfConfiger.Instance.IP, WcfConfiger.Instance.Port, tName);

                ServiceHost host = new ServiceHost(item.Value, new Uri(endpointAddress));

                WSHttpBinding wsHttpBinding = new WSHttpBinding();
                wsHttpBinding.MaxBufferPoolSize = int.MaxValue;
                wsHttpBinding.MaxReceivedMessageSize = int.MaxValue;
                wsHttpBinding.ReceiveTimeout = new TimeSpan(1, 0, 0);
                wsHttpBinding.Security = new System.ServiceModel.WSHttpSecurity();
                wsHttpBinding.Security.Mode = SecurityMode.None;
                host.AddServiceEndpoint(item.Key, wsHttpBinding, string.Empty);

                ServiceMetadataBehavior behavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();

                if (behavior == null)
                {
                    behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    host.Description.Behaviors.Add(behavior);
                }
                else
                {
                    behavior.HttpGetEnabled = true;
                }

                DataContractSerializerOperationBehavior dataContractBehavior = host.Description.Behaviors.Find<DataContractSerializerOperationBehavior>()
                            as DataContractSerializerOperationBehavior;

                if (dataContractBehavior != null)
                {
                    dataContractBehavior.MaxItemsInObjectGraph = int.MaxValue;
                }

                host.Open();
                serviceHosts.Add(host);
            }
        }
    }
}
