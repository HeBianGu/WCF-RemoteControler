#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 长虹智慧健康有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2018/5/22 16:52:32 
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
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Base.WcfManager.Privider
{
    /// <summary> 提供控制台日志输出 </summary>
    public class LogService
    {
        public static LogService Instance = new LogService();

        int Step = 1;

        /// <summary> 输出步骤格式 </summary>
        public string StepString
        {
            get
            {
                return string.Format("步骤 {0} ,", (Step++).ToString());
            }
        }

        /// <summary> 时间间隔 </summary>
        public string TimeSpan
        {
            get
            {
                return string.Format("  时间：{0}  间隔 {1} ,", DateTime.Now.ToString(), (DateTime.Now - CurrentTime).ToString());
            }
        }
        public DateTime CurrentTime { get; set; }

        string runLogFormat = "     正在运行：[{0}]";
        /// <summary> 运行日志格式 </summary>
        string RunLogFormat
        {
            get { return StepString + runLogFormat; }
        }

        string errLogFormat = "     处理异常：[{0}]";
        /// <summary> 错误日志格式 </summary>
        string ErrLogFormat
        {
            get { return StepString + errLogFormat; }
        }

        /// <summary> 写运行日志 </summary>>
        public void RunLog(string str)
        {
            //Console.WriteLine(StepString + TimeSpan);
            string outtemp = string.Format(RunLogFormat, str);
            Console.WriteLine(outtemp);
            this.CurrentTime = DateTime.Now;
        }

        /// <summary> 写错误日志 </summary>
        public void ErrLog(string str)
        {
            //Console.WriteLine(StepString + TimeSpan);
            string outtemp = string.Format(ErrLogFormat, str);
            Console.WriteLine(outtemp);
            this.CurrentTime = DateTime.Now;
        }

        /// <summary> 写错误日志 </summary>
        public void ErrLog(Exception ex)
        {
            //Console.WriteLine(StepString + TimeSpan);
            string outtemp = string.Format(ErrLogFormat, ex.Message);
            Console.WriteLine(outtemp);
            this.CurrentTime = DateTime.Now;
        }
    }
}
