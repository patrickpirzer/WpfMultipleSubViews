﻿using System.Collections.ObjectModel;
using System.ComponentModel;

namespace P16Admintool.ViewModels
{
    /// <summary>
    /// Class for the viewmodel of the StepFunctionsView.xaml.
    /// </summary>
    public class StepFunctionsViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Eventhandler for signalising that a property has changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Field for the data of the stepfunction.
        /// </summary>
        private ObservableCollection<StepData> stepdataSource = new ObservableCollection<StepData>();

        /// <summary>
        /// The constructor.
        /// </summary>
        public StepFunctionsViewModel()
        {
            IsInsertMode = false;
            IsUpdateMode = false;
            CurrentCellChanged = false;
            FillLowerComparersList();
            FillLowerComparerItemsList();
        }

        /// <summary>
        /// Gets or sets the data of the stepfunction.
        /// </summary>
        public ObservableCollection<StepData> StepDataSource
        {
            get { return stepdataSource; }
            set
            {
                stepdataSource = value;
                RaisePropertyChanged("StepDataSource");
            }
        }

        /// <summary>
        /// Gets the list with the arithmetic lower comparers.
        /// </summary>
        public ObservableCollection<string> LowerComparers { get; set; }

        /// <summary>
        /// Gets the list with the arithmetic lower comparers.
        /// </summary>
        public ObservableCollection<ArithmeticSignData> LowerComparerItems { get; set; }

        /// <summary>
        /// Gets or sets if an item in the datagrid is inserted.
        /// </summary>
        public bool IsInsertMode { get; set; }

        /// <summary>
        /// Gets or sets if an item in the datagrid is updated.
        /// </summary>
        public bool IsUpdateMode { get; set; }

        /// <summary>
        /// Gets or sets if the datagrid's CurrentCell-property was changed.
        /// </summary>
        public bool CurrentCellChanged { get; set; }

        /// <summary>
        /// Informs the target which is bound to a property, that it's source was changed and that it shall update.
        /// </summary>
        /// <param name="propertyName">The name of the property.</param>
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Fills the list with the arithemtic lower comparers.
        /// </summary>
        private void FillLowerComparersList()
        {
            LowerComparers = new ObservableCollection<string>();
            LowerComparers.Add("<");
            LowerComparers.Add("<=");
        }

        /// <summary>
        /// Fills the list with the arithmetic lower comparers.
        /// </summary>
        private void FillLowerComparerItemsList()
        {
            LowerComparerItems = new ObservableCollection<ArithmeticSignData>();
            LowerComparerItems.Add(new ArithmeticSignData("1", "<"));
            LowerComparerItems.Add(new ArithmeticSignData("2", "<="));
        }

    }
}
