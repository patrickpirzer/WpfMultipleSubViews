using P16Common;
using System.ComponentModel;
using System.Windows;

namespace P16Admintool.ViewModels
{
    /// <summary>
    /// Viewmodel for changing the properties of the element.
    /// </summary>
    public class ChangeElementPropertiesViewModel : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// Field for the element whose properties shall be changed.
        /// </summary>
        private FrameworkElement fwElement;

        /// <summary>
        /// Field for the text/content of the element.
        /// </summary>
        private string strText = "";

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="element">The element.</param>
        public ChangeElementPropertiesViewModel(FrameworkElement element)
        {
            fwElement = element;

            GetElementProperties();
        }

        #endregion

        #region Properties

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the window title.
        /// </summary>
        public string TitleChangeElementProperties
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Eigenschaften anpassen";
                    case Constants.CultureEnglish:
                        return "Change element properties";
                    default:
                        return "Eigenschaften anpassen";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for button btn_set_properties.
        /// </summary>
        public string TextBtnSetProperties
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Übernehmen";
                    case Constants.CultureEnglish:
                        return "Accept";
                    default:
                        return "Übernehmen";
                }
            }
        }

        /// <summary>
        /// Gets or sets the text/content of the element.
        /// </summary>
        public string StrText
        {
            get { return strText; }
            set
            {
                strText = value;
                OnPropertyChanged("StrText");
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Tries to set the püroperties of the element.
        /// </summary>
        public void SetElementProperties()
        {
            if (fwElement.GetType().GetProperty("Content") != null)
            {
                fwElement.GetType().GetProperty("Content").SetValue(fwElement, StrText);
            }

            if (fwElement.GetType().GetProperty("Text") != null)
            {
                fwElement.GetType().GetProperty("Text").SetValue(fwElement, StrText);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Tries to get the properties and its data from the element.
        /// </summary>
        private void GetElementProperties()
        {
            if (fwElement == null)
            {
                return;
            }

            GetElementText();
        }

        /// <summary>
        /// Tries to get the text/content of the element.
        /// </summary>
        private void GetElementText()
        {
            if (fwElement.GetType().GetProperty("Content") != null && fwElement.GetType().GetProperty("Content").GetValue(fwElement) != null)
            {
                StrText = fwElement.GetType().GetProperty("Content").GetValue(fwElement).ToString();
            }

            if (fwElement.GetType().GetProperty("Text") != null && fwElement.GetType().GetProperty("Text").GetValue(fwElement) != null)
            {
                StrText = fwElement.GetType().GetProperty("Text").GetValue(fwElement).ToString();
            }
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
