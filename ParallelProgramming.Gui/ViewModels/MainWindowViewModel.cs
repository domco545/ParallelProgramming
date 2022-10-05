using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Media;
using DynamicData;
using ParallelProgramming.Core;
using ReactiveUI;

namespace ParallelProgramming.Gui.ViewModels
{
    // comment
    public class MainWindowViewModel : ViewModelBase
    {
        // logic instance
        private readonly Primes _primesLogic;

        public MainWindowViewModel()
        {
            _primesLogic = new Primes();
        }

        private ComboBoxItem _selectedAlgorithm;

        public ComboBoxItem SelectedAlgorithm
        {
            get => _selectedAlgorithm;
            private set
            {
                var res = value;
                this.RaiseAndSetIfChanged(ref _selectedAlgorithm, value);
            }
        }

        private long _fromInputField;

        public long FromInputField
        {
            get => _fromInputField;
            set => this.RaiseAndSetIfChanged(ref _fromInputField, value);
        }

        private long _toInputField;

        public long ToInputField
        {
            get => _toInputField;
            set => this.RaiseAndSetIfChanged(ref _toInputField, value);
        }

        private ObservableCollection<long> _primes = new ObservableCollection<long>();

        public ObservableCollection<long> Primes
        {
            get => _primes;
            set => this.RaiseAndSetIfChanged(ref _primes, value);
        }

        public async Task OnClick_CalculateButton()
        {
            await Task.Delay(1);
            if (_selectedAlgorithm.Content.ToString() == "Sequential")
            {
                var resultSequential = _primesLogic.GetPrimesSequential(_fromInputField, _toInputField);
                Primes.AddRange(resultSequential);

            }
            else
            {
                var resultParallel = _primesLogic.GetPrimesParallel(_fromInputField, _toInputField);
                Primes.AddRange(resultParallel);

            }
        }
    }
}