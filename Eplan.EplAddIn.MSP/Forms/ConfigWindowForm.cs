using System;
using System.Windows.Forms;

namespace Eplan.EplAddIn.MSP
{
    /// <summary>
    /// This class represents the configuration window form for the Motor Starter with Protection Add-In.
    /// </summary>
    public partial class ConfigWindowForm : Form
    {
        // Result scheme builder
        private EplMspBuilder mspBuilder = new EplMspBuilder();

        /// <summary>
        /// Constructor
        /// </summary>
        public ConfigWindowForm()
        {
            // Initialize the form components.
            InitializeComponent();

            protectionTypeComboBox.Items.AddRange(mspBuilder.ProtectionTypes);
            orderNumberComboBox.Items.AddRange(mspBuilder.OrderNumbers);
            startTypeComboBox.Items.AddRange(mspBuilder.StartTypes);

            clampsCheckBox.Checked = true;
            protectionTypeComboBox.SelectedIndex = 0;
            orderNumberComboBox.SelectedIndex = 0;
            startTypeComboBox.SelectedIndex = 0;
            protectionValueTextBox.Text = "1";
            motorPowerTextBox.Text = "1";
        }

        /// <summary>
        /// "Generate" button click.
        /// </summary>
        private void generateButton_Click(object sender, EventArgs e)
        {
            // Build Motor Starter Circuit with Protection Devices 
            if (mspBuilder.BuidMotorStarterCircuitWithProtectionDevices(protectionTypeComboBox.Text,
                                                                        protectionValueTextBox.Text,
                                                                        orderNumberComboBox.Text,
                                                                        startTypeComboBox.Text,
                                                                        clampsCheckBox.Checked,
                                                                        motorPowerTextBox.Text))
            {
                // If the circuit is successfully built, close the configuration window.
                Close();
            }
        }

        /// <summary>
        /// "Cancel" button click
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Check values of ProtectionTypeComboBox
        /// </summary>
        private void protectionTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (protectionTypeComboBox.SelectedIndex == 0)
                orderNumberComboBox.Enabled = true;
            else
                orderNumberComboBox.Enabled = false;
        }
    }
}

