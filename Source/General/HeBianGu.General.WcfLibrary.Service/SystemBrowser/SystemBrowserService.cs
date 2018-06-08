#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 长虹智慧健康有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2018/5/22 17:41:02 
 * 文件名：Class1 
 * 说明：
 * 
 * 
 * 修改者：           时间：               
 * 修改说明：
 * ========================================================================
*/
#endregion
using HeBianGu.General.WcfLibrary.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfLibrary.Service
{
    public class SystemBrowserService : ISystemBrowserService
    {
        public List<string> GetDrivers()
        {
            return Directory.GetLogicalDrives().ToList();
        }

        public List<string> GetFolder(string parent)
        {
            try
            {
                return Directory.GetDirectories(parent).ToList();
            }
            catch
            {
                return new List<string>();
            }

        }

        public List<string> GetFiles(string folder)
        {
            return Directory.GetFiles(folder).ToList();
        }
    }
}
