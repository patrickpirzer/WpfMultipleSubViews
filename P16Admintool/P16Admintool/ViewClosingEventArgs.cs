using System;

namespace P16Admintool
{
    /// <summary>
    /// Class with EventArguments for close-event of a view.
    /// </summary>
    public class ViewClosingEventArgs : EventArgs
    {
        /// <summary>
        /// Gets or sets the key of the subview.
        /// </summary>
        public string SubviewKey { get; set; }

    }
}
