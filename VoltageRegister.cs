using System;
using System.Collections.Generic;
using MathNet.Numerics;

namespace TB_mu2e
{
    public class VoltageRegister
    {
        //Names are, for a given FPGA, Bias0, Bias1, Trim0 -- Trim15, LED0 -- LED7
        public string name { get; set; }
        public int fpga;
        public double voltage { get; set; }
        private Mu2e_Register register;
        public List<double> HVHiVals = new List<double>();
        public List<double> HVMedVals = new List<double>();
        public List<double> HVLowVals = new List<double>();
        private double gain { get; set; }
        private double offset { get; set; }
        private bool isTested { get; set; }
        private bool isCalibrated { get; set; }


        double calcGain()
        {
            return gain;
        }

        public VoltageRegister(int fpga, string name)
        {
            isTested = false;
            isCalibrated = false;
            gain = 1;
            offset = 0;
            voltage = 0;
            if (name.Contains("Bias"))
            {
                if (name[4] == 0)
                {
                }
            }
            else if (name.Contains("Trim"))
            {

            }
            else if (name.Contains("LED"))
            {

            }
            else { }
        }
    }
}
