using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia.Controls;
using DynamicData;
using ReactiveUI;

namespace ParallelProgramming.Gui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
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
        private ObservableCollection<long> _primes = new ObservableCollection<long>();
        public ObservableCollection<long> Primes
        {
            get => _primes;
            set => this.RaiseAndSetIfChanged(ref _primes, value);
        }

        public async Task OnClick_CalculateButton()
        {
            await Task.Delay(1000);
            Primes.AddRange(new List<long>(){100,1000000,1000000000});
            Console.WriteLine(_selectedAlgorithm.Content);
        }
    }
}