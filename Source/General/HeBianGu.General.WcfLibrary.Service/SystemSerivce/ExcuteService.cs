#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 长虹智慧健康有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2018/5/22 16:47:53 
 * 文件名：Class1 
 * 说明：
 * 
 * 
 * 修改者：           时间：               
 * 修改说明：
 * ========================================================================
*/
#endregion
using HeBianGu.Base.WinService;
using HeBianGu.General.WcfLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfLibrary.Service
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class ExcuteService : IExcuteService
    {
        /// <summary> 执行Cmd命令 </summary>
        public void ExecuteCmd(string cmdString)
        {
            //ActionDelegate action = cmdString.SerializeDeBinary<ActionDelegate>();

            //action();

            Process.Start(cmdString);
        }

        /// <summary> 执行Cmd命令 </summary>
        public string ExecuteCmdOutPut(string cmdString)
        {
            return CmdAPI.RunCmdOutPut(cmdString);
        }

        /// <summary> 执行Cmd命令 </summary>
        public void ExecuteAction(string act)
        {
            //ActionDelegate action = act.ActString.SerializeDeBinary<ActionDelegate>();

            //action();
        }


    }
}
