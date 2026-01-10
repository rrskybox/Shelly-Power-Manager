using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShellyPowerManager
{
    public partial class FormSwitchNames : Form
    {
        private ASCOM.DriverAccess.Switch local_driver1;
        private ASCOM.DriverAccess.Switch local_driver2;

        public FormSwitchNames(ASCOM.DriverAccess.Switch driver1, ASCOM.DriverAccess.Switch driver2)
        {
            InitializeComponent();
            local_driver1 = driver1;
            local_driver2 = driver2;
            if (!(driver1 == null) && driver1.Connected)
            {
                int relayCount = driver1.MaxSwitch;
                if (relayCount >= 1) SwitchBox1.Text = driver1.GetSwitchName(0);
                if (relayCount >= 2) SwitchBox2.Text = driver1.GetSwitchName(1);
                if (relayCount >= 3) SwitchBox3.Text = driver1.GetSwitchName(2);
                if (relayCount >= 4) SwitchBox4.Text = driver1.GetSwitchName(3);
            }
            if (!(driver2 == null) && driver2.Connected)
            {
                int relayCount = driver2.MaxSwitch;
                if (relayCount >= 1) SwitchBox5.Text = driver2.GetSwitchName(0);
                if (relayCount >= 2) SwitchBox6.Text = driver2.GetSwitchName(1);
                if (relayCount >= 3) SwitchBox7.Text = driver2.GetSwitchName(2);
                if (relayCount >= 4) SwitchBox8.Text = driver2.GetSwitchName(3);
            }
        }

        private void SaveNamesButton_Click(object sender, EventArgs e)
        {
            if (!(local_driver1 == null) && local_driver1.Connected)
            {
                int relayCount = local_driver1.MaxSwitch;
                if (relayCount >= 1) local_driver1.SetSwitchName(0, SwitchBox1.Text);
                if (relayCount >= 2) local_driver1.SetSwitchName(1, SwitchBox2.Text);
                if (relayCount >= 3) local_driver1.SetSwitchName(2, SwitchBox3.Text);
                if (relayCount >= 4) local_driver1.SetSwitchName(3, SwitchBox4.Text);
            }
            if (!(local_driver2 == null) && local_driver2.Connected)
            {
                int relayCount = local_driver2.MaxSwitch;
                if (relayCount >= 1) local_driver1.SetSwitchName(0, SwitchBox5.Text);
                if (relayCount >= 2) local_driver1.SetSwitchName(1, SwitchBox6.Text);
                if (relayCount >= 3) local_driver1.SetSwitchName(2, SwitchBox7.Text);
                if (relayCount >= 4) local_driver1.SetSwitchName(3, SwitchBox8.Text);
            }
            this.Close();
        }
    }
}
