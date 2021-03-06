﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfLibrary.Interface
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    /// <summary> 执行程序服务 </summary>
    [ServiceContract]
    public interface IExcuteService
    {
        /// <summary> 执行步骤一 </summary>
        [OperationContract]
        void ExecuteCmd(string cmdString);

        /// <summary> 执行步骤一 </summary>
        [OperationContract]
        string ExecuteCmdOutPut(string cmdString);

        /// <summary> 执行步骤一 </summary>
        [OperationContract]
        void ExecuteAction(string act);

    }
}
