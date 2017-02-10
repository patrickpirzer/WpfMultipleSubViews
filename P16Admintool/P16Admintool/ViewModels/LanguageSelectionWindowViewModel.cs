using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using P16Common;

namespace P16Admintool.ViewModels
{
    /// <summary>
    /// Class for the viewmodel of LanguageSelectionWindow.xaml.
    /// </summary>
    public class LanguageSelectionWindowViewModel : INotifyPropertyChanged
    {
        #region Constructor

        /// <summary>
        /// The constructor.
        /// </summary>
        public LanguageSelectionWindowViewModel()
        {
            // Displays the current language of the application thread.
            switch (CommonMethods.GetCurrentLanguage())
            {
                case Constants.CultureGerman:
                    LanguageGermanSelected = true;
                    LanguageEnglishSelected = false;
                    CountryLanguageSelected = false;
                    break;
                case Constants.CultureEnglish:
                    LanguageGermanSelected = false;
                    LanguageEnglishSelected = true;
                    CountryLanguageSelected = false;
                    break;
                default:
                    LanguageGermanSelected = true;
                    LanguageEnglishSelected = false;
                    CountryLanguageSelected = false;
                    break;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the title for the language selection window.
        /// </summary>
        public string TitleLanguageSelectionWindow
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Spracheinstellung";
                    case Constants.CultureEnglish:
                        return "Language selection";
                    default:
                        return "Spracheinstellung";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for the groupbox to select the language.
        /// </summary>
        public string TextLanguageGroup
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Sprache";
                    case Constants.CultureEnglish:
                        return "Language";
                    default:
                        return "Sprache";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for the radiobutton to select language german.
        /// </summary>
        public string TextLanguageGerman
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Deutsch";
                    case Constants.CultureEnglish:
                        return "German";
                    default:
                        return "Deutsch";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for the radiobutton to select language english.
        /// </summary>
        public string TextLanguageEnglish
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Englisch";
                    case Constants.CultureEnglish:
                        return "English";
                    default:
                        return "Englisch";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for the radiobutton to select the country language.
        /// </summary>
        public string TextCountryLanguage
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Landessprache";
                    case Constants.CultureEnglish:
                        return "Country language";
                    default:
                        return "Landessprache";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for the groupbox to select the alternative language.
        /// </summary>
        public string TextAltLanguageGroup
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "Alternativsprache";
                    case Constants.CultureEnglish:
                        return "Alternative language";
                    default:
                        return "Alternativsprache";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for the abort-button.
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
                        return "Quit";
                    default:
                        return "Abbrechen";
                }
            }
        }

        /// <summary>
        /// TODO : Read from the database.
        /// Gets the text for the confirm-button.
        /// </summary>
        public string TextBtnChangeLanguage
        {
            get
            {
                switch (CommonMethods.GetCurrentLanguage())
                {
                    case Constants.CultureGerman:
                        return "OK";
                    case Constants.CultureEnglish:
                        return "OK";
                    default:
                        return "OK";
                }
            }
        }

        /// <summary>
        /// Gets or sets if language german is selected.
        /// </summary>
        public bool? LanguageGermanSelected { get; set; }

        /// <summary>
        /// Gets or sets if language english is selected.
        /// </summary>
        public bool? LanguageEnglishSelected { get; set; }

        /// <summary>
        /// Gets or sets if country language is selected.
        /// </summary>
        public bool? CountryLanguageSelected { get; set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Changes the application language.
        /// </summary>
        public void ChangeLanguage()
        {
            // Gets and reminds the current application language.
            string language = CommonMethods.GetCurrentLanguage();

            // Tries to find the culture to the selected language.
            if (LanguageGermanSelected == true || CountryLanguageSelected == true)
                language = Constants.CultureGerman;
            if (LanguageEnglishSelected == true)
                language = Constants.CultureEnglish;

            // Updates the current application language.
            CommonMethods.SetCurrentLanguage(language);
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
