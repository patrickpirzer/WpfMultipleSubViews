using System.Windows;
using System.Windows.Controls;

namespace P16CustomControlLibrary
{
    /// <summary>
    /// Class for the CustomControl CustomNumericField.
    /// </summary>
    public class CustomNumericField : TextBox
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        static CustomNumericField()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomNumericField), new FrameworkPropertyMetadata(typeof(CustomNumericField)));
        }

        /// <summary>
        /// DependencyProperty for external access to the property TableName.
        /// </summary>
        public static readonly DependencyProperty TableNameProperty =
            DependencyProperty.Register("TableName", typeof(string), typeof(CustomNumericField));

        /// <summary>
        /// DependencyProperty for external access to the Formula-property of the control's binding.
        /// </summary>
        public static readonly DependencyProperty BindingFormulaProperty =
            DependencyProperty.Register("BindingFormula", typeof(string), typeof(CustomNumericField));

        /// <summary>
        /// DependencyProperty for external access to the PredecimalPlaces-property.
        /// </summary>
        public static readonly DependencyProperty PredecimalPlacesProperty =
            DependencyProperty.Register("PredecimalPlaces", typeof(int), typeof(CustomNumericField));

        /// <summary>
        /// DependencyProperty for external access to the DecimalPlaces-property.
        /// </summary>
        public static readonly DependencyProperty DecimalPlacesProperty =
            DependencyProperty.Register("DecimalPlaces", typeof(int), typeof(CustomNumericField));

        /// <summary>
        /// DependencyProperty for external access to the IsRequired-property.
        /// </summary>
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register("IsRequired", typeof(bool), typeof(CustomNumericField));

        /// <summary>
        /// DependencyProperty with which we can check, if the control is visible on the input form.
        /// </summary>
        public static readonly DependencyProperty IsVisibleInInputFormProperty =
            DependencyProperty.Register("IsVisibleInInputForm", typeof(bool), typeof(CustomNumericField));

        /// <summary>
        /// DependencyProperty with which we can check, if the control is visible on the testprotocol.
        /// </summary>
        public static readonly DependencyProperty IsVisibleInTestprotocolProperty =
            DependencyProperty.Register("IsVisibleInTestprotocol", typeof(bool), typeof(CustomNumericField));

        /// <summary>
        /// DependencyProperty for external access to the CanBeEdited-property.
        /// </summary>
        public static readonly DependencyProperty CanBeEditedProperty =
            DependencyProperty.Register("CanBeEdited", typeof(bool), typeof(CustomNumericField));

        /// <summary>
        /// DependencyProperty for external access to the DatabaseFieldName-property.
        /// </summary>
        public static readonly DependencyProperty DatabaseFieldNameProperty =
            DependencyProperty.Register("DatabaseFieldName", typeof(string), typeof(CustomNumericField));

        /// <summary>
        /// DependencyProperty for external access to the list with the selected formulas.
        /// </summary>
        public static readonly DependencyProperty SelectedFormulasProperty =
            DependencyProperty.Register("SelectedFormulas", typeof(SelectedFormulaCollection), typeof(CustomNumericField));

        /// <summary>
        /// DependencyProperty with which we can check, if the control is a numeric field.
        /// </summary>
        public static readonly DependencyProperty IsNumericFieldProperty =
            DependencyProperty.Register("IsNumericField", typeof(bool), typeof(CustomNumericField));

        /// <summary>
        /// DependencyProperty for external access to the InputFieldId-property.
        /// </summary>
        public static readonly DependencyProperty InputFieldIdProperty =
            DependencyProperty.Register("InputFieldId", typeof(int), typeof(CustomNumericField));

        /// <summary>
        /// DependencyProperty for external access to the DescriptionText-property.
        /// </summary>
        public static readonly DependencyProperty DescriptionTextProperty =
            DependencyProperty.Register("DescriptionText", typeof(string), typeof(CustomNumericField));

        /// <summary>
        /// Gets or sets the name of the datatable which is the datasource.
        /// </summary>
        public string TableName
        {
            get { return (string)GetValue(TableNameProperty); }
            set { SetValue(TableNameProperty, value); }
        }

        /// <summary>
        /// Gets or sets the binding formula.
        /// </summary>
        public string BindingFormula
        {
            get { return (string)GetValue(BindingFormulaProperty); }
            set { SetValue(BindingFormulaProperty, value); }
        }

        /// <summary>
        /// Gets or sets the predecimalplaces.
        /// </summary>
        public int PredecimalPlaces
        {
            get { return int.Parse(GetValue(PredecimalPlacesProperty).ToString()); }
            set { SetValue(PredecimalPlacesProperty, value); }
        }

        /// <summary>
        /// Gets or sets the decimalplaces.
        /// </summary>
        public int DecimalPlaces
        {
            get { return int.Parse(GetValue(DecimalPlacesProperty).ToString()); }
            set { SetValue(DecimalPlacesProperty, value); }
        }

        /// <summary>
        /// Gets or sets if input in the control is required.
        /// </summary>
        public bool IsRequired
        {
            get { return bool.Parse(GetValue(IsRequiredProperty).ToString()); }
            set { SetValue(IsRequiredProperty, value); }
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
        /// Gets or sets if input in the control can be edited.
        /// </summary>
        public bool CanBeEdited
        {
            get { return bool.Parse(GetValue(CanBeEditedProperty).ToString()); }
            set { SetValue(CanBeEditedProperty, value); }
        }

        /// <summary>
        /// Gets or sets the database fieldname.
        /// </summary>
        public string DatabaseFieldName
        {
            get { return (string)GetValue(DatabaseFieldNameProperty); }
            set { SetValue(DatabaseFieldNameProperty, value); }
        }

        /// <summary>
        /// Gets or sets the list with the selected formulas.
        /// </summary>
        public SelectedFormulaCollection SelectedFormulas
        {
            get { return GetValue(SelectedFormulasProperty) as SelectedFormulaCollection; }
            set { SetValue(SelectedFormulasProperty, value); }
        }

        /// <summary>
        /// Gets if the control is a numeric field.
        /// </summary>
        public bool IsNumericField
        {
            get { return true; }
        }

        /// <summary>
        /// Gets or sets the input_field_id.
        /// </summary>
        public int InputFieldId
        {
            get { return int.Parse(GetValue(InputFieldIdProperty).ToString()); }
            set { SetValue(InputFieldIdProperty, value); }
        }

        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public string DescriptionText
        {
            get { return (string)GetValue(DescriptionTextProperty); }
            set { SetValue(DescriptionTextProperty, value); }
        }

    }
}
