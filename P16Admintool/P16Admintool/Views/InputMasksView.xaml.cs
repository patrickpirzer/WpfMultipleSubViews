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

namespace P16Admintool.Views
{
    /// <summary>
    /// Class for the view to administrate the input masks.
    /// </summary>
    public partial class InputMasksView : UserControl, IView
    {
        #region Fields

        /// <summary>
        /// Field for an object of the class <see cref="InputMasksViewModel"/> class.
        /// </summary>
        private InputMasksViewModel vm = null;

        #endregion

        #region Events

        /// <summary>
        /// Event for closing this view.
        /// </summary>
        public event EventHandler<ViewClosingEventArgs> ViewCloseEvent;

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor.
        /// </summary>
        public InputMasksView()
        {
            // Initializes the view.
            InitializeComponent();

            // The viewmodel is created and gets the designerpanel.
            vm = new InputMasksViewModel(designerpanel, this);
            DataContext = vm;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Closes this view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            if (ViewCloseEvent != null)
            {
                ViewClosingEventArgs eventargs = new ViewClosingEventArgs();
                eventargs.SubviewKey = Constants.keyInputMasks;
                ViewCloseEvent(this, eventargs);
            }
        }

        /// <summary>
        /// Starts the adding of a label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddLabel_Click(object sender, RoutedEventArgs e)
        {
            vm.StartAddingLabel();
        }

        /// <summary>
        /// Starts the adding of a text field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddTextField_Click(object sender, RoutedEventArgs e)
        {
            vm.StartAddingTextField();
        }

        /// <summary>
        /// Starts the adding of a numeric field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddNumericField_Click(object sender, RoutedEventArgs e)
        {
            vm.StartAddingNumericField();
        }

        /// <summary>
        /// Starts the adding of a dropdown list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddDropDownList_Click(object sender, RoutedEventArgs e)
        {
            vm.StartAddingDropDownList();
        }

        /// <summary>
        /// Aborts the adding action.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_abort_Click(object sender, RoutedEventArgs e)
        {
            vm.AbortAddingAction();
        }

        /// <summary>
        /// The mouse cursor enters the designerpanel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void designerpanel_MouseEnter(object sender, MouseEventArgs e)
        {
            vm.designerpanelMouseEnter();
        }

        /// <summary>
        /// The mouse cursor leaves the designerpanel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void designerpanel_MouseLeave(object sender, MouseEventArgs e)
        {
            vm.designerpanelMouseLeave();
        }

        /// <summary>
        /// A mouse-button is clicked while the cursor is in the designerpanel.
        /// Now the control chosen for adding shall be added to the designerpanel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void designerpanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            vm.designerpanelMouseDown();
        }

        /// <summary>
        /// The cursor is moved inside the designerpanel.
        /// Actually not in use.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void designerpanel_MouseMove(object sender, MouseEventArgs e)
        {
            //
        }

        #endregion

    }
}
