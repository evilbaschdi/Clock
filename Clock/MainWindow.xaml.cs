using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Threading;
using SourceChord.FluentWPF;

namespace Clock
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AcrylicWindow, INotifyPropertyChanged
    {
        private string _currentTime;

        public MainWindow()
        {
            InitializeComponent();
            var timer = new DispatcherTimer(DispatcherPriority.Background)
                                    {
                                        Interval = TimeSpan.FromSeconds(1),
                                        IsEnabled = true
                                    };
            timer.Tick += (s, e) => { UpdateTime(); };
        }

        public string CurrentTime
        {
            get => _currentTime;
            set
            {
                _currentTime = value;
                OnPropertyChanged("CurrentTime");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void UpdateTime()
        {
            CurrentTime = DateTime.Now.ToLongTimeString();
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}