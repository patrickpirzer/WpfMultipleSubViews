using P16Common;
using P16CustomControlLibrary;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace P16Admintool.ViewModels
{
    /// <summary>
    /// ViewModel class for InputMasksView.
    /// </summary>
    public class InputMasksViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Field for the control which is created on the designer window.
        /// </summary>
        private FrameworkElement myControl = null;

        /// <summary>
        /// Field for an object of the designerpanel.
        /// On that panel the control are created, dragged and resized.
        /// </summary>
        private Canvas designerpanel;

        /// <summary>
        /// Field for an object of the designerwindow (= InputMasksView.xaml).
        /// </summary>
        private FrameworkElement designerwindow;

        /// <summary>
        /// Field for an object of the <see cref="DragAndResizeElementActions"/> class.
        /// </summary>
        private DragAndResizeElementActions dragAndResizeElementActions;

        /// <summary>
        /// Field for an object of the <see cref="ContextmenuAdministration"/> class.
        /// </summary>
        private ContextmenuAdministration contextmenuAdministration;

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="panelForMaskDesign">The panel for designing a mask.</param>
        /// <param name="windowForMaskDesign">The window for designing a mask.</param>
        public InputMasksViewModel(Canvas panelForMaskDesign, FrameworkElement windowForMaskDesign)
        {
            designerpanel = panelForMaskDesign;
            designerwindow = windowForMaskDesign;

            // Initializes an instance of the class for dragging and resizing elements.
            dragAndResizeElementActions = new DragAndResizeElementActions(designerwindow);

            contextmenuAdministration = new ContextmenuAdministration();
        }

        #endregion

        #region Properties

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for the button to add a label.
        /// </summary>
        public string TextBtnAddLabel
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Beschriftung";
                    case Constants.CultureEnglish:
                        return "Lettering";
                    default:
                        return "Beschriftung";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for the button to add a numeric field.
        /// </summary>
        public string TextBtnAddNumericField
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Num. Feld";
                    case Constants.CultureEnglish:
                        return "Num. box";
                    default:
                        return "Num. Feld";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for the button to add a text field.
        /// </summary>
        public string TextBtnAddTextField
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Textfeld";
                    case Constants.CultureEnglish:
                        return "Text box";
                    default:
                        return "Textfeld";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for the button to add a dropdown list.
        /// </summary>
        public string TextBtnAddDropDownList
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Aufzählung";
                    case Constants.CultureEnglish:
                        return "Selection box";
                    default:
                        return "Aufzählung";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for the button to abort the adding of a new control.
        /// </summary>
        public string TextBtnAbort
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Abbrechen";
                    case Constants.CultureEnglish:
                        return "Abort";
                    default:
                        return "Abbrechen";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for the button btn_close.
        /// </summary>
        public string TextBtnClose
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Schliessen";
                    case Constants.CultureEnglish:
                        return "Close";
                    default:
                        return "Schliessen";
                }
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Starts the adding of a label.
        /// </summary>
        public void StartAddingLabel()
        {
            myControl = new CustomLabel();
            CommonMethods.DisplayCursor(Cursors.No, designerwindow);
        }

        /// <summary>
        /// Starts the adding of a numeric field.
        /// </summary>
        public void StartAddingNumericField()
        {
            myControl = new CustomNumericField();
            CommonMethods.DisplayCursor(Cursors.No, designerwindow);
        }

        /// <summary>
        /// Starts the adding of a text field.
        /// </summary>
        public void StartAddingTextField()
        {
            myControl = new CustomTextBox();
            CommonMethods.DisplayCursor(Cursors.No, designerwindow);
        }

        /// <summary>
        /// Starts the adding of a dropdown list.
        /// </summary>
        public void StartAddingDropDownList()
        {
            myControl = new CustomComboBox();
            CommonMethods.DisplayCursor(Cursors.No, designerwindow);
        }

        /// <summary>
        /// Aborts the adding action.
        /// </summary>
        public void AbortAddingAction()
        {
            myControl = null;
            CommonMethods.DisplayCursor(Cursors.Arrow, designerwindow);
        }

        /// <summary>
        /// The mouse cursor enters the designerpanel.
        /// </summary>
        public void designerpanelMouseEnter()
        {
            if (myControl == null)
            {
                return;
            }

            // If myControl is set the cursor has to become a cross.
            CommonMethods.DisplayCursor(Cursors.Cross, designerwindow);
        }

        /// <summary>
        /// The mouse cursor leaves the designerpanel.
        /// </summary>
        public void designerpanelMouseLeave()
        {
            if (myControl == null)
            {
                return;
            }

            // If myControl is set the cursor has to become the forbidden sign.
            CommonMethods.DisplayCursor(Cursors.No, designerwindow);
        }

        /// <summary>
        /// A mouse-button is clicked while the cursor is in the designerpanel.
        /// Now the control chosen for adding shall be added to the designerpanel.
        /// </summary>
        public void designerpanelMouseDown()
        {
            FrameworkElement newControl = null;

            // If no control was chosen before mousedown, no further action is required.
            if (myControl == null)
            {
                return;
            }

            // A control is created according to the selection.
            newControl = (new ControlCreator()).GetControl(myControl);

            // If newControl is set, the new control will be added to the designerpanel.
            if (newControl != null)
            {
                // Gets the actual position of the cursor and recalculates the coordinates.
                double xpos = Mouse.GetPosition(designerpanel).X;
                double ypos = Mouse.GetPosition(designerpanel).Y;
                xpos = Math.Round(xpos / 10) * 10;
                ypos = Math.Round(ypos / 10) * 10;

                // The new control gets the final left and top position.
                Canvas.SetLeft(newControl, xpos);
                Canvas.SetTop(newControl, ypos);

                // Adds eventhandlers to the new control for drag, drop and resize.
                ElementAddEventhandlers(newControl);

                // Creates the context menu and adds it to the new control.
                contextmenuAdministration.ElementAddContextMenu(newControl);

                // Adds the new control to the designerpanel.
                designerpanel.Children.Add(newControl);
            }

            // myControl and the cursor are resetted.
            myControl = null;
            CommonMethods.DisplayCursor(Cursors.Arrow, designerwindow);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Adds eventhandlers to the new control for drag, drop and resize.
        /// </summary>
        /// <param name="element"></param>
        private void ElementAddEventhandlers(FrameworkElement element)
        {
            element.PreviewMouseLeftButtonDown += dragAndResizeElementActions.OnElementMouseDown;
            element.PreviewMouseMove += dragAndResizeElementActions.OnElementMouseMove;
            element.PreviewMouseLeftButtonUp += dragAndResizeElementActions.OnMouseUp;
            element.MouseEnter += dragAndResizeElementActions.OnMouseEnter;
            element.MouseLeave += dragAndResizeElementActions.OnMouseLeave;
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
