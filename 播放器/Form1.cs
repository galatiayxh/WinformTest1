using DirectShowLib;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace 播放器
{
    public partial class Form1 : Form
    {
        //0x0400 is WM_USER in the window message
        private const int WMGraphNotify = 0x0400 + 19;
        private Thread t = null;
        //See DirectShow Interface:
        //    http://msdn.microsoft.com/zh-cn/library/ms919457.aspx
        private IGraphBuilder graphBuilder = null;
        private IMediaControl mediaControl = null;
        private IMediaEventEx mediaEventEx = null;
        private IVideoWindow videoWindow = null;
        private IBasicAudio basicAudio = null;
        private IBasicVideo basicVideo = null;
        private IMediaSeeking mediaSeeking = null;
        private IMediaPosition mediaPosition = null;
        private IVideoFrameStep frameStep = null;

        public Form1()
        {
            InitializeComponent();
            trackBar1.SetRange(-1000, 0);
            this.txtPath.Text = @"C:\Users\15388\Videos\Captures\aa.avi";
        }
        //Initialize the window playing video
        private int InitVideoWindow(int nMultiplier, int nDivider)
        {
            int hr = 0;
            int Height, Width;

            if (this.basicVideo == null)
            {
                return 0;
            }
            //read the default video size
            hr = this.basicVideo.GetVideoSize(out Width, out Height);
            if (hr == DsResults.E_NoInterface)
            {
                return 0;
            }
            //account for requests of normal,half,or double size
            Width = Width * nMultiplier / nDivider;
            Height = Height * nMultiplier / nDivider;
            this.ClientSize = new Size(Width, Height + 75);
            Application.DoEvents();

            hr = this.videoWindow.SetWindowPosition(0, 30, Width, Height);

            return hr;
        }
        //set the trackBar1'value equel the video'progress
        private void updateTimeBarThread()
        {
            double time;
            int volu;
            while (true)
            {
                mediaPosition.get_CurrentPosition(out time);
                Console.WriteLine(time);
                basicAudio.get_Volume(out volu);
                Console.WriteLine(volu);
                this.BeginInvoke(new MethodInvoker(() =>
                {
                    trackBar1.Value = (int)time;
                }));
                Thread.Sleep(1000);
            }
        }
        //close video
        private void closeVideo()
        {
            int hr = 0;
            //stop media playback
            if (this.mediaControl != null)
                hr = this.mediaControl.Stop();
            //free directShow interfaces
            closeInterfaces();
            btnPlay.Text = "Play";
        }
        private void closeInterfaces()
        {
            int hr = 0;
            try
            {
                lock (this)
                {
                    //relinquish ownership (IMPORTANT!) after hiding video window
                    hr = this.videoWindow.put_Visible(OABool.False);
                    DsError.ThrowExceptionForHR(hr);
                    hr = this.videoWindow.put_Owner(IntPtr.Zero);
                    DsError.ThrowExceptionForHR(hr);

                    if (this.mediaEventEx != null)
                    {
                        hr = this.mediaEventEx.SetNotifyWindow(IntPtr.Zero, 0, IntPtr.Zero);
                        DsError.ThrowExceptionForHR(hr);
                    }
                    //release and zero DirectShow interfaces
                    if (this.mediaEventEx != null) this.mediaEventEx = null;
                    if (this.mediaSeeking != null) this.mediaSeeking = null;
                    if (this.mediaPosition != null) this.mediaPosition = null;
                    if (this.mediaControl != null) this.mediaControl = null;
                    if (this.basicAudio != null) this.basicAudio = null;
                    if (this.basicVideo != null) this.basicVideo = null;
                    if (this.videoWindow != null) this.videoWindow = null;
                    if (this.frameStep != null) this.frameStep = null;
                    if (this.graphBuilder != null)
                    {
                        Marshal.ReleaseComObject(this.graphBuilder);
                        this.graphBuilder = null;
                    }
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Ctrl'event
        private void btnPlay_Click(object sender, EventArgs e)
        {
            int hr = 0;
            if (this.graphBuilder == null)
            {


                string filename = txtPath.Text;
                this.graphBuilder = (IGraphBuilder)new FilterGraph();

                hr = this.graphBuilder.RenderFile(filename, null);
                DsError.ThrowExceptionForHR(hr);
                // QueryInterface for DirectShow interfaces
                this.mediaControl = (IMediaControl)this.graphBuilder;
                this.mediaEventEx = (IMediaEventEx)this.graphBuilder;
                this.mediaSeeking = (IMediaSeeking)this.graphBuilder;
                this.mediaPosition = (IMediaPosition)this.graphBuilder;
                // Query for video interfaces, which may not be relevant for audio files
                this.videoWindow = this.graphBuilder as IVideoWindow;
                this.basicVideo = this.graphBuilder as IBasicVideo;
                // Query for audio interfaces, which may not be relevant for video-only files
                this.basicAudio = this.graphBuilder as IBasicAudio;

                hr = this.mediaEventEx.SetNotifyWindow(this.Handle, WMGraphNotify, IntPtr.Zero);
                DsError.ThrowExceptionForHR(hr);
                //Setup the video window
                hr = this.videoWindow.put_Owner(this.Handle);
                DsError.ThrowExceptionForHR(hr);

                hr = this.videoWindow.put_WindowStyle(WindowStyle.Child | WindowStyle.ClipSiblings | WindowStyle.ClipChildren);
                DsError.ThrowExceptionForHR(hr);

                this.Focus();

                hr = InitVideoWindow(1, 1);
                DsError.ThrowExceptionForHR(hr);

                double time;
                mediaPosition.get_Duration(out time);
                trackBar1.SetRange(0, (int)time);
                //create a new Thread
                t = new Thread(new ThreadStart(updateTimeBarThread));

                if (btnPlay.Text.Equals("Play"))
                {
                    hr = this.mediaControl.Run();
                    DsError.ThrowExceptionForHR(hr);
                    btnPlay.Text = "Pause";
                }
                else
                {
                    hr = this.mediaControl.Pause();
                    DsError.ThrowExceptionForHR(hr);
                    btnPlay.Text = "Play";
                }
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            closeVideo();
            t.Abort();
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (mediaPosition != null)
            {
                mediaPosition.put_CurrentPosition(trackBar1.Value);
            }
        }

    }
}

