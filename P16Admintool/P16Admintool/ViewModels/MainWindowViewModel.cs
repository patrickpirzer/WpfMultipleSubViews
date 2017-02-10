using P16Admintool.Views;
using P16Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace P16Admintool.ViewModels
{
    /// <summary>
    /// ViewModel of MainWindow.xaml.
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Field for MainWindow.xaml.
        /// </summary>
        private MainWindow mainwindow;

        /// <summary>
        /// Field for checking if menuitems "Language selection" and "Release / Version" are enabled.
        /// While items/windows from the menu "Master data" are open, the items above are disabled.
        /// </summary>
        private bool programMenuItemsEnabled = true;

        /// <summary>
        /// List for the open subviews
        /// </summary>
        private Dictionary<string, TabItem> subViews = new Dictionary<string, TabItem>();

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="window">Give the MainWindow as parameter.</param>
        public MainWindowViewModel(MainWindow window)
        {
            mainwindow = window;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets if menuitems "Language selection" and "Release / Version" are enabled.
        /// While items/windows from the menu "Master data" are open, the items above are disabled.
        /// </summary>
        public bool ProgramMenuItemsEnabled
        {
            get { return programMenuItemsEnabled; }
            set
            {
                programMenuItemsEnabled = value;
                OnPropertyChanged("ProgramMenuItemsEnabled");
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the title for the mainwindow.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TitleMainWindow
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Stammdatenverwaltung";
                    case Constants.CultureEnglish:
                        return "Master data management";
                    default:
                        return "Stammdatenverwaltung";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_program.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuProgram
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Programm";
                    case Constants.CultureEnglish:
                        return "Program";
                    default:
                        return "Programm";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_languageSelection.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemLanguageSelection
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Sprachwahl";
                    case Constants.CultureEnglish:
                        return "Language selection";
                    default:
                        return "Sprachwahl";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_releaseVersion.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemReleaseVersion
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Freigabe / Version";
                    case Constants.CultureEnglish:
                        return "Release / Version";
                    default:
                        return "Freigabe / Version";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_textMaintenence.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemTextMaintenance
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Textpflege";
                    case Constants.CultureEnglish:
                        return "Text maintenance";
                    default:
                        return "Textpflege";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_exit.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemExit
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Beenden";
                    case Constants.CultureEnglish:
                        return "Exit";
                    default:
                        return "Beenden";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_masterdata.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemMasterData
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Stammdaten";
                    case Constants.CultureEnglish:
                        return "Master Data";
                    default:
                        return "Stammdaten";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_componentKinds.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemComponentKinds
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Komponentenarten";
                    case Constants.CultureEnglish:
                        return "Component types";
                    default:
                        return "Komponentenarten";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_componentGroups.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemComponentGroups
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Komponentengruppen";
                    case Constants.CultureEnglish:
                        return "Component groups";
                    default:
                        return "Komponentengruppen";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_systemTypes.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemSystemTypes
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Anlagenarten";
                    case Constants.CultureEnglish:
                        return "Equipment types";
                    default:
                        return "Anlagenarten";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_componentTypes.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemComponentTypes
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Komponententypen";
                    case Constants.CultureEnglish:
                        return "Component models";
                    default:
                        return "Komponententypen";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_testTypes.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemTestTypes
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Testarten";
                    case Constants.CultureEnglish:
                        return "Test types";
                    default:
                        return "Testarten";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_testTypeProperties.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemTestTypeProperties
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Testart-Eigenschaften";
                    case Constants.CultureEnglish:
                        return "Test type properties";
                    default:
                        return "Testart-Eigenschaften";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_inputMasks.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemInputMasks
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Erfassungsmasken";
                    case Constants.CultureEnglish:
                        return "Log masks";
                    default:
                        return "Erfassungsmasken";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_dependencies.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemDependencies
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Abhängigkeiten";
                    case Constants.CultureEnglish:
                        return "Correlations";
                    default:
                        return "Abhängigkeiten";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_nominalValues.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemNominalValues
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Sollwerte";
                    case Constants.CultureEnglish:
                        return "Target values";
                    default:
                        return "Sollwerte";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_formulas.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemFormulas
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Formeln";
                    case Constants.CultureEnglish:
                        return "Formulas";
                    default:
                        return "Formeln";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_stepFunctions.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemStepFunctions
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Treppenfunktionen";
                    case Constants.CultureEnglish:
                        return "Step functions";
                    default:
                        return "Treppenfunktionen";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text of the menuitem mi_documentation.
        /// </summary>
        [UpdateAfterLanguageChange]
        public string TextMenuitemDocumentation
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Dokumentation";
                    case Constants.CultureEnglish:
                        return "Documentation";
                    default:
                        return "Dokumentation";
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Opens the window for selection of the application language.
        /// </summary>
        public void ShowLanguageSelectionDialogue()
        {
            LanguageSelectionWindow lsw = new LanguageSelectionWindow();
            lsw.LanguageHasChanged += UpdatePropertiesAfterLanguageChange;
            lsw.ShowDialog();
        }

        /// <summary>
        /// Opens the window to administrate the release/version.
        /// </summary>
        public void ShowReleaseVersionDialogue()
        {
            ReleaseVersionWindow rvw = new ReleaseVersionWindow();
            rvw.ShowDialog();
        }

        /// <summary>
        /// Opens the window for maintaining texts.
        /// </summary>
        public void ShowTextMaintenanceDialogue()
        {
            TextMaintenanceWindow tmw = new TextMaintenanceWindow();
            tmw.ShowDialog();
        }

        /// <summary>
        /// Shows a subview.
        /// </summary>
        /// <param name="subviewKey">The key of the subview.</param>
        /// <param name="tabHeaderPath">The binding path of the tab header.</param>
        /// <param name="tabHeaderFallbackValue">The fallbackvalue of the tab header.</param>
        public void ShowSubview(string subviewKey, string tabHeaderPath, string tabHeaderFallbackValue)
        {
            // If the subview don't exist in the list, it is created and added.
            if (!subViews.ContainsKey(subviewKey))
            {
                // Creates a tabitem and sets the binding properties.
                TabItem tab = new TabItem();
                Binding binding = new Binding(tabHeaderPath);
                binding.FallbackValue = tabHeaderFallbackValue;
                tab.SetBinding(HeaderedContentControl.HeaderProperty, binding);

                // The tab gets the view to the given subview-key.
                tab.Content = GetView(subviewKey);
                // The key and the tabitem are added to the list of open subviews.
                subViews.Add(subviewKey, tab);
                // The tabitem is added to the tab-control.
                mainwindow.tab_maintab.Items.Add(tab);
            }

            // Sets the focus on the subview which was selected in the menu.
            mainwindow.tab_maintab.SelectedItem = subViews[subviewKey];

            // Enables or disables the menuitems "Language selection" and "Release / Version".
            ProgramMenuItemsEnabled = GetProgramMenuItemsEnabled();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Updates all properties with attribute [UpdateAfterLanguageChange] after the application language was changed.
        /// </summary>
        private void UpdatePropertiesAfterLanguageChange(object sender, EventArgs e)
        {
            // Updates all properties of this class.
            //OnPropertyChanged("");

            // Updates only the properties with attribute [UpdateAfterLanguageChange].
            var props = typeof(MainWindowViewModel).GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(UpdateAfterLanguageChange)));
            foreach (PropertyInfo prop in props)
            {
                OnPropertyChanged(prop.Name);
            }
        }

        /// <summary>
        /// Gets the view according to the given subview-key.
        /// </summary>
        /// <param name="subviewKey">The key of the subview.</param>
        /// <returns>Returns the view as an object of type FrameworkElement.</returns>
        private FrameworkElement GetView(string subviewKey)
        {
            var element = new FrameworkElement();

            switch (subviewKey)
            {
                case Constants.keyInputMasks:
                    var inputMaskView = new InputMasksView();
                    inputMaskView.ViewCloseEvent += OnViewClosing;
                    element = inputMaskView;
                    break;
                case Constants.keyStepFunctions:
                    var stepFunctionsView = new StepFunctionsView();
                    stepFunctionsView.ViewCloseEvent += OnViewClosing;
                    element = stepFunctionsView;
                    break;
                // TODO
            }

            return element;
        }

        /// <summary>
        /// One of the subviews is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnViewClosing(object sender, ViewClosingEventArgs e)
        {
            if (e != null &&
                string.IsNullOrWhiteSpace(e.SubviewKey) == false)
            {
                if (subViews.ContainsKey(e.SubviewKey))
                {
                    // Removes the subview from the tab-control.
                    mainwindow.tab_maintab.Items.Remove(subViews[e.SubviewKey]);
                    // Removes the key from the list of open subviews.
                    subViews.Remove(e.SubviewKey);
                    // Tries to set the focus on the first open subview.
                    TabSetFocus();
                }
            }

            // Enables or disables the menuitems "Language selection" and "Release / Version".
            ProgramMenuItemsEnabled = GetProgramMenuItemsEnabled();
        }

        /// <summary>
        /// Tries to set the focus on the first open tab/view.
        /// </summary>
        private void TabSetFocus()
        {
            foreach (TabItem item in mainwindow.tab_maintab.Items)
            {
                if (item.Visibility == Visibility.Visible)
                {
                    item.Focus();
                    return;
                }
            }
        }

        /// <summary>
        /// Gets if the menuitems "Language selection" and "Release / Version" are enabled or disabled if just one tabview is displayed.
        /// </summary>
        /// <returns>True: The menuitems are enabled, False: The menuitems are disabled.</returns>
        private bool GetProgramMenuItemsEnabled()
        {
            bool menuitemsEnabled = true;

            foreach (TabItem item in mainwindow.tab_maintab.Items)
            {
                if (item.Visibility == Visibility.Visible)
                {
                    menuitemsEnabled = false;
                }
            }

            return menuitemsEnabled;
        }

        #endregion

        #region INotifyPropertyChanged members

        /// <summary>
        /// Eventhandler for signalising that a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Informs the target which is bound to a property, that it's source was changed and that it shall update.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
