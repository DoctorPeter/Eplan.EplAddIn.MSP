using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Globalization;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.DataModel;
using Eplan.EplApi.DataModel.MasterData;
using Eplan.EplApi.HEServices;
using Eplan.EplApi.Base;
using Eplan.EplApi.DataModel.EObjects;
using Eplan.EplApi.DataModel.Graphics;

namespace Eplan.EplAddIn.MSP
{
    /// <summary>
    /// Buider for Motor Starter Circuit with Protection Devices
    /// </summary>
    public class EplMspBuilder
    {
        #region Properties

        // Array of available protection types.
        public string[] ProtectionTypes { get; private set; } = new string[] { "Автоматический выключатель", "Предохранители" };

        // Array of available order numbers.
        public string[] OrderNumbers { get; private set; } = new string[] { "3RV1021-4AA15", "3RV1021-1JA15", "3RV1021-1GA15" };

        // Array of available start types.
        public string[] StartTypes { get; private set; } = new string[] { "DOL", "RDOL" };


        // Project manager
        private ProjectManager projectManager = new ProjectManager();

        /// <summary>
        /// Current project
        /// </summary>
        private Project CurrentProject
        {
            get
            {
                return projectManager.CurrentProject;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public EplMspBuilder()
        {
            // For future developemnt
        }

        #endregion

        #region Build

        /// <summary>
        /// Builds a Motor Starter Circuit with Protection Devices
        /// </summary>
        /// <param name="protectionType">Type of protection device</param>
        /// <param name="protectionValueText">Protection setting value</param>
        /// <param name="orderNumber">Order number of the device</param>
        /// <param name="startType">Type of motor start</param>
        /// <param name="clamps">Whether clamps are needed</param>
        /// <param name="motorPowerText">Nominal power of the motor</param>
        /// <returns>TRUE - if success</returns>
        public bool BuidMotorStarterCircuitWithProtectionDevices(string protectionType,
                                                                 string protectionValueText,
                                                                 string orderNumber,
                                                                 string startType,
                                                                 bool clamps,
                                                                 string motorPowerText)
        {
            Page resultPage = null;
            bool result = false;


            try
            {
                // Validate input values
                if (!double.TryParse(protectionValueText, NumberStyles.Any, CultureInfo.InvariantCulture, out double protectionValue))
                {
                    MessageBox.Show("\"Уставка защиты\" должна быть числовым значением.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return result;
                }

                if (!double.TryParse(motorPowerText, NumberStyles.Any, CultureInfo.InvariantCulture, out double motorPower))
                {
                    MessageBox.Show("\"Мотор Ном. мощность\" должна быть числовым значением.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return result;
                }
                                           
                // Check current project
                if (CurrentProject == null)
                {
                    MessageBox.Show("Нет текущего проекта!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return result;
                }

                // Load page template
                resultPage = LoadPageTemplate();

                if (resultPage == null)
                {
                    MessageBox.Show("Ошибка создания новой страницы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return result;
                }
                
                // Tune up protection type
                if (!TuneUpProtectionType(resultPage, protectionType, protectionValueText, orderNumber))
                {
                    MessageBox.Show("Ошибка настройки параметров защиты!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return result;
                }

                // Tune up start type
                if (!TuneUpStartType(resultPage, startType))
                {
                    MessageBox.Show("Ошибка настройки типа пуска!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return result;
                }

                // Tune up clamps
                if (!TuneUpСlamps(resultPage, clamps))
                {
                    MessageBox.Show("Ошибка настройки клем!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return result;
                }

                // Tune up motor power
                if (!TuneUpMotorPower(resultPage, motorPowerText))
                {
                    MessageBox.Show("Ошибка настройки номинальной мощности мотора!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return result;
                }

                result = true;
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка текущей надстройки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                result = false;
                return result;
            }
            finally
            {
                // Remove created page if error occured
                if ((!result) && (resultPage != null))
                    resultPage.Remove();
            }
        }

        #endregion

        #region Tune-up

        /// <summary>
        /// Tune up protection type
        /// </summary>
        /// <param name="page">EPLAN poject page</param>
        /// <param name="protectionType">protection type value</param>
        /// <param name="protectionValueText">protection value as string</param>
        /// <param name="orderNumber">article number</param>
        /// <returns>TRUE - if success</returns>
        private bool TuneUpProtectionType(Page page, string protectionType, string protectionValueText, string orderNumber)
        {
            try
            {
                // Find functions
                Function autoCircuitBreaker = FindFunction(page, "=+-Q1");
                Function safetyCatch = FindFunction(page, "=+-F1");

                // Check protection type
                if (protectionType == ProtectionTypes[0])
                {
                    safetyCatch.RemoveFromPage();

                    // Tune up auto circuit breaker
                    autoCircuitBreaker.Properties.FUNC_TECHNICAL_CHARACTERISTIC.Set("In=" + protectionValueText + "A");

                    foreach (ArticleReference articleReference in autoCircuitBreaker.ArticleReferences)
                        articleReference.RemoveArticleReference();

                    autoCircuitBreaker.AddArticleReference(orderNumber, "1", 1);
                }
                else
                {
                    // Tune up safety catch
                    safetyCatch.Location = new PointD(autoCircuitBreaker.Location.X, autoCircuitBreaker.Location.Y);
                    safetyCatch.Properties.FUNC_TECHNICAL_CHARACTERISTIC.Set("In=" + protectionValueText + "A");
                    autoCircuitBreaker.RemoveFromPage();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Tune up start type
        /// </summary>
        /// <param name="page">EPLAN poject page</param>
        /// <param name="startType">type of motor start</param>
        /// <returns>TRUE - if success</returns>
        private bool TuneUpStartType(Page page, string startType)
        {
            try
            {
                // Get functions
                Function dolStarter = FindFunction(page, "=+-?K1");
                Function rdolStarter1 = FindFunction(page, "=+-?K2");
                Function rdolStarter2 = FindFunction(page, "=+-?K3");

                // Get symbol references
                List<SymbolReference> coList = new List<SymbolReference>();
                List<SymbolReference> tourList = new List<SymbolReference>();

                foreach (Placement placement in page.AllFirstLevelPlacements)
                {
                    if (placement is SymbolReference)
                    {
                        SymbolReference symbolReference = placement as SymbolReference;

                        if (symbolReference.SymbolVariant.SymbolName == "CO")
                            coList.Add(symbolReference);
                        else
                        if (symbolReference.SymbolVariant.SymbolName == "TOUR")
                            tourList.Add(symbolReference);
                    }
                }

                if (startType == StartTypes[0])
                {
                    // Tune up for DOL
                    rdolStarter1.RemoveFromPage();
                    rdolStarter2.RemoveFromPage();

                    foreach (SymbolReference s in coList)
                        s.Remove();

                    foreach (SymbolReference s in tourList)
                        s.Remove();
                }
                else
                {
                    // Tune up for RDOL
                    rdolStarter1.Location = new PointD(dolStarter.Location.X, dolStarter.Location.Y);
                    rdolStarter2.Location = new PointD(dolStarter.Location.X + 50, dolStarter.Location.Y);
                                        
                    coList[0].Location = new PointD(rdolStarter2.Location.X, coList[0].Location.Y);
                    coList[1].Location = new PointD(rdolStarter2.Location.X + 8, coList[1].Location.Y);
                    coList[2].Location = new PointD(rdolStarter2.Location.X + 16, coList[2].Location.Y);
                    coList[3].Location = new PointD(rdolStarter2.Location.X, coList[3].Location.Y);
                    coList[4].Location = new PointD(rdolStarter2.Location.X + 8, coList[4].Location.Y);
                    coList[5].Location = new PointD(rdolStarter2.Location.X + 16, coList[5].Location.Y);
                                       

                    tourList[0].Location = new PointD(rdolStarter1.Location.X, tourList[0].Location.Y);
                    tourList[1].Location = new PointD(rdolStarter1.Location.X + 8, tourList[1].Location.Y);
                    tourList[2].Location = new PointD(rdolStarter1.Location.X + 16, tourList[2].Location.Y);
                    tourList[3].Location = new PointD(rdolStarter1.Location.X, tourList[3].Location.Y);
                    tourList[4].Location = new PointD(rdolStarter1.Location.X + 8, tourList[4].Location.Y);
                    tourList[5].Location = new PointD(rdolStarter1.Location.X + 16, tourList[5].Location.Y);

                    dolStarter.RemoveFromPage();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Tune up motor power
        /// </summary>
        /// <param name="page">EPLAN project page</param>
        /// <param name="motorPowerText">The nominal power of the motor</param>
        private bool TuneUpMotorPower(Page page, string motorPowerText)
        {
            try
            {
                Function motor = FindFunction(page, "=+EXT-M1");
                motor.Properties.FUNC_TECHNICAL_CHARACTERISTIC.Set(motorPowerText + "kW");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Tune up clamps
        /// </summary>
        /// <param name="page">EPLAN project page</param>
        /// <param name="clamps">Whether clamps are needed</param>
        /// <returns>TRUE - if success</returns>
        private bool TuneUpСlamps(Page page, bool clamps)
        {
            try
            {
                Function clamp1 = FindFunction(page, "+-X1:1");
                Function clamp2 = FindFunction(page, "+-X1:2");
                Function clamp3 = FindFunction(page, "+-X1:3");

                if (!clamps)
                {
                    clamp1.RemoveFromPage();
                    clamp2.RemoveFromPage();
                    clamp3.RemoveFromPage();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion

        #region Template

        /// <summary>
        /// Add page to current project by template that is stored in DLL resource
        /// </summary>
        /// <returns>new page instance</returns>
        private Page LoadPageTemplate()
        {
            // Temporary path for template unpacking
            string tempPath = Path.Combine(Path.GetTempPath(), "EplanMsp");

            try
            {
                // Name of temporary project
                string tempProjectName = "MSP_TEMP";
                
                // Prepare work path
                string zw1Path = Path.Combine(tempPath, tempProjectName + ".zw1");
                string elkPath = Path.Combine(tempPath, tempProjectName + ".elk");

                // Create temporary directory
                Directory.CreateDirectory(tempPath);

                // Save file with template
                File.WriteAllBytes(zw1Path, Properties.Resources.MSP_Tempate);

                // Restore and open template project
                Restore restore = new Restore();
                StringCollection archives = new StringCollection{ zw1Path };
                restore.Project(archives, tempPath, tempProjectName, false, false, 1);
                Project tempProject = projectManager.OpenProject(elkPath, ProjectManager.OpenMode.Standard, true);

                // Copy page from template project to current project
                Page tempPage = tempProject.Project.Pages.First();
                tempPage.CopyTo(CurrentProject, new PagePropertyList(), PageMacro.Enums.NumerationMode.None, false);
                tempProject.Close();
                               
                // Set unique name for new page
                Page newPage = CurrentProject.Pages.First();
                newPage.Properties.PAGE_NAME.Set(GetUniquePageName("NEW_MSP"));

                // Show page in editor
                new Edit().BringToFront(newPage);

                return newPage;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                // Delete temporary directory
                if (Directory.Exists(tempPath))
                    Directory.Delete(tempPath, true);
            }
        }

        #endregion

        #region Tools

        /// <summary>
        /// Get unique name for new page
        /// </summary>
        /// <param name="pageName">page name value string</param>
        /// <returns>new unique name of page</returns>
        private string GetUniquePageName(string pageName)
        {
            if (FindPage(pageName) != null)
            {
                int dupplicateCount = 0;
                string newPageNameWithDupplicateIndex = "";

                do
                {
                    dupplicateCount++;
                    newPageNameWithDupplicateIndex = pageName + "_" + dupplicateCount;

                } while (FindPage(newPageNameWithDupplicateIndex) != null);

                return newPageNameWithDupplicateIndex;
            }
            else
                return pageName;
        }
                                      
        /// <summary>
        /// Find page in project
        /// </summary>
        /// <param name="pageName">page name</param>
        /// <returns>page instance</returns>
        private Page FindPage(string pageName)
        {
            foreach (Page page in CurrentProject.Pages)
                if (page.Properties.PAGE_FULLNAME.ToString() == "/" + pageName)
                    return page;

            return null;
        }

        /// <summary>
        /// Find functional object on page
        /// </summary>
        /// <param name="page">pane instance</param>
        /// <param name="name">function name</param>
        /// <returns>function instance</returns>
        private Function FindFunction(Page page, string name)
        {
            foreach (Function function in page.Functions)
                if (function.Name == name)
                    return function;

            return null;
        }
        
        #endregion
    }
}
