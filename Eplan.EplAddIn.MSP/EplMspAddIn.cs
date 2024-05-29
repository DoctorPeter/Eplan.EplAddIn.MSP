using System.Drawing;
using System.IO;
using System.Reflection;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Gui;

namespace EplMspAddIn
{
    /// <summary>
    /// Represents the Eplan Motor Starter Circuit With Protection Add-In.
    /// </summary>
    public class EplMspAddIn : IEplAddIn
    {
        /// <summary>
        /// Method called when Eplan exits.
        /// </summary>
        /// <returns>True if the method was executed successfully, otherwise false.</returns>
        public bool OnExit()
        {
            return true;
        }

        /// <summary>
        /// Method called during initialization.
        /// </summary>
        /// <returns>True if the method was executed successfully, otherwise false.</returns>
        public bool OnInit()
        {
            return true;
        }

        /// <summary>
        /// Method called during GUI initialization.
        /// </summary>
        /// <returns>True if the method was executed successfully, otherwise false.</returns>
        public bool OnInitGui()
        {
            return true;
        }

        /// <summary>
        /// Method called during add-in registration.
        /// </summary>
        /// <param name="bLoadOnStart">A boolean value indicating whether the add-in should be loaded on Eplan startup.</param>
        /// <returns>True if the method was executed successfully, otherwise false.</returns>
        public bool OnRegister(ref bool bLoadOnStart)
        {
            // Create a new RibbonBar instance.
            RibbonBar ribbonBar = new RibbonBar();

            // Add a command to the RibbonBar with the specified text, identifier, and icon.
            ribbonBar.AddCommand("Motor Starter with Protection", "EplMspAction", CommandIcon.Motor);

            // Set bLoadOnStart to true to load the add-in on Eplan startup.
            bLoadOnStart = true;

            return true;
        }

        /// <summary>
        /// Method called during add-in unregistration.
        /// </summary>
        /// <returns>True if the method was executed successfully, otherwise false.</returns>
        public bool OnUnregister()
        {
            // Create a new RibbonBar instance.
            RibbonBar ribbonBar = new RibbonBar();

            // Remove the command with the specified identifier from the RibbonBar.
            return ribbonBar.RemoveCommand("EplMspAction");
        }
    }
}

