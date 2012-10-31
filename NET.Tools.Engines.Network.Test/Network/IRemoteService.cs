using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Tools.Engines.Network.Test
{
    public interface IRemoteService
    {
        double Add(double a, double b);
        double Mul(double a, double b);
        double Div(double a, double b);
        double Sub(double a, double b);
    }
}
