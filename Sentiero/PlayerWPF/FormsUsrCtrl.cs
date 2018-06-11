using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayerWPF
{
    public partial class FormsUsrCtrl : UserControl
    {
        public event EventHandler<PositionArgs> PositionChanged;
        public FormsUsrCtrl()
        {
            InitializeComponent();
        }

        public string GetMediaName()
        {
            return axWindowsMediaPlayer1.currentMedia.name;
        }
        public void Play(string URL)
        {
            axWindowsMediaPlayer1.URL = URL;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        public void Play()
        {
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
        public void Pause()
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause();
        }
        public WMPLib.WMPPlayState GetPlayState()
        {
            return axWindowsMediaPlayer1.playState;
        }
        public void SetPosition(double time)
        {
            axWindowsMediaPlayer1.Ctlcontrols.currentPosition = time;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (PositionChanged != null)
            {
                PositionChanged(this, new PositionArgs(axWindowsMediaPlayer1.currentMedia.duration, axWindowsMediaPlayer1.Ctlcontrols.currentPosition));
            }
        }
        
    }
    public struct PositionArgs
    {
        public PositionArgs(double end,double current)
        {
            this.duration = end;
            this.current = current;
        }
        public double duration;
        public double current;
    }

}
