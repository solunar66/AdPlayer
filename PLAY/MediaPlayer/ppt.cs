using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using OFFICECORE = Microsoft.Office.Core;
using POWERPOINT = Microsoft.Office.Interop.PowerPoint;
using MSG;

namespace PPT
{
    public class OperatePPT
    {
        #region=========基本的参数信息=======
        POWERPOINT.Application objApp = null;
        POWERPOINT.Presentation objPresSet = null;
        POWERPOINT.SlideShowWindows objSSWs;
        POWERPOINT.SlideShowTransition objSST;
        POWERPOINT.SlideShowSettings objSSS;
        POWERPOINT.SlideRange objSldRng;

        bool bAssistantOn;
        int iSlideIndex = 0;
        int iSlideShowTime = 0;
        #endregion

        public OperatePPT()
        { }

        #region===========操作方法==============

        /// <summary>
        /// 自动播放PPT文档.
        /// </summary>
        /// <param name="filePath">PPTy文件路径.</param>
        /// <param name="playTime">翻页的时间间隔.【以秒为单位】</param>
        public void PPTAuto(string filePath, int playTime)
        {
            iSlideShowTime = playTime;
            try
            {
                //防止连续打开多个PPT程序.
                if (this.objApp != null) return;
                objApp = new POWERPOINT.Application();
                objPresSet = objApp.Presentations.Open(filePath, OFFICECORE.MsoTriState.msoCTrue, OFFICECORE.MsoTriState.msoFalse, OFFICECORE.MsoTriState.msoFalse);
                // 自动播放的代码（开始）
                int Slides = objPresSet.Slides.Count;
                int[] SlideIdx = new int[Slides];
                for (int i = 0; i < Slides; i++) { SlideIdx[i] = i + 1; };
                objSldRng = objPresSet.Slides.Range(SlideIdx);
                objSST = objSldRng.SlideShowTransition;
                //设置翻页的时间.
                objSST.AdvanceOnTime = OFFICECORE.MsoTriState.msoCTrue;
                objSST.AdvanceTime = playTime;
                //翻页时的特效!
                objSST.EntryEffect = POWERPOINT.PpEntryEffect.ppEffectCircleOut;
                //Prevent Office Assistant from displaying alert messages:
                bAssistantOn = objApp.Assistant.On;
                objApp.Assistant.On = false;
                //Run the Slide show from slides 1 thru 3.
                objSSS = objPresSet.SlideShowSettings;
                objSSS.StartingSlide = 1;
                objSSS.EndingSlide = Slides;
                objApp.SlideShowNextSlide += new POWERPOINT.EApplication_SlideShowNextSlideEventHandler(objApp_SlideShowNextSlide);
                objSSS.Run();
            }
            catch (Exception ex)
            {
                this.objApp.Quit();
            }
        }

        /// <summary>
        /// 关闭PPT文档。
        /// </summary>
        public void PPTClose()
        {
            //装备PPT程序。
            if (this.objPresSet != null)
            {
                //判断是否退出程序,可以不使用。
                //objSSWs = objApp.SlideShowWindows;
                //if (objSSWs.Count >= 1)
                //{
                //if (MessageBox.Show("是否保存修改的笔迹!", "提示", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
                //    this.objPresSet.Save();
                //}
                this.objPresSet.Close();
            }
            if (this.objApp != null)
                //    this.objApp.Quit();
                //GC.Collect();

                try
                {
                    Process[] thisproc = Process.GetProcessesByName("POWERPNT");
                    if (thisproc.Length > 0)
                    {
                        for (int i = 0; i < thisproc.Length; i++)
                        {
                            if (!thisproc[i].CloseMainWindow()) //尝试关闭进程 释放资源
                            {
                                thisproc[i].Kill(); //强制关闭
                            }
                            //Console.WriteLine("进程 {0}关闭成功", processName);
                        }
                    }
                    else
                    {
                        //Console.WriteLine("进程 {0} 关闭失败!", processName);
                    }
                }
                catch //出现异常，表明 kill 进程失败
                {
                    //Console.WriteLine("结束进程{0}出错！", processName);
                }
        }

        /// <summary>
        /// 自动播放完成后关闭
        /// </summary>
        /// <param name="Wn">播放窗口状态</param>
        private void objApp_SlideShowNextSlide(POWERPOINT.SlideShowWindow Wn)
        {
            iSlideIndex++;
            if (iSlideIndex == Wn.Presentation.Slides.Count)
            {
                //等待最后一页播放完成
                System.Threading.Thread.Sleep(iSlideShowTime * 1000);
                //清零
                iSlideIndex = 0;

                PPTClose();
                //等待进程退出
                System.Threading.Thread.Sleep(500);

                //继续播放
                IntPtr ptr = Msg.FindWindow(null, "广告播放系统");
                if (IntPtr.Zero == ptr) return;
                Msg.My_lParam_Notice m = new Msg.My_lParam_Notice();
                Msg.PostMessage(ptr, Msg.INT_MSG_GoOnPlayingAfterPPT, 1, ref m);//发送消息
            }
        }
        #endregion
    }
}
