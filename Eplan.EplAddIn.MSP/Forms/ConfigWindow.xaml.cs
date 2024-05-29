using System;
using System.Windows;
using System.Windows.Controls;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.HEServices;

namespace Eplan.EplAddIn.MSP
{
    /// <summary>
    /// This class represents the configuration window form for the Motor Starter with Protection Add-In.
    /// </summary>
    public partial class ConfigWindow : Window
    {
        // Array of available protection types.
        public string[] ProtectionTypes { get; private set; } = null;

        // Array of available order numbers.
        public string[] OrderNumbers { get; private set; } = null;

        // Array of available start types.
        public string[] StartTypes { get; private set; } = null;

        // Result scheme builder
        private EplMspBuilder mspBuilder = new EplMspBuilder();


        /// <summary>
        /// Constructor
        /// </summary>
        public ConfigWindow()
        {
            ProtectionTypes = mspBuilder.ProtectionTypes;
            OrderNumbers = mspBuilder.OrderNumbers;
            StartTypes = mspBuilder.StartTypes;

            InitializeComponent();
            DataContext = this;

            clampsCheckBox.IsChecked = true;
            protectionTypeComboBox.SelectedIndex = 0;
            orderNumberComboBox.SelectedIndex = 0;
            startTypeComboBox.SelectedIndex = 0;
            protectionValueTextBox.Text = "1";
            motorPowerTextBox.Text = "1";
        }

        /// <summary>
        /// "Generate" button click.
        /// </summary>
        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            // Build Motor Starter Circuit with Protection Devices 
            if (mspBuilder.BuidMotorStarterCircuitWithProtectionDevices(protectionTypeComboBox.Text,
                                                                        protectionValueTextBox.Text,
                                                                        orderNumberComboBox.Text,
                                                                        startTypeComboBox.Text,
                                                                        clampsCheckBox.IsChecked.Value,
                                                                        motorPowerTextBox.Text))
            {
                Close();
            }
        }

        /// <summary>
        /// "Cancel" button click
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Check values of ProtectionTypeComboBox
        /// </summary>
        private void ProtectionTypeComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (protectionTypeComboBox.SelectedIndex == 0)
                orderNumberComboBox.IsEnabled = true;
            else
                orderNumberComboBox.IsEnabled = false;
        }
    }
}
