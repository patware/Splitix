using GalaSoft.MvvmLight;
using Splitix.Model;

namespace Splitix.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly Service.IInputParser _parser;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService, Service.IInputParser parser)
        {
            
            _dataService = dataService;
            _parser = parser;

            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    Input = item.InitialInput;
                    this.NumberOfItems = item.InitialNumberOfItems;
                    
                });

            this.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(MainViewModel_PropertyChanged);

            
        }

        void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case OutputPropertyName:
                    break;

                default:
                    doParse();
                    break;
            }
        }

        private void doParse()
        {
            var axis = (Splitix.Service.Axis)this.SelectedAxisIndex;
            var orientation = (Splitix.Service.Orientation)this.SelectedFillByIndex;

            this.Output = _parser.Parse(this.Input, this.NumberOfItems, axis, orientation);
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}

        #region Properties
        #region Input
        /// <summary>
        /// The <see cref="Input" /> property's name.
        /// </summary>
        public const string InputPropertyName = "Input";

        private string _input;

        /// <summary>
        /// Sets and gets the Input property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Input
        {
            get
            {
                return _input;
            }

            set
            {
                if (_input == value)
                {
                    return;
                }

                RaisePropertyChanging(InputPropertyName);
                _input = value;
                RaisePropertyChanged(InputPropertyName);
            }
        }
        #endregion
        #region NumberOfItems
        /// <summary>
        /// The <see cref="NumberOfItems" /> property's name.
        /// </summary>
        public const string NumberOfItemsPropertyName = "NumberOfItems";

        private int _numberOfItems;

        /// <summary>
        /// Sets and gets the NumberOfItems property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int NumberOfItems
        {
            get
            {
                return _numberOfItems;
            }

            set
            {
                if (_numberOfItems == value)
                {
                    return;
                }

                RaisePropertyChanging(NumberOfItemsPropertyName);
                _numberOfItems = value;
                RaisePropertyChanged(NumberOfItemsPropertyName);
            }
        }
        #endregion
        #region SelectedAxisIndex
        /// <summary>
        /// The <see cref="SelectedAxisIndex" /> property's name.
        /// </summary>
        public const string SelectedAxisIndexPropertyName = "SelectedAxisIndex";

        private int _selectedAxisIndex;

        /// <summary>
        /// Sets and gets the SelectedAxisIndex property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int SelectedAxisIndex
        {
            get
            {
                return _selectedAxisIndex;
            }

            set
            {
                if (_selectedAxisIndex == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedAxisIndexPropertyName);
                _selectedAxisIndex = value;
                RaisePropertyChanged(SelectedAxisIndexPropertyName);
            }
        }
        #endregion
        #region SelectedFillByIndex
        /// <summary>
        /// The <see cref="SelectedFillByIndex" /> property's name.
        /// </summary>
        public const string SelectedFillByIndexPropertyName = "SelectedFillByIndex";

        private int _selectedFillByIndex;

        /// <summary>
        /// Sets and gets the SelectedFillByIndex property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int SelectedFillByIndex
        {
            get
            {
                return _selectedFillByIndex;
            }

            set
            {
                if (_selectedFillByIndex == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedFillByIndexPropertyName);
                _selectedFillByIndex = value;
                RaisePropertyChanged(SelectedFillByIndexPropertyName);
            }
        }
        #endregion
        #region Output
        /// <summary>
        /// The <see cref="Output" /> property's name.
        /// </summary>
        public const string OutputPropertyName = "Output";

        private string _output;

        /// <summary>
        /// Sets and gets the Output property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Output
        {
            get
            {
                return _output;
            }

            set
            {
                if (_output == value)
                {
                    return;
                }

                RaisePropertyChanging(OutputPropertyName);
                _output = value;
                RaisePropertyChanged(OutputPropertyName);
            }
        }
        #endregion
        #endregion
    }
}