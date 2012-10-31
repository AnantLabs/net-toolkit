using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.AudioVideoPlayback;
using System.Threading;

namespace NET.Tools.Engines.AVM
{
    /// <summary>
    /// Represent a music player
    /// 
    /// This is a player that can play a list of audios with a lot of options
    /// </summary>
    public sealed class AVMMusicPlayer : AVMAudioPlayer, IMusic
    {
        private int listIndex = 0;
        private Random random = new Random();
        private Thread playerThread;
        private Audio nextAudio = null;

        public AVMMusicPlayer()
            : base()
        {
            MusicFileList = new List<String>();
            playerThread = new Thread(CheckEnding);
            playerThread.Start();

            PlayRandom = true;
            Overlap = 1;
        }

        #region IMusic Member

        public IList<string> MusicFileList
        {
            get;
            private set;
        }

        public bool PlayRandom
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public double Overlap
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        protected override void CreateAudioPlayer()
        {
            if (MusicFileList.Count <= 0)
                throw new InvalidOperationException("The music list is empty!");

            audio = new Audio(MusicFileList[listIndex]);
            audio.Ending += new EventHandler(audio_Ending);
        }

        private void audio_Ending(object sender, EventArgs e)
        {
            //Dispose old
            audio.Stop();
            audio.Dispose();
            audio = null;

            //New audio is next audio 
            audio = nextAudio;
            nextAudio = null; //Next audio is null
        }

        private void NextAudio()
        {
            if (!PlayRandom)
            {
                listIndex++;
                if (listIndex >= MusicFileList.Count)
                    listIndex = 0;
            }
            else
            {
                if (MusicFileList.Count > 1)
                {
                    int nextIndex = listIndex;
                    while (nextIndex == listIndex)
                    {
                        nextIndex = random.Next() % MusicFileList.Count;
                    }
                    listIndex = nextIndex;
                }
            }
            if (MusicFileList.Count <= 0)
                throw new InvalidOperationException("The music list is empty!");

            nextAudio = new Audio(MusicFileList[listIndex]);
            nextAudio.Volume = -10000;
            nextAudio.Ending += new EventHandler(audio_Ending);
        }

        public override void Dispose()
        {
            playerThread.Abort();
            base.Dispose();
        }

        private void CheckEnding()
        {
            while (true)
            {
                lock (audio)
                {
                    if (audio.Duration - audio.CurrentPosition <= Overlap)
                    {
                        if (nextAudio == null)
                            NextAudio();
                        else
                        {
                            nextAudio.Volume = -(int)((audio.Duration - audio.CurrentPosition) * 10000 / Overlap);
                            audio.Volume = -(10000 - (int)((audio.Duration - audio.CurrentPosition) * 10000 / Overlap));
                        }
                    }
                }

                Thread.Sleep(100);
            }
        }
    }
}
