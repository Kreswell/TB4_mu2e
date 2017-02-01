using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.ComponentModel;

namespace TB_mu2e
{
    public static class AddRegisters
    {
        public static void add_FEB_reg(out List<Mu2e_Register> list_of_reg)
        {
            list_of_reg = new List<Mu2e_Register>(10);
            Mu2e_Register r1 = new Mu2e_Register();
            r1.name = "CSR";
            r1.addr = 0x00;
            r1.fpga_offset_mult = 0x400;
            r1.pref_hex = true;
            r1.comment = "Control and status register";
            r1.bit_comment = new string[15];
            r1.bit_comment[0] = "Power Down AFE 0. 0: Run. 1: Power down.";
            r1.bit_comment[1] = "Power Down AFE 1. 0: Run. 1: Power down.";
            r1.bit_comment[2] = "Issue a reset to the AFE deserializer logic in the FPGA";
            r1.bit_comment[3] = "Issue a MIG DDR interface reset";
            r1.bit_comment[4] = "Reset readout sequencer 1: Reset, 0: No action";
            r1.bit_comment[5] = "Issue a general reset. The AFE FIFOs, Trigger counter, Spill counter and Readout sequencer are reset.";
            r1.bit_comment[6] = "Reset the serial controller in the AFE chips";
            r1.bit_comment[7] = "Clear FM receive parity error.";
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "SDRAM_WritePointer";
            r1.addr = 0x03;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "SDRam Write address (2=upper bits, 3=lower bits)";
            r1.bit_comment = new string[15];
            r1.width = 32;
            r1.upper_addr = 0x02;
            r1.lower_addr = 0x03;
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "SDRAM_ReadPointer";
            r1.addr = 0x05;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "SDRam Read address (4=upper bits, 5=lower bits)";
            r1.bit_comment = new string[15];
            r1.width = 32;
            r1.upper_addr = 0x04;
            r1.lower_addr = 0x05;
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "SDRAM_read_swapped";
            r1.addr = 0x06;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Byte swapped SDRam read data port";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "SDRAM_read";
            r1.addr = 0x07;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Un-swapped SDRam data port";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "MIG_Status";
            r1.addr = 0x08;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "MIG status register";
            r1.bit_comment = new string[15];
            r1.bit_comment[0] = "DDR Reset Busy";
            r1.bit_comment[1] = "DDR Cal Done";
            r1.bit_comment[2] = "WRITE command FIFO full";
            r1.bit_comment[3] = "WRITE command FIFO empty";
            r1.bit_comment[4] = "WRITE data FIFO full";
            r1.bit_comment[5] = "WRITE data FIFO empty";
            r1.bit_comment[6] = "READ command FIFO full";
            r1.bit_comment[7] = "READ command FIFO empty";
            r1.bit_comment[8] = "READ data FIFO full";
            r1.bit_comment[9] = "READ data FIFO empty";
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "MIG_fifo_count";
            r1.addr = 0x09;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "13:8 = MIG DDR Write Count , 5:0 = MIG DDR Write Count";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "MIG burst size";
            r1.addr = 0x0A;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "always 8 for now";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "HISTO_CTRL_REG";
            r1.addr = 0x10;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Histogram control register";
            r1.bit_comment = new string[15];
            r1.bit_comment[0] = "Channel select, bits 0-2.";
            r1.bit_comment[4] = "Mode bit. 0: free running, 1: external gate.";
            r1.bit_comment[5] = "Start accumulation for AFE 0";
            r1.bit_comment[6] = "Start accumulation for AFE 1";
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "HISTO_COUNT_INTERVAL";
            r1.addr = 0x11;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "A 12 bit counting interval in steps of 1 millisecond.";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "HISTO_PED_AFE0";
            r1.addr = 0x12;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "This signed 12 bit value is subtracted from the AFE 0 ADC values before being histogrammed.";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "HISTO_PED_AFE1";
            r1.addr = 0x13;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "This signed 12 bit value is subtracted from the AFE 1 ADC values before being histogrammed.";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "HISTO_POINTER_AFE0";
            r1.addr = 0x14;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "The histogram memory is 512 deep x 32 bits wide. This is a 10 bit pointer.";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "HISTO_POINTER_AFE1";
            r1.addr = 0x15;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "The histogram memory is 512 deep x 32 bits wide. This is a 10 bit pointer.";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "HISTO_PORT_AFE0";
            r1.addr = 0x16;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Read AFE 0 histogram memory data port";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "HISTO_PORT_AFE1";
            r1.addr = 0x17;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Read AFE 1 histogram memory data port";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "MUX_SEL";
            r1.addr = 0x20;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Selects which of 16 DAC trim resistors is connected to the second level multiplexer. Set Mux enable to 0 before taking SiPM pulsed data.";
            r1.bit_comment = new string[15];
            r1.bit_comment[0] = "CH select 3:0";
            r1.bit_comment[4] = "MUX enable";
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "CHAN_MASK";
            r1.addr = 0x21;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "A four bit register to select which CMBs to read out. Bits 0..3 enable CMBs 1..4";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);
            
            r1 = new Mu2e_Register();
            r1.name = "TEST_COUNTER";
            r1.addr = 0x23;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "A write to this address defines the 32 bit test counter.  A read from this address displays the value of bits and increments all 32 bits of the counter after the read.";
            r1.bit_comment = new string[15];
            r1.width = 32;
            r1.upper_addr = 0x22;
            r1.lower_addr = 0x23;
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "ONE_WIRE_COMMAND";
            r1.addr = 0x24;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "One wire command register";
            r1.bit_comment = new string[15];
            r1.bit_comment[0] = "Bits 0..7: If an individual write transaction is requested, the lower eight bits of this register are sent to the one wire interface.";
            r1.bit_comment[8] = "Bit 8: Start the read temperature sequencer. A complete read temperature sequence will execute when this bit is set. The read value of this bit will return a 0 until the sequence is complete.";
            r1.bit_comment[9] = "Bit 9: Start the read ROM sequencer. A complete ROM read sequence will execute when this bit is set. The read value of this bit will return a 0 until the sequence is complete.";
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "ONE_WIRE_CONTROL";
            r1.addr = 0x25;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "One wire control register";
            r1.bit_comment = new string[15];
            r1.bit_comment[0] = "Bit 0..3: Selects which CMB read data is stored in the register file";
            r1.bit_comment[4] = "Bit 4: Request a write transaction";
            r1.bit_comment[5] = "Bit 5: Request a read transaction";
            r1.bit_comment[6] = "Request a reset transaction";
            r1.bit_comment[7] = "Bit 7: Transaction status. Returns a ‘1’ when transaction is in progress";
            r1.bit_comment[8] = "Bit 15..8: Transaction bitcount (N-1). For a write set to seven. For a 72 bit read set to 71.";
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "ONE_WIRE_READ0";
            r1.addr = 0x26;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "One wire control register";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "ONE_WIRE_READ1";
            r1.addr = 0x27;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "One wire control register";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "ONE_WIRE_REA2";
            r1.addr = 0x28;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "One wire control register";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "ONE_WIRE_READ3";
            r1.addr = 0x29;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "One wire control register";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "ONE_WIRE_READ4";
            r1.addr = 0x2a;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "One wire control register";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            //r1 = new Mu2e_Register();
            //r1.name = "FLASH_GATE_TURN_ON_TIME";
            //r1.addr = 0x28;
            //r1.fpga_offset_mult = 0x400;
            //r1.comment = "A write to this address defines the time in the microbunch in steps of 6.28ns that the flash gate is asserted, that is when the SiPM voltage is lowered. The microbunch duration is 270 steps";
            //r1.bit_comment = new string[15];
            //list_of_reg.Add(r1);

            //r1 = new Mu2e_Register();
            //r1.name = "FLASH_GATE_TURN_OFF_TIME";
            //r1.addr = 0x29;
            //r1.fpga_offset_mult = 0x400;
            //r1.comment = "A write to this address defines the time in the microbunch in steps of 6.28ns that the flash gate is de-asserted.";
            //r1.bit_comment = new string[15];
            //list_of_reg.Add(r1);
            
            r1 = new Mu2e_Register();
            r1.name = "AFE_INPUT_FIFO_EMPTY_FLAG";
            r1.addr = 0x2F;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Shows the level of the empty flags of the 16 FIFOs used to buffer data destined for the DDR RAM.";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            for (int i = 0; i < 16; i++)
            {
                r1 = new Mu2e_Register();
                r1.name = "BIAS_DAC_CH" + i.ToString();
                r1.addr = (ushort)(0x30 + i);
                r1.fpga_offset_mult = 0x400;
                r1.comment = "12 bit DACs with a span of ±4.096V. Chan" + i.ToString();
                r1.bit_comment = new string[15];
                list_of_reg.Add(r1);
            }

            for (int i = 0; i < 4; i++)
            {
                r1 = new Mu2e_Register();
                r1.name = "LED_INTENSITY_DAC_CH" + i.ToString();
                r1.addr = (ushort)(0x40 + i);
                r1.fpga_offset_mult = 0x400;
                r1.comment = "Four 12 bit DACs with a span of 0..14V.  Addresses 0x40..0x43 Apply to CMB 1..4. Chan" + i.ToString();
                r1.bit_comment = new string[15];
                list_of_reg.Add(r1);
            }

            r1 = new Mu2e_Register();
            r1.name = "BIAS_BUS_DAC0";
            r1.addr = 0x44;
            r1.fpga_offset_mult = 0x0;
            r1.comment = "Two 12 bits DACs with a possible span of 0..80V. Address 0x44 applies to CMB1..2";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "BIAS_BUS_DAC1";
            r1.addr = 0x45;
            r1.fpga_offset_mult = 0x0;
            r1.comment = "Two 12 bits DACs with a possible span of 0..80V. Address 0x44 applies to CMB3..4";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "AFE_VGA0";
            r1.addr = 0x46;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Two 12 bits DACs with a span of 0..1.54V. Address 0x46 applies to AFE 0";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "AFE_VGA1";
            r1.addr = 0x47;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Two 12 bits DACs with a span of 0..1.54V. Address 0x46 applies to AFE 1";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            for (int i = 0; i < 7; i++)
            {
                r1 = new Mu2e_Register();
                r1.name = "SETUP_DAC_CH" + i.ToString();
                r1.addr = (ushort)(0x48 + i);
                r1.fpga_offset_mult = 0x400;
                r1.comment = "Dont' touch this. Chan" + i.ToString();
                r1.bit_comment = new string[15];
                list_of_reg.Add(r1);
            }

            r1 = new Mu2e_Register();
            r1.name = "SPILL_TRIG_COUNT";
            r1.addr = 0x67;
            r1.fpga_offset_mult = 0x0;
            r1.comment = "Reads the number of triggers received during the spill.";
            r1.bit_comment = new string[15];
            r1.width = 32;
            r1.upper_addr = 0x66;
            r1.lower_addr = 0x67;
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "SPILL_NUMBER";
            r1.addr = 0x68;
            r1.fpga_offset_mult = 0x0;
            r1.comment = "Increments once per spill. Use buffer reset to reset this counter.";
            r1.bit_comment = new string[15];
            r1.width = 16;
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "EVENT_WORD_COUNT";
            r1.addr = 0x69;
            r1.fpga_offset_mult = 0x0;
            r1.comment = "Increments once per spill. Use buffer reset to reset this counter.";
            r1.bit_comment = new string[15];
            r1.width = 16;
            list_of_reg.Add(r1); 
            
            r1 = new Mu2e_Register();
            r1.name = "SPILL_WORD_COUNT";
            r1.addr = 0x6B;
            r1.fpga_offset_mult = 0x0;
            r1.comment = "Read the word count from the most recent spill";
            r1.bit_comment = new string[15];
            r1.width = 32;
            r1.upper_addr = 0x6A;
            r1.lower_addr = 0x6B;
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "UPTIME";
            r1.addr = 0x6D;
            r1.fpga_offset_mult = 0x0;
            r1.comment = "A counter showing the number of seconds since the last FPGA reset";
            r1.bit_comment = new string[15];
            r1.width = 32;
            r1.upper_addr = 0x6C;
            r1.lower_addr = 0x6D;
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "TRIG_TIME_STAMP";
            r1.addr = 0x73;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "A 32 bit register showing the time stamp of the most recent trigger";
            r1.bit_comment = new string[15];
            r1.width = 32;
            r1.upper_addr = 0x72;
            r1.lower_addr = 0x73;
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "PULSER_TRIG_DELAY";
            r1.addr = 0x74;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "An eight bit value in steps of 6.28ns that specifies the delay between receipt of a pulser trigger command from the controller and the issuing of a test pulse to the CMB LEDs. The desire is to obviate the need for pipeline readjustment between data taking and pulser triggers.";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "SPILL_ERROR";
            r1.addr = 0x75;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x0;
            r1.comment = "Read the spill error register";
            r1.bit_comment = new string[15];
            r1.bit_comment[0] = "[0] One or more of the AFE FIFOs has overflowed";
            r1.bit_comment[1] = "[1] Event FIFO empty. This should be the case at the end of a spill.";
            r1.bit_comment[2] = "[2] Parity error on the command link from the controller to the TDC.";
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "SPILL_STATE";
            r1.addr = 0x76;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x0;
            r1.comment = "Read the spill state register";
            r1.bit_comment = new string[15];
            r1.bit_comment[0] = "[0] The DDR write sequencer is busy.";
            r1.bit_comment[1] = "[1] Spill End Flag.";
            r1.bit_comment[2] = "[2] Spill Gate.";
            list_of_reg.Add(r1);

///broadcast reg

            r1 = new Mu2e_Register();
            r1.name = "FLASH_GATE_CONTROL";
            r1.addr = 0x300;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Broadcast. Flash gate control.";
            r1.bit_comment = new string[15];
            r1.bit_comment[0] = "[0] Enable the flash gate.";
            r1.bit_comment[1] = "[1] Select the CMB pulse routing. 0: Flash Gate, 1: LED flasher.";
            r1.bit_comment[2] = "[2] LED Flasher signal source. 0: Test pulser, 1: Flash Gate.";
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "FLASH_GATE_TURN_ON";
            r1.addr = 0x301;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Broadcast. A write to this address defines the time in the microbunch in steps of 6.28ns that the flash gate is asserted, that is when the SiPM voltage is lowered. The microbunch duration is 270 steps";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "FLASH_GATE_TURN_OFF";
            r1.addr = 0x302;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Broadcast. A write to this address defines the time in the microbunch in steps of 6.28ns that the flash gate is de-asserted, that is when the SiPM voltage is raised.";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);
            
            r1 = new Mu2e_Register();
            r1.name = "TRIG_CONTROL";
            r1.addr = 0x303;
            r1.pref_hex = true;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Broadcast. Trigger control register.";
            r1.bit_comment = new string[15];
            r1.bit_comment[0] = "[0] Writing a ‘1’ to this bit position sends a software trigger.";
            r1.bit_comment[1] = "[1] Selects the trigger input type as a pulse or an FM data stream. The assumption is that a trigger pulse comes from the LEMO connector, the FM encoded trigger message comes from the RJ-45 connector. The microprocessor controls the multiplexer that routes either the LEMO or the RJ-45 signal to the trigger input on the FPGAs.";
            r1.bit_comment[2] = "[2] Trigger Inhibit. If trigger inhibit is enabled, this bit goes to one in response to a trigger";
            r1.bit_comment[3] = "[3] Trigger Inhibit enable.";
            r1.bit_comment[4] = "[4] Spill Inhibit. If spill inhibit is enabled, this bit goes to one in response to end of spill. Writing a ‘1’ to this position sets a request to clear the inhibit. Clear spill inhibit will wait until any spill in progress finishes before clearing and allow more triggers.";
            r1.bit_comment[5] = "[5] Clear spill inhibit."; 
            r1.bit_comment[6] = "[6] Spill Inhibit enable.";
            r1.bit_comment[7] = "[7] Not used.";
            r1.bit_comment[8] = "[8] Enable the on card test pulser.";
            r1.bit_comment[9] = "[9] Run the test pulser for one spill or continuously. 1: Run once 0: Run continuously";
            list_of_reg.Add(r1);
            
            
            r1 = new Mu2e_Register();
            r1.name = "HIT_DEL_REG";
            r1.addr = 0x304;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Broadcast. Specifies the number of pipeline stages the hit data traverses before being presented to the first level FIFO. This is used to compensate for trigger delays. The least count is 12.56 ns and the span is eight bits. The minimum delay setting is one and increases monotonically up to a setting of 255. ";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "NUM_SAMPLE_REG";
            r1.addr = 0x305;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Broadcast. Specifies the number ADC samples per trigger to record. 1..254 Samples.";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "TEST_PULSE_FREQ";
            r1.addr = 0x307;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Broadcast. Test Pulser frequency word. The rate is 0.0741 Hz per count.";
            r1.bit_comment = new string[15];
            r1.width = 32;
            r1.upper_addr = 0x306;
            r1.lower_addr = 0x307;
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "TEST_PULSE_DURATION";
            r1.addr = 0x308;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Broadcast. A write to this address defines the length of the internally generated spill in seconds.";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "TEST_PULSE_INTERSPILL";
            r1.addr = 0x309;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Broadcast. A write to this address defines the length of the internally generated gap between spills in seconds. This is only significant if the test pulser is set to run continuously.";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "COARSE_COUNT_INTI";
            r1.addr = 0x30a;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "A write to this address defines the lower eight bits of the initial count of the time stamp counter. This can be used to match the delay between receipt of a trigger at the controller and the FEB.";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);

            r1 = new Mu2e_Register();
            r1.name = "TEST_PULSE_DELAY";
            r1.addr = 0x30b;
            r1.fpga_offset_mult = 0x400;
            r1.comment = "Broadcast.A write to this address defines the delay in 6.28 ns clock ticks between receipt of a test pulse trigger from the controller and the firing of the trigger logic on the FEB";
            r1.bit_comment = new string[15];
            list_of_reg.Add(r1);


            //for (int i = 0; i < 59; i++)
            //{
            //    r1 = new Mu2e_Register();
            //    r1.name = "AFE0_REG_0x" + Convert.ToString(i, 16);
            //    r1.addr = (ushort)(0x100 + i);
            //    r1.pref_hex = true;
            //    r1.fpga_offset_mult = 0x400;
            //    r1.comment = "This space is mapped onto to the AFE5807 register map.." + i.ToString();
            //    r1.bit_comment = new string[15];
            //    list_of_reg.Add(r1);

            //    r1 = new Mu2e_Register();
            //    r1.name = "AFE1_REG_0x" + Convert.ToString(i, 16);
            //    r1.addr = (ushort)(0x200 + i);
            //    r1.pref_hex = true;
            //    r1.fpga_offset_mult = 0x400;
            //    r1.comment = "This space is mapped onto to the AFE5807 register map.." + i.ToString();
            //    r1.bit_comment = new string[15];
            //    list_of_reg.Add(r1);
            //}

        }

        public static void add_WC_reg(out List<Mu2e_Register> list_of_reg)
        {
            list_of_reg = new List<Mu2e_Register>(1);
            Mu2e_Register r1 = new Mu2e_Register();
            r1.name = "CSR";
            r1.addr = 0x00;
            r1.fpga_offset_mult = 0;
            r1.pref_hex = true;
            r1.comment = "Control and status register";
            r1.bit_comment = new string[15];
            
            list_of_reg.Add(r1);
        }
    }

    
    public class Mu2e_Register
    {
        public delegate double Conv_to_Double(UInt32 val);
        public delegate UInt32 Conv_from_Double(double v);
        public string name;
        public string comment;
        public string[] bit_comment;
        public UInt16 addr;
        public UInt16 fpga_offset_mult=0x400;
        public UInt16 fpga_index=0;
        public uint width = 16;
        public UInt16 upper_addr;
        public UInt16 lower_addr;
        public UInt32 prev_val = 0;
        public UInt32 val = 0;
        public double dv = 0;
        public bool pref_hex = false;
        public bool pref_double = false;
        public Conv_to_Double myUint2Double = Simple_Conv2Double;
        public enum RegError { Unknown, Timeout }


        public static bool FindName(string reg_name, ref List<Mu2e_Register> reg_list, out Mu2e_Register reg)
        {
            reg = null;
            foreach (Mu2e_Register r in reg_list)
            {
                if (r.name == reg_name)
                { reg = r; return true; }
            }
            { return false; }
            {

            }
        }

        public static bool FindAddr(UInt16 reg_addr, ref List<Mu2e_Register> reg_list, out Mu2e_Register reg)
        {
            reg = null;
            foreach (Mu2e_Register r in reg_list)
            {
                if (r.addr == reg_addr)
                { reg = r; return true; }
            }
            { return false; }
            {

            }
        }

        public static void ReadReg(ref Mu2e_Register reg, ref TcpClient myClient)
        {
            ushort addr = (ushort)(reg.addr + (reg.fpga_index * reg.fpga_offset_mult));
            ushort upper_addr = (ushort)(reg.upper_addr + (reg.fpga_index * reg.fpga_offset_mult));
            ushort lower_addr = (ushort)(reg.lower_addr + (reg.fpga_index * reg.fpga_offset_mult));
            try
            {
                if (myClient.Connected)
                {
                    NetworkStream TNETStream = myClient.GetStream();
                    //StreamWriter SW = new StreamWriter(TNETStream);
                    //StreamReader SR = new StreamReader(TNETStream);
                    if (reg.width <= 16)
                    {
                        string lin = "rd " + Convert.ToString(addr, 16) + "\r\n";
                        byte[] buf = PP.GetBytes(lin);
                        TNETStream.Write(buf, 0, buf.Length);

                        System.Threading.Thread.Sleep(5);
                        if (myClient.Available > 0)
                        {
                            byte[] rec_buf = new byte[myClient.Available];
                            Thread.Sleep(1);
                            int ret_len = TNETStream.Read(rec_buf, 0, rec_buf.Length);
                            reg.prev_val = reg.val;
                            UInt32 t; double dv;
                            BufVal(rec_buf, out t, out dv);
                            reg.val = t;
                            reg.dv = dv;
                        }
                        else
                        { }
                    }
                    else if (reg.width > 16)
                    {
                        string lin = "rd " + Convert.ToString(upper_addr, 16) + "\r\n";
                        byte[] buf = PP.GetBytes(lin);
                        TNETStream.Write(buf, 0, buf.Length);
                        System.Threading.Thread.Sleep(10);
                        UInt32[] tv = new UInt32[2];
                        if (myClient.Available > 0)
                        {
                            byte[] rec_buf = new byte[myClient.Available];
                            Thread.Sleep(1);
                            int ret_len = TNETStream.Read(rec_buf, 0, rec_buf.Length);
                            reg.prev_val = reg.val;
                            UInt32 t; double dv;
                            BufVal(rec_buf, out t, out dv);
                            tv[0] = t;
                        }
                        lin = "rd " + Convert.ToString(lower_addr, 16) + "\r\n";
                        buf = PP.GetBytes(lin);
                        TNETStream.Write(buf, 0, buf.Length);
                        System.Threading.Thread.Sleep(10);

                        if (myClient.Available > 0)
                        {
                            byte[] rec_buf = new byte[myClient.Available];
                            Thread.Sleep(1);
                            int ret_len = TNETStream.Read(rec_buf, 0, rec_buf.Length);
                            reg.prev_val = reg.val;
                            UInt32 t; double dv;
                            BufVal(rec_buf, out t, out dv);
                            tv[1] = t;
                        }

                        reg.val = (tv[0] * 256*256) + tv[1];
                    }
                }
                else { }
            }
            catch { }
        }

        public static void WriteReg(UInt32 v, ref Mu2e_Register reg, ref TcpClient myClient)
        {
            ushort addr = (ushort)(reg.addr + (reg.fpga_index * reg.fpga_offset_mult));
            ushort upper_addr = (ushort)(reg.upper_addr + (reg.fpga_index * reg.fpga_offset_mult));
            ushort lower_addr = (ushort)(reg.lower_addr + (reg.fpga_index * reg.fpga_offset_mult));
            if (myClient.Connected)
            {
                NetworkStream TNETStream = myClient.GetStream();
                //StreamWriter SW = new StreamWriter(TNETStream);
                //StreamReader SR = new StreamReader(TNETStream);
                if (reg.width <= 16)
                {
                    if (v >= Math.Pow(2, 16)) { Exception e = new Exception("write val greater than possible"); throw e; }
                    string sv = Convert.ToString(v, 16);
                    string lout = "wr " + Convert.ToString(addr, 16) + " " + sv+ "\r\n";
                    byte[] buf = PP.GetBytes(lout);
                    TNETStream.Write(buf, 0, buf.Length);

                    System.Threading.Thread.Sleep(5);
                    
                }
                else if (reg.width > 16)
                {
                    //if (v >= Math.Pow(2, 16)) !stupid! what if we want to write a zero?
                    {
                        uint vu = v % (uint)(Math.Pow(2, 16));
                        string sv = Convert.ToString(vu, 16);
                        string lout = "wr " + Convert.ToString(upper_addr, 16) + " " + sv + "\r\n";
                        byte[] buf = PP.GetBytes(lout);
                        TNETStream.Write(buf, 0, buf.Length);
                    }
                    //else
                    {
                        string sv = "0";
                        string lout = "wr " + Convert.ToString(upper_addr, 16) + " " + sv + "\r\n";
                        byte[] buf = PP.GetBytes(lout);
                        TNETStream.Write(buf, 0, buf.Length);
                    }

                    System.Threading.Thread.Sleep(5);
                    {
                        uint vl = v & (uint)(0xffff);
                        string sv = Convert.ToString(vl, 16);
                        string lout = "wr " + Convert.ToString(lower_addr, 16) + " " + sv + "\r\n";
                        byte[] buf = PP.GetBytes(lout);
                        TNETStream.Write(buf, 0, buf.Length);
                    }
                }
                reg.val = v;
            }
            else { Exception e = new Exception("can't scan without a connected FEB client"); throw (e); }

        }

        #region helpers
        private static void BufVal(byte[] rec_buf, out UInt32 v, out double dv)
        {
            v = 0;
            dv = 0;
            int len = rec_buf.Length;
            char[] chars = new char[len];
            for (int i = 0; i < len; i++)
            {
                chars[i] = (char)rec_buf[i];
            }
            string t = new string(chars);
            char[] sep = new char[3];
            sep[0] = ' ';
            sep[1] = '\r';
            sep[2] = '\n';
            string[] tok = t.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            try { v = Convert.ToUInt32(tok[0],16); }
            catch { v = 0; }
            //catch { adc = -1; }
            //double adc;
            //try { adc = Convert.ToDouble(tok[10]); }
            //catch { adc = -1; }
            //if (adc > 4.096) { adc = 8.192 - adc; }
            //double I = adc / 8 * 250;
            //for (int i = 0; i < tok.Length; i++)
        }

        private static double Simple_Conv2Double(UInt32 v)
        { return Convert.ToDouble(v); }

       
        private static double Adc2Volts(UInt32 v)
        {
            double adc;
            try { adc = Convert.ToDouble(v); }
            catch { adc = -1; }
            if (adc > 4.096) { adc = 8.192 - adc; }
            double I = adc ;
            return I;
        }

        private static double Adc2microA(UInt32 v)
        {
            double adc;
            try { adc = Convert.ToDouble(v); }
            catch { adc = -1; }
            if (adc > 4.096) { adc = 8.192 - adc; }
            double I = adc / 8 * 250;
            return I;
        }
        #endregion helpers
    }

}
