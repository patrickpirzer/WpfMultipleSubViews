using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using P16Admintool.ViewModels;
using P16Common;

namespace P16Admintool
{
    /// <summary>
    /// Class for the main view of the P16 administration.
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 

        /// <summary>
        /// Field for an instance of the viewmodel class.
        /// </summary>
        private MainWindowViewModel vm;

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor of the window.
        /// </summary>
        public MainWindow()
        {
            // TODO : Replace this by reading the last used user language from the database.
            // Sets the current application language to english.
            // In the final application the user's language would be read from the database.
            CommonMethods.SetCurrentLanguage(Constants.CultureEnglish);

            // Initializes the window.
            InitializeComponent();

            // Creates an instance of the viewmodel and sets the datacontext.
            vm = new MainWindowViewModel(this);
            DataContext = vm;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Opens the window for selection of the application language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_languageSelection_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowLanguageSelectionDialogue();
        }

        /// <summary>
        /// Opens the window to administrate the release/version.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_releaseVersion_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowReleaseVersionDialogue();
        }

        /// <summary>
        /// Opens the window for maintaining texts.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_textMaintenence_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowTextMaintenanceDialogue();
        }

        /// <summary>
        /// Closes this window and exits the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Opens the view to administrate the component kinds.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_componentKinds_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowSubview(Constants.keyComponentKinds, "TextMenuitemComponentKinds", "Komponentenarten");
        }

        /// <summary>
        /// Opens the view to administrate the component groups.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_componentGroups_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowSubview(Constants.keyComponentGroups, "TextMenuitemComponentGroups", "Komponentengruppen");
        }

        /// <summary>
        /// Opens the view to administrate the system types.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_systemTypes_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowSubview(Constants.keySystemTypes, "TextMenuitemSystemTypes", "Anlagenarten");
        }

        /// <summary>
        /// Opens the view to administrate the component types.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_componentTypes_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowSubview(Constants.keyComponentTypes, "TextMenuitemComponentTypes", "Komponententypen");
        }

        /// <summary>
        /// Opens the view to administrate the test types.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_testTypes_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowSubview(Constants.keyTestTypes, "TextMenuitemTestTypes", "Testarten");
        }

        /// <summary>
        /// Opens the view to administrate the test type properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_testTypeProperties_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowSubview(Constants.keyTestTypeProperties, "TextMenuitemTestTypeProperties", "Testart-Eigenschaften");
        }

        /// <summary>
        /// Opens the view to administrate the input masks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_inputMasks_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowSubview(Constants.keyInputMasks, "TextMenuitemInputMasks", "Erfassungsmasken");
        }

        /// <summary>
        /// Opens the view to administrate the dependencies.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_dependencies_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowSubview(Constants.keyDependencies, "TextMenuitemDependencies", "Abhängigkeiten");
        }

        /// <summary>
        /// Opens the view to administrate the nominal values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_nominalValues_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowSubview(Constants.keyNominalValues, "TextMenuitemNominalValues", "Sollwerte");
        }

        /// <summary>
        /// Opens the view to administrate the formulas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_formulas_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowSubview(Constants.keyFormulas, "TextMenuitemFormulas", "Formeln");
        }

        /// <summary>
        /// Opens the view to administrate the stepfunctions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_stepFunctions_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowSubview(Constants.keyStepFunctions, "TextMenuitemStepFunctions", "Treppenfunktionen");
        }

        /// <summary>
        /// Opens the view to open the documentation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_documentation_Click(object sender, RoutedEventArgs e)
        {
            vm.ShowSubview(Constants.keyDocumentation, "TextMenuitemDocumentation", "Dokumentation");
        }

        #endregion

    }
}
