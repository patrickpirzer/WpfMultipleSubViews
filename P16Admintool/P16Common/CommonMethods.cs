using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace P16Common
{
    /// <summary>
    /// Class for common methods.
    /// </summary>
    public class CommonMethods
    {
        /// <summary>
        /// Display the given cursor.
        /// </summary>
        /// <param name="displayCursor">The cursor to be displayed.</param>
        public static void DisplayCursor(Cursor displayCursor)
        {
            Mouse.OverrideCursor = displayCursor;
        }

        /// <summary>
        /// Displays the given cursor.
        /// </summary>
        /// <param name="displayCursor">The cursor to be displayed.</param>
        /// <param name="window">The window on which the cursor shall be displayed.</param>
        public static void DisplayCursor(Cursor displayCursor, FrameworkElement window)
        {
            window.Cursor = displayCursor;
            Mouse.OverrideCursor = displayCursor;
        }

        /// <summary>
        /// Gets the current application language.
        /// </summary>
        /// <returns>Returns a string with the current language (p.e. "en").</returns>
        public static string GetCurrentLanguage()
        {
            if (CultureInfo.DefaultThreadCurrentCulture != null &&
                string.IsNullOrWhiteSpace(CultureInfo.DefaultThreadCurrentCulture.Name) == false)
            {
                return CultureInfo.DefaultThreadCurrentCulture.Name;
            }

            if (CultureInfo.DefaultThreadCurrentUICulture != null &&
                string.IsNullOrWhiteSpace(CultureInfo.DefaultThreadCurrentUICulture.Name) == false)
            {
                return CultureInfo.DefaultThreadCurrentUICulture.Name;
            }

            return Constants.CultureGerman;
        }

        /// <summary>
        /// Sets the current application language.
        /// </summary>
        /// <param name="language">The new application language (p.e. "en").</param>
        public static void SetCurrentLanguage(string language)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(language);
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(language);
        }

    }
}
