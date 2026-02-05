using System;
using System.Windows.Forms;


namespace ShellyPowerManager
{
    public partial class FormShellyPowerManager : Form
    {

        private string ASCOM_Driver_Name = "ASCOM.ShellyRelayController.Switch";

        private ASCOM.DriverAccess.Switch driver;

        public FormShellyPowerManager()
        {
            InitializeComponent();
            try
            {
                driver = new ASCOM.DriverAccess.Switch(ASCOM_Driver_Name);
                driver.Connected = true;
                if (driver.Connected)
                    InitializeForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to Shelly Relay Controller: " + ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SetUIState();
        }

        private void FormShellyPowerManager_Form(object sender, FormClosingEventArgs e)
        {
            if (IsConnected(1))
                driver.Connected = false;
            Properties.Settings.Default.Save();
        }

        private void SetUIState()
        {

        }

        private bool IsConnected(int deviceNumber)
        {
            return (this.driver != null) && (driver.Connected == true);
        }

        private void InitializeForm()
        {
            PowerButton0.Enabled = false;
            PowerButton1.Enabled = false;
            PowerButton2.Enabled = false;
            PowerButton3.Enabled = false;
            PowerButton4.Enabled = false;
            PowerButton5.Enabled = false;
            PowerButton6.Enabled = false;
            PowerButton7.Enabled = false;

            if (driver == null)
                return;

            LoadPresets();

            LightThemUp();

        }

        private void LightThemUp()
        {
            int maxSwitchNumber = driver.MaxSwitch;
            if (maxSwitchNumber > 0)
            {
                PowerButton0.Enabled = true;
                PowerButton0.Text = driver.GetSwitchName(0);
                PowerButton0.BackColor = driver.GetSwitch(0) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            }
            if (maxSwitchNumber > 1)
            {
                PowerButton1.Enabled = true;
                PowerButton1.Text = driver.GetSwitchName(1);
                PowerButton1.BackColor = driver.GetSwitch(1) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            }
            if (maxSwitchNumber > 2)
            {
                PowerButton2.Enabled = true;
                PowerButton2.Text = driver.GetSwitchName(2);
                PowerButton2.BackColor = driver.GetSwitch(2) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            }
            if (maxSwitchNumber > 3)
            {
                PowerButton3.Enabled = true;
                PowerButton3.Text = driver.GetSwitchName(3);
                PowerButton3.BackColor = driver.GetSwitch(3) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            }
            if (maxSwitchNumber > 4)
            {
                PowerButton4.Enabled = true;
                PowerButton4.Text = driver.GetSwitchName(4);
                PowerButton4.BackColor = driver.GetSwitch(4) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            }

            if (maxSwitchNumber > 5)
            {
                PowerButton5.Enabled = true;
                PowerButton5.Text = driver.GetSwitchName(5);
                PowerButton5.BackColor = driver.GetSwitch(5) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            }
            if (maxSwitchNumber > 6)
            {
                PowerButton6.Enabled = true;
                PowerButton6.Text = driver.GetSwitchName(6);
                PowerButton6.BackColor = driver.GetSwitch(6) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            }
            if (maxSwitchNumber > 7)
            {
                PowerButton7.Enabled = true;
                PowerButton7.Text = driver.GetSwitchName(7);
                PowerButton7.BackColor = driver.GetSwitch(7) ? System.Drawing.Color.Red : System.Drawing.Color.Green;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConfigureButton_Click(object sender, EventArgs e)
        {
            string id = ASCOM.DriverAccess.Switch.Choose(ASCOM_Driver_Name);

            // Exit if no device was selected
            if (string.IsNullOrEmpty(id))
                return;
            // Create this device
            ASCOM.DriverAccess.Switch device = new ASCOM.DriverAccess.Switch(id);
            // Connect to the device
            device.Connected = true;
            LightThemUp();
        }

        private void AllOnButton_Click(object sender, EventArgs e)
        {
            bool switchState = true;
            for (short i = 0; i < driver.MaxSwitch; i++)
            {
                driver.SetSwitch(i, switchState);
            }
            LightThemUp();
        }

        private void AllOFfButton_Click(object sender, EventArgs e)
        {
            bool switchState = false;
            for (short i = 0; i < driver.MaxSwitch; i++)
            {
                driver.SetSwitch(i, switchState);
            }
            LightThemUp();
        }

        #region power buttons

        private void PowerButton0_Click(object sender, EventArgs e)
        {
            //Toggle switch
            driver.SetSwitch(0, !driver.GetSwitch(0));
            LightThemUp();
        }

        private void PowerButton1_Click(object sender, EventArgs e)
        {
            //Toggle switch
            driver.SetSwitch(1, !driver.GetSwitch(1));
            LightThemUp();
        }

        private void PowerButton2_Click(object sender, EventArgs e)
        {
            //Toggle switch
            driver.SetSwitch(2, !driver.GetSwitch(2));
            LightThemUp();
        }

        private void PowerButton3_Click(object sender, EventArgs e)
        {
            //Toggle switch
            driver.SetSwitch(3, !driver.GetSwitch(3));
            LightThemUp();
        }

        private void PowerButton4_Click(object sender, EventArgs e)
        {
            //Toggle switch
            driver.SetSwitch(4, !driver.GetSwitch(4));
            LightThemUp();
        }

        private void PowerButton5_Click(object sender, EventArgs e)
        {
            //Toggle switch
            driver.SetSwitch(5, !driver.GetSwitch(5));
            LightThemUp();
        }

        private void PowerButton6_Click(object sender, EventArgs e)
        {
            //Toggle switch
            driver.SetSwitch(6, !driver.GetSwitch(6));
            LightThemUp();
        }

        private void PowerButton7_Click(object sender, EventArgs e)
        {
            //Toggle switch
            driver.SetSwitch(7, !driver.GetSwitch(7));
            LightThemUp();
        }

        #endregion

        #region presets

        private void LoadPresets()
        {
            StandbyCheckbox0.Checked = Properties.Settings.Default.PB0;
            StandbyCheckbox1.Checked = Properties.Settings.Default.PB1;
            StandbyCheckbox2.Checked = Properties.Settings.Default.PB2;
            StandbyCheckbox3.Checked = Properties.Settings.Default.PB3;
            StandbyCheckbox4.Checked = Properties.Settings.Default.PB4;
            StandbyCheckbox5.Checked = Properties.Settings.Default.PB5;
            StandbyCheckbox6.Checked = Properties.Settings.Default.PB6;
            StandbyCheckbox7.Checked = Properties.Settings.Default.PB7;
        }

        private void StandbyCheckbox0_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PB0 = StandbyCheckbox0.Checked;
        }

        private void StandbyCheckbox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PB1 = StandbyCheckbox1.Checked;
        }

        private void StandbyCheckbox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PB2 = StandbyCheckbox2.Checked;
        }

        private void StandbyCheckbox3_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PB3 = StandbyCheckbox3.Checked;
        }

        private void StandbyCheckbox4_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PB4 = StandbyCheckbox4.Checked;
        }

        private void StandbyCheckbox5_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PB5 = StandbyCheckbox5.Checked;
        }

        private void StandbyCheckbox6_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PB6 = StandbyCheckbox6.Checked;
        }

        private void StandbyCheckbox7_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.PB7 = StandbyCheckbox7.Checked;
        }

        private void PresetButton_Click(object sender, EventArgs e)
        {
            if (driver.MaxSwitch > 0)
                driver.SetSwitch(0, StandbyCheckbox0.Checked);
            if (driver.MaxSwitch > 1)
                driver.SetSwitch(1, StandbyCheckbox1.Checked);
            if (driver.MaxSwitch > 2)
                driver.SetSwitch(2, StandbyCheckbox2.Checked);
            if (driver.MaxSwitch > 3)
                driver.SetSwitch(3, StandbyCheckbox3.Checked);
            if (driver.MaxSwitch > 4)
                driver.SetSwitch(4, StandbyCheckbox4.Checked);
            if (driver.MaxSwitch > 5)
                driver.SetSwitch(5, StandbyCheckbox5.Checked);
            if (driver.MaxSwitch > 6)
                driver.SetSwitch(6, StandbyCheckbox6.Checked);
            if (driver.MaxSwitch > 7)
                driver.SetSwitch(7, StandbyCheckbox7.Checked);

            LightThemUp();

        }
        #endregion

    }
}
