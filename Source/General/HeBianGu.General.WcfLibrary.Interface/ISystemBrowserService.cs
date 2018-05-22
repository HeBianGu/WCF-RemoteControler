#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 长虹智慧健康有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2018/5/22 17:38:40 
 * 文件名：ISystemBrowserService 
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
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfLibrary.Interface
{
    [ServiceContract]
    public interface ISystemBrowserService
    {
        [OperationContract]
         List<string> GetDrivers();
        [OperationContract]
         List<string> GetFolder(string parent);
        [OperationContract]
         List<string> GetFiles(string folder);
    }
}
