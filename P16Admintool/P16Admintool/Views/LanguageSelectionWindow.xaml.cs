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
using System.Windows.Shapes;
using P16Admintool.ViewModels;

namespace P16Admintool.Views
{
    /// <summary>
    /// Interaction logic for LanguageSelectionWindow.xaml.
    /// </summary>
    public partial class LanguageSelectionWindow : Window
    {
        #region Fields

        /// <summary>
        /// Field for an instance of the viewmodel class.
        /// </summary>
        private LanguageSelectionWindowViewModel vm;

        #endregion

        #region Events

        /// <summary>
        /// Event for signalizing that the application language has changed.
        /// </summary>
        public EventHandler LanguageHasChanged;

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor.
        /// </summary>
        public LanguageSelectionWindow()
        {
            // Initializes the window.
            InitializeComponent();

            // Creates an instance of the viewmodel and sets the datacontext.
            vm = new LanguageSelectionWindowViewModel();
            DataContext = vm;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Aborts the changing of the language.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_abort_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Confirms the selected language and executes the change.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_changeLanguage_Click(object sender, RoutedEventArgs e)
        {
            // Changes th application language.
            vm.ChangeLanguage();

            // Calls an event which informs the caller (in that case MainWindow.xaml) that the language has changed.
            if (LanguageHasChanged != null)
                LanguageHasChanged(null, null);

            // Closes this window.
            Close();
        }

        #endregion

    }
}
