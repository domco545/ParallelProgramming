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

        private int _fromInputField;
        public int FromInputField
        {
            get => _fromInputField;
            set => this.RaiseAndSetIfChanged(ref _fromInputField, value);
        }
        
        private int _toInputField;
        public int ToInputField
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
            await Task.Delay(100);
            // _primesLogic.GetPrimesSequential()

            // Primes.AddRange(new List<long>(){100,1000000,1000000000});
            // Console.WriteLine(_selectedAlgorithm.Content);
            Console.WriteLine("from: " + _fromInputField);
            Console.WriteLine("to: " + _toInputField);

            Console.WriteLine("click");

        }
    }
}