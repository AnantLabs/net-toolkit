using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.AudioVideoPlayback;
using System.Windows.Forms;

namespace NET.Tools.Engines.AVM
{
    /// <summary>
    /// Represent a video player
    /// </summary>
    public sealed class AVMVideoPlayer : IPlayer<double>, IAudio, IVideo, IDisposable
    {
        private Video video;

        /// <summary>
        /// Gets the video file to play
        /// </summary>
        public String VideoFile { get; private set; }

        public AVMVideoPlayer(string videoFile, Control target)
        {
            VideoFile = videoFile;
            video = new Video(videoFile, false);
            video.Ending += (s, e) =>
            {
                if (Finished != null)
                    Finished(this, new EventArgs());

                if (IsLoop)
                {
                    video.Stop();
                    video.SeekStopPosition(0, SeekPositionFlags.AbsolutePositioning);
                    video.Play();
                }
            };

            IsLoop = false;
            Target = target;
        }

        #region IPlayer Member

        public void Start()
        {
            video.Play();
        }

        public void Pause()
        {
            video.Pause();
        }

        public void Stop()
        {
            video.Stop();
        }

        public bool IsPlayed
        {
            get { return video.Playing; }
        }

        public bool IsPaused
        {
            get { return video.Paused; }
        }

        public bool IsLoop
        {
            get;
            set;
        }

        public double Position
        {
            get
            {
                return video.CurrentPosition;
            }
            set
            {
                video.SeekCurrentPosition(value, SeekPositionFlags.AbsolutePositioning);
            }
        }

        public double Length
        {
            get { return video.Duration; }
        }

        public event EventHandler Finished;

        #endregion

        #region IAudio Member

        public double Volume
        {
            get
            {
                return (video.Audio.Volume + 10000) / 10000;
            }
            set
            {
                if ((value < 0d) || (value > 1d))
                    throw new ArgumentException("The volume must be between 0 and 1!");

                video.Audio.Volume = (int)(value * 10000) - 10000;
            }
        }

        public double Balance
        {
            get
            {
                return video.Audio.Balance / 10000d;
            }
            set
            {
                if ((value < -1d) || (value > 1d))
                    throw new ArgumentException("The balance must be between -1 and 1!");

                video.Audio.Balance = (int)(value * 10000d);
            }
        }

        #endregion

        #region IDisposable Member

        public void Dispose()
        {
            video.Dispose();
        }

        public bool IsDisposed
        {
            get { return video.Disposed; }
        }

        #endregion

        #region IVideo Member

        public Control Target
        {
            get { return video.Owner; }
            set { video.Owner = value; }
        }

        public string Caption
        {
            get
            {
                return video.Caption;
            }
            set
            {
                if (Target != null)
                    throw new InvalidOperationException("Target is set!");

                video.Caption = value;
            }
        }

        public bool Fullscreen
        {
            get
            {
                return video.Fullscreen;
            }
            set
            {
                if (Target != null)
                    throw new InvalidOperationException("Target is set!");

                video.Fullscreen = true;
            }
        }

        #endregion
    }
}
