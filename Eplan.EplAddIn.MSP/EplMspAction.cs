using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eplan.EplApi.ApplicationFramework;

namespace Eplan.EplAddIn.MSP
{
    /// <summary>
    /// Represents the action to open the configuration window for the Motor Starter with Protection Add-In.
    /// </summary>
    public class EplMspAction : IEplAction
    {
        /// <summary>
        /// Executes the action to open the configuration window.
        /// </summary>
        /// <param name="ctx">The ActionCallingContext object containing context information.</param>
        /// <returns>True if the action was executed successfully, otherwise false.</returns>
        public bool Execute(ActionCallingContext ctx)
        {
            // Create and display the configuration window form
            ConfigWindowForm configWindow = new ConfigWindowForm();
            configWindow.ShowDialog();
            return true;
        }

        /// <summary>
        /// Registers the action with Eplan.
        /// </summary>
        /// <param name="Name">The name of the action.</param>
        /// <param name="Ordinal">The ordinal value of the action.</param>
        /// <returns>True if the action registration was successful, otherwise false.</returns>
        public bool OnRegister(ref string Name, ref int Ordinal)
        {
            // Set the name and ordinal of the action
            Name = "EplMspAction";
            Ordinal = 0;
            return true;
        }

        /// <summary>
        /// Retrieves the action properties.
        /// </summary>
        /// <param name="actionProperties">The ActionProperties object to be populated with action properties.</param>
        public void GetActionProperties(ref ActionProperties actionProperties)
        {
            // This method is not currently implemented, reserved for future development
        }
    }
}
