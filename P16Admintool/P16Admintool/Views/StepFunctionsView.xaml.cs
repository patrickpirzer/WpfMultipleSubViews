using P16Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using P16Admintool.ViewModels;
using System.Windows.Forms.DataVisualization.Charting;

namespace P16Admintool.Views
{
    /// <summary>
    /// Class for the view to administrate the stepfunctions.
    /// </summary>
    public partial class StepFunctionsView : UserControl, IView
    {
        #region Fields

        /// <summary>
        /// Field for an instance of the viewmodel-class.
        /// </summary>
        private StepFunctionsViewModel vm;

        #endregion

        #region Events

        /// <summary>
        /// Event for closing this view.
        /// </summary>
        public event EventHandler<ViewClosingEventArgs> ViewCloseEvent;

        #endregion

        #region Constructor

        /// <summary>
        /// The constructor.
        /// </summary>
        public StepFunctionsView()
        {
            // The view is initailized.
            InitializeComponent();

            // Creates an instance of the viewmodel-class and sets the datacontext.
            vm = new StepFunctionsViewModel();
            DataContext = vm;

            // Prepares some testdata for the datagrid.
            vm.StepDataSource.Add(new StepData("<", 0, 0, vm.LowerComparerItems.FirstOrDefault(x => x.ArithmeticSignKey == "1")));
            vm.StepDataSource.Add(new StepData("<=", 0.1, 0.8, vm.LowerComparerItems.FirstOrDefault(x => x.ArithmeticSignKey == "2")));
            vm.StepDataSource.Add(new StepData("<", 0.2, 1.2, vm.LowerComparerItems.FirstOrDefault(x => x.ArithmeticSignKey == "1")));
            vm.StepDataSource.Add(new StepData("<=", 0.3, 1.4, vm.LowerComparerItems.FirstOrDefault(x => x.ArithmeticSignKey == "2")));

            ChartDataRefresh();
        }

        #endregion

        #region Properties

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

        #region Private methods

        /// <summary>
        /// As the view was loaded the cursor is set in the datagrid for adding stepfunction data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Sets the focus to the first cell of the gridrow for adding data.
            grd_stepdata_SetFocus();

            if (grd_stepdata.SelectionUnit == DataGridSelectionUnit.FullRow)
            {
                grd_stepdata.SelectedItems.Clear(); // Just work while the datagrid's SelectionUnit is "FullRow"
            }
        }

        /// <summary>
        /// Closes this view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            if (ViewCloseEvent != null)
            {
                ViewClosingEventArgs eventargs = new ViewClosingEventArgs();
                eventargs.SubviewKey = Constants.keyStepFunctions;
                ViewCloseEvent(this, eventargs);
            }
        }

        /// <summary>
        /// Start adding a new item in the datagrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grd_stepdata_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            vm.IsInsertMode = true;
        }

        /// <summary>
        /// Start editing an existing item in the datagrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grd_stepdata_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            // Sets IsUpdateMode only if no insert action is running.
            // In case of an insert the events AddingNewItem and BeginningEdit are fired one by one.
            // In case of update only BeginningEdit is fired.
            if (!vm.IsInsertMode)
            {
                vm.IsUpdateMode = true;
            }
        }

        /// <summary>
        /// Analyzes the keydown in the datagrid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grd_stepdata_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // With the Enter-key the user can navigate in a gridrow from one cell to the next.
            // When the gridrow's final cell was reached, the cursor jumps to the next gridrow.
            var uiElement = e.OriginalSource as UIElement;

            if (e.Key == Key.Enter &&
                uiElement != null)
            {
                var maxColIndex = grd_stepdata.Columns.Count - 1;
                bool doMoveNext = true;

                if (vm.IsInsertMode && grd_stepdata.CurrentCell.Column.DisplayIndex == maxColIndex)
                    doMoveNext = false;

                if (doMoveNext)
                {
                    e.Handled = true;
                    uiElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                }
            }

            // The selected row will be deleted from the datagrid.
            if (e.Key == Key.Delete)
            {
                // Refreshes the chart control.
                ChartDataRefresh();
            }
        }

        /// <summary>
        /// When the user leaves a DataGrid-row after insert or update the chart shall be refreshed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grd_stepdata_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            // If the CurrentCell-property of the datagrid was changed by the method grd_stepdata_SetFocus the RowEditEnding-event is fired one more time.
            // But this method shall not be executed twice, so it is interrupted here.
            if (vm.CurrentCellChanged)
            {
                return;
            }

            // Just executed when the EditAction is not Cancel.
            if (e.EditAction == DataGridEditAction.Cancel)
            {
                vm.IsInsertMode = false;
                vm.IsUpdateMode = false;
                return;
            }

            // Refreshes the chart control.
            ChartDataRefresh();

            // Clears the selected cells.
            if (grd_stepdata.SelectionUnit == DataGridSelectionUnit.Cell)
            {
                grd_stepdata.SelectedCells.Clear(); // Just works while the datagrid's SelectionUnit is "Cell"
            }

            // Clears the selected items (= rows).
            if (grd_stepdata.SelectionUnit == DataGridSelectionUnit.FullRow)
            {
                grd_stepdata.SelectedItems.Clear(); // Just works while the datagrid's SelectionUnit is "FullRow"
            }

            // Sets the focus to the first cell of the gridrow for adding data.
            grd_stepdata_SetFocus();
        }

        /// <summary>
        /// After editing of a cell the chart shall be refreshed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void grd_stepdata_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (!vm.IsInsertMode && vm.IsUpdateMode)
            {
                // Refreshes the chart control while update of an existing datagrid item.
                ChartDataRefresh();
            }
        }

        /// <summary>
        /// Sets the focus to the first cell of the gridrow for adding data.
        /// </summary>
        private void grd_stepdata_SetFocus()
        {
            int rowIndex = 0;

            // Sets the rowindex for insert.
            // To the first cell in the adding row.
            if (vm.IsInsertMode)
                rowIndex = grd_stepdata.Items.Count - 1;

            // Sets the rowindex for update.
            // Same cell but the next row.
            if (!vm.IsInsertMode && vm.IsUpdateMode)
                rowIndex = grd_stepdata.Items.IndexOf(grd_stepdata.CurrentItem);

            grd_stepdata.Focus();
            vm.CurrentCellChanged = true;
            grd_stepdata.CurrentCell = new DataGridCellInfo(grd_stepdata.Items[rowIndex], grd_stepdata.Columns[0]);
            vm.CurrentCellChanged = false;

            if (grd_stepdata.SelectionUnit == DataGridSelectionUnit.FullRow)
            {
                grd_stepdata.SelectedIndex = rowIndex; // Just work while the datagrid's SelectionUnit is "FullRow", not with "Cell"
            }

            vm.IsInsertMode = false;
            vm.IsUpdateMode = false;
        }

        /// <summary>
        /// Refreshes the chart control.
        /// </summary>
        private void ChartDataRefresh()
        {
            Chart myWinformChart = new Chart();
            myWinformChart.Dock = System.Windows.Forms.DockStyle.Fill;
            Series mySeries = new Series("series");
            mySeries.ChartType = SeriesChartType.Point;
            myWinformChart.Series.Add(mySeries);
            ChartArea myArea = new ChartArea();
            myWinformChart.ChartAreas.Add(myArea);
            myWinformChart.DataSource = vm.StepDataSource;
            myWinformChart.Series["series"].XValueMember = "LowerBound";
            myWinformChart.Series["series"].YValueMembers = "StepValue";
            host.Child = myWinformChart;
        }

        #endregion

    }
}
