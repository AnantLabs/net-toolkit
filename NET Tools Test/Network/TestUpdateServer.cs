using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using NET.Tools.Engines.Network;

namespace NET.Tools.Test
{
    public class TestUpdateServer : DefaultUpdateServer
    {
        private Stream setup;

        public TestUpdateServer()
        {
            Random rand = new Random();

            setup = new MemoryStream();
            for (int i = 0; i < 100000; i++)
                setup.WriteByte((byte)(rand.Next() % 256));
            setup.Seek(0, SeekOrigin.Begin);
        }

        public override Version NewVersion
        {
            get { return new Version(2, 0); }
        }

        public override System.IO.Stream UpdateSetup
        {
            get { return setup; }
        }
    }
}
