#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 长虹智慧健康有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2018/5/22 16:56:46 
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
using HeBianGu.Base.WcfManager.Privider;
using HeBianGu.Domian.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Domain.Service
{

    /// <summary> 宿主领域服务 </summary>
    public class HostService
    {
        public static HostService Instance = new HostService();

        public void Start()
        {

            Dictionary<Type, Type> dic = WcfServiceFactory.Instance.CreateMonitorService();
         
            WcfRegisterProvider.Instance.AddService(dic);
        }


        /// <summary> 启动宿主 </summary>
        public void StartConsoleHost()
        {
            LogService.Instance.RunLog("准备启动服务！");

            LogService.Instance.RunLog(WcfConfiger.Instance.IP);

            LogService.Instance.RunLog(WcfConfiger.Instance.Port);

            try
            {
                this.Start();

                LogService.Instance.RunLog("启动成功，按任意键退出！");

            }
            catch (Exception ex)
            {
                LogService.Instance.ErrLog(ex);
            }

            LogService.Instance.RunLog("按任意键退出！");

            Console.Read();
        }

    }
}
