#region <版 本 注 释>
/*
 * ========================================================================
 * Copyright(c) 长虹智慧健康有限公司, All Rights Reserved.
 * ========================================================================
 *    
 * 作者：[李海军]   时间：2018/5/22 16:28:55 
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
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.General.WcfLibrary.Service
{
   public  class ImageSenderService : IImageSenderService
    {
        static IStreamPrivider _streamprivider = new StreamPrivider();

        public void PrintStreenToStream()
        {
            var bitmap = WinSysHelper.Instance.PrintScreem();

            //FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            //新建一个内存流 用于存放图片
            MemoryStream strPic = new MemoryStream();

            bitmap.Save(strPic, ImageFormat.Jpeg);

            _streamprivider.SetStream(strPic);

        }

        public bool ReadNextBuffer()
        {
            return _streamprivider.ReadNextBuffer();
        }

        public byte[] GetCurrentBuffer()
        {
            return _streamprivider.GetCurrectBuffer();
        }
    }
}
