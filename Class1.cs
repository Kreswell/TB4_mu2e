using System;
using System.Collections.Generic;
using MathNet.Numerics;

namespace TB_mu2e
{
    public class VoltageRegister
    {
        //Names are, for a given FPGA, Bias0, Bias1, Trim0 -- Trim15, LED0 -- LED7
        public string name { get; set; }
        public double voltage { get; set; }
        private Mu2e_Register

        public VoltageRegister(int fpga, int name)
        {

        }
    }
}
