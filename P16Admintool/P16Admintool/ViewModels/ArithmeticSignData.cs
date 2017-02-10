namespace P16Admintool.ViewModels
{
    /// <summary>
    /// Class for arithmetic sign data.
    /// </summary>
    public class ArithmeticSignData
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public ArithmeticSignData(string key, string value)
        {
            ArithmeticSignKey = key;
            ArithmeticSignValue = value;
        }

        /// <summary>
        /// The key of the arithmetic sign.
        /// </summary>
        public string ArithmeticSignKey { get; set; }

        /// <summary>
        /// The value of the arithmetic sign.
        /// </summary>
        public string ArithmeticSignValue { get; set; }

    }
}
