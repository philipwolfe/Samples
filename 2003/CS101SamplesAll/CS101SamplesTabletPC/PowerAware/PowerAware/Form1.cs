using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PowerAware
{
    public partial class Form1 : Form
    {
        ManagedPower myManagedPower = new ManagedPower();

        public Form1()
        {
            InitializeComponent();

            //Set label1 to initial status
            label1.Text = myManagedPower.ToString();

            //Check the power status every time the timer "ticks" (3 seconds by default)
            timer1.Tick += delegate(object sender, EventArgs e)
            {
                label1.Text = myManagedPower.ToString();
            };
        }
    }

    /// <summary>
    /// This class contains the definitions of the unmanaged methods,
    /// structs and enums that will be used in the call to the 
    /// unmanaged power API.
    /// </summary>
    public class ManagedPower
    {
        // GetSystemPowerStatus() is the only unmanaged API called.
        [DllImport("kernel32")]
        internal static extern bool GetSystemPowerStatus(out SystemPowerStatus sps);

        public override string ToString()
        {
            string text = "";
            SystemPowerStatus sysPowerStatus;
			// Get the power status of the system
			if (ManagedPower.GetSystemPowerStatus(out sysPowerStatus))
			{
				// Current power source - AC/DC
				_ACLineStatus currentPowerStatus = sysPowerStatus.ACLineStatus;
				text += "Power source: " + sysPowerStatus.ACLineStatus.ToString() + "\n";

				// Current power status
				text += "Power status: ";

				// Check for unknown
				if (sysPowerStatus.BatteryFlag == ManagedPower._BatteryFlag.Unknown)
				{
					text += "Unknown";
				}
				else
				{
					// Check if currently charging
					bool fCharging = (ManagedPower._BatteryFlag.Charging ==
						(sysPowerStatus.BatteryFlag & ManagedPower._BatteryFlag.Charging));

					if (fCharging)
					{
						sysPowerStatus.BatteryFlag -= ManagedPower._BatteryFlag.Charging;
					}

					// Print out power level
					// If the power is not High, Low, or Critical, report it as "Medium".
					string currentPowerLevel = (sysPowerStatus.BatteryFlag != 0 ?
						sysPowerStatus.BatteryFlag.ToString() :
								"Medium");
					text += currentPowerLevel;

					// Print out charging status
					if (fCharging)
					{
						string currentChargingStatus = ManagedPower._BatteryFlag.Charging.ToString();
						text += " (" + ManagedPower._BatteryFlag.Charging.ToString() + ") ";
					}
				}

				// Finally print the percentage of the battery life remaining.
				byte currentBatteryPercentage = sysPowerStatus.BatteryLifePercent;
				text += "\nBattery life remaining is " +
						sysPowerStatus.BatteryLifePercent.ToString() + "%";
			}
            return text;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SystemPowerStatus
        {
            public _ACLineStatus ACLineStatus;
            public _BatteryFlag BatteryFlag;
            public byte BatteryLifePercent;
            public byte Reserved1;
            public uint BatteryLifeTime;
            public uint BatteryFullLifeTime;
        }

        public enum _ACLineStatus : byte
        {
            Battery = 0,
            AC = 1,
            Unknown = 255
        }

        internal enum _BatteryFlag : byte
        {
            High = 1,
            Low = 2,
            Critical = 4,
            Charging = 8,
            NoSystemBattery = 128,
            Unknown = 255
        }
    }
}