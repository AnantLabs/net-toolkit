using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.AudioVideoPlayback;

namespace NET.Tools.Engines.AVM
{
    /// <summary>
    /// Represent an audio player
    /// </summary>
    public class AVMAudioPlayer : IPlayer<double>, IAudio, IDisposable
    {
        protected Audio audio = null;

        /// <summary>
        /// Gets the audio file to play
        /// </summary>
        public String AudioFile { get; private set; }

        public AVMAudioPlayer(string audioFile)
            : this()
        {
            AudioFile = audioFile;
        }

        protected AVMAudioPlayer()
        {
            IsLoop = false;
        }

        #region IPlayer Member

        public void Start()
        {
            if (audio == null)
                CreateAudioPlayer();

            audio.Play();
        }

        public void Pause()
        {
            if (audio == null)
                CreateAudioPlayer();

            audio.Pause();
        }

        public void Stop()
        {
            if (audio == null)
                CreateAudioPlayer();

            audio.Stop();
        }

        public bool IsPlayed
        {
            get
            {
                if (audio == null)
                    CreateAudioPlayer();

                return audio.Playing;
            }
        }

        public bool IsPaused
        {
            get
            {
                if (audio == null)
                    CreateAudioPlayer();

                return audio.Paused;
            }
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
                if (audio == null)
                    CreateAudioPlayer();

                return audio.CurrentPosition;
            }
            set
            {
                if (audio == null)
                    CreateAudioPlayer();

                audio.SeekCurrentPosition(value, SeekPositionFlags.AbsolutePositioning);
            }
        }

        public double Length
        {
            get
            {
                if (audio == null)
                    CreateAudioPlayer();

                return audio.Duration;
            }
        }

        public event EventHandler Finished;

        #endregion

        #region IAudio Member

        public double Volume
        {
            get
            {
                if (audio == null)
                    CreateAudioPlayer();

                return (audio.Volume + 10000) / 10000;
            }
            set
            {
                if ((value < 0d) || (value > 1d))
                    throw new ArgumentException("The volume must be between 0 and 1!");

                if (audio == null)
                    CreateAudioPlayer();

                audio.Volume = (int)(value * 10000) - 10000;
            }
        }

        public double Balance
        {
            get
            {
                if (audio == null)
                    CreateAudioPlayer();

                return audio.Balance / 10000d;
            }
            set
            {
                if ((value < -1d) || (value > 1d))
                    throw new ArgumentException("The balance must be between -1 and 1!");

                if (audio == null)
                    CreateAudioPlayer();

                audio.Balance = (int)(value * 10000d);
            }
        }

        #endregion

        #region IDisposable Member

        public virtual void Dispose()
        {
            if (audio != null)
                audio.Dispose();
        }

        public bool IsDisposed
        {
            get
            {
                if (audio != null)
                    return audio.Disposed;
                else
                    return false;
            }
        }

        #endregion

        protected virtual void CreateAudioPlayer()
        {
            audio = new Audio(AudioFile, false);
            audio.Ending += (s, e) =>
            {
                if (Finished != null)
                    Finished(this, new EventArgs());

                if (IsLoop)
                {
                    audio.Stop();
                    audio.SeekStopPosition(0, SeekPositionFlags.AbsolutePositioning);
                    audio.Play();
                }
            };  
        }
    }
}
