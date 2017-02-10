using System.Windows;
using System.Windows.Controls;

namespace P16CustomControlLibrary
{
    /// <summary>
    /// Class for a CustomControl which inherits from Label and has a nested TextBlock for textwrapping.
    /// </summary>
    public class CustomLabel : Label
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        static CustomLabel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomLabel), new FrameworkPropertyMetadata(typeof(CustomLabel)));
        }

        /// <summary>
        /// DependencyProperty for access to the text value.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(CustomLabel));

        /// <summary>
        /// DependencyProperty for the textdecorations.
        /// </summary>
        public static readonly DependencyProperty TextDecorationsProperty =
            DependencyProperty.Register("TextDecorations", typeof(TextDecorationCollection), typeof(CustomLabel));

        /// <summary>
        /// DependencyProperty for external access to the property TableName.
        /// </summary>
        public static readonly DependencyProperty TableNameProperty =
            DependencyProperty.Register("TableName", typeof(string), typeof(CustomLabel));

        /// <summary>
        /// DependencyProperty with which we can check, if the control is visible on the input form.
        /// </summary>
        public static readonly DependencyProperty IsVisibleInInputFormProperty =
            DependencyProperty.Register("IsVisibleInInputForm", typeof(bool), typeof(CustomLabel));

        /// <summary>
        /// DependencyProperty with which we can check, if the control is visible on the testprotocol.
        /// </summary>
        public static readonly DependencyProperty IsVisibleInTestprotocolProperty =
            DependencyProperty.Register("IsVisibleInTestprotocol", typeof(bool), typeof(CustomLabel));

        /// <summary>
        /// DependencyProperty for external access to the thickness of the inner border.
        /// </summary>
        public static readonly DependencyProperty InnerBorderThicknessProperty =
            DependencyProperty.Register("InnerBorderThickness", typeof(Thickness), typeof(CustomLabel));

        /// <summary>
        /// DependencyProperty for external access to the thickness of the outer border.
        /// </summary>
        public static readonly DependencyProperty OuterBorderThicknessProperty =
            DependencyProperty.Register("OuterBorderThickness", typeof(Thickness), typeof(CustomLabel));

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Gets or sets the textdecorations.
        /// </summary>
        public TextDecorationCollection TextDecorations
        {
            get { return (TextDecorationCollection)GetValue(TextDecorationsProperty); }
            set { SetValue(TextDecorationsProperty, value); }
        }

        /// <summary>
        /// Gets or sets the name of the datatable which is the datasource.
        /// </summary>
        public string TableName
        {
            get { return (string)GetValue(TableNameProperty); }
            set { SetValue(TableNameProperty, value); }
        }

        /// <summary>
        /// Gets or sets if input in the control is visible on the input form.
        /// </summary>
        public bool IsVisibleInInputForm
        {
            get { return bool.Parse(GetValue(IsVisibleInInputFormProperty).ToString()); }
            set { SetValue(IsVisibleInInputFormProperty, value); }
        }

        /// <summary>
        /// Gets or sets if input in the control is visible on the testprotocol.
        /// </summary>
        public bool IsVisibleInTestprotocol
        {
            get { return bool.Parse(GetValue(IsVisibleInTestprotocolProperty).ToString()); }
            set { SetValue(IsVisibleInTestprotocolProperty, value); }
        }

        /// <summary>
        /// Gets or sets the thickness of the inner border.
        /// </summary>
        public Thickness InnerBorderThickness
        {
            get { return (Thickness)GetValue(InnerBorderThicknessProperty); }
            set { SetValue(InnerBorderThicknessProperty, value); }
        }

        /// <summary>
        /// Gets or sets the thickness of the outer border.
        /// </summary>
        public Thickness OuterBorderThickness
        {
            get { return (Thickness)GetValue(OuterBorderThicknessProperty); }
            set { SetValue(OuterBorderThicknessProperty, value); }
        }

    }
}
