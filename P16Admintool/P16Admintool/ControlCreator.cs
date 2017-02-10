using P16CustomControlLibrary;
using System.Windows;

namespace P16Admintool
{
    /// <summary>
    /// Class for the creating controls to the mask designer.
    /// </summary>
    public class ControlCreator
    {
        /// <summary>
        /// Creates a control according to the given element and returns it.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns>
        /// If successfull the method returns the control as an object of type FrameworkElement.
        /// Otherwise it returns null.
        /// </returns>
        public FrameworkElement GetControl(FrameworkElement element)
        {
            FrameworkElement newControl = null;

            if (element.GetType() == typeof(CustomLabel))
            {
                newControl = GetLabel();
            }
            else if (element.GetType() == typeof(CustomNumericField))
            {
                newControl = GetNumericField();
            }
            else if (element.GetType() == typeof(CustomTextBox))
            {
                newControl = GetTextField();
            }
            else if (element.GetType() == typeof(CustomComboBox))
            {
                newControl = GetDropDownList();
            }

            return newControl;
        }

        /// <summary>
        /// Gets a label.
        /// </summary>
        /// <returns>Returns a frameworkelement of type <see cref="CustomLabel"/>.</returns>
        private FrameworkElement GetLabel()
        {
            //FrameworkElement newControl = new Label();
            //newControl.GetType().GetProperty("Content").SetValue(newControl, "Label");
            //newControl.GetType().GetProperty("Background").SetValue(newControl, new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.AliceBlue));
            //// Sets the width to AutoSize.
            //newControl.GetType().GetProperty("Width").SetValue(newControl, double.NaN);
            //return newControl;

            FrameworkElement newControl = new CustomLabel();
            newControl.GetType().GetProperty("Text").SetValue(newControl, "Label");
            newControl.GetType().GetProperty("Background").SetValue(newControl, new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.AliceBlue));
            return newControl;
        }

        /// <summary>
        /// Gets a numeric field.
        /// </summary>
        /// <returns>Returns a frameworkelement of type <see cref="CustomNumericField"/>.</returns>
        private FrameworkElement GetNumericField()
        {
            FrameworkElement newControl = new CustomNumericField();
            newControl.GetType().GetProperty("Width").SetValue(newControl, 50);
            return newControl;
        }

        /// <summary>
        /// Gets a text field.
        /// </summary>
        /// <returns>Returns a frameworkelement of type <see cref="CustomTextBox"/>.</returns>
        private FrameworkElement GetTextField()
        {
            FrameworkElement newControl = new CustomTextBox();
            newControl.GetType().GetProperty("Width").SetValue(newControl, 150);
            return newControl;
        }

        /// <summary>
        /// Gets a dropdown list.
        /// </summary>
        /// <returns>Returns a frameworkelement of type <see cref="CustomComboBox"/>.</returns>
        private FrameworkElement GetDropDownList()
        {
            FrameworkElement newControl = new CustomComboBox();
            newControl.GetType().GetProperty("Width").SetValue(newControl, 150);
            return newControl;
        }

    }
}
