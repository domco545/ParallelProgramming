using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DynamicData;
using ReactiveUI;

namespace ParallelProgramming.Gui.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ObservableCollection<long> _primes = new ObservableCollection<long>();
        public ObservableCollection<long> Primes
        {
            get => _primes;
            set => this.RaiseAndSetIfChanged(ref _primes, value);
        }

        public void OnClick_CalculateButton()
        {
            Primes.AddRange(new List<long>(){100,1000000,1000000000});
        }
    }
}