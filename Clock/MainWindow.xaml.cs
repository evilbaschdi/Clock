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
        private string _currenttime;
        private TimeZoneInfo _selectedTimeZone;

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.IsEnabled = true;
            timer.Tick += (s, e) => { UpdateTime(); };
        }

        public string CurrentTime
        {
            get { return _currenttime; }
            set
            {
                _currenttime = value;
                OnPropertyChanged("CurrentTime");
            }
        }

        public TimeZoneInfo SelectedTimeZone
        {
            get { return _selectedTimeZone; }
            set
            {
                _selectedTimeZone = value;
                OnPropertyChanged("SelectedTimeZone");
                UpdateTime();
            }
        }

        public List<TimeZoneInfo> TimeZones
        {
            get { return TimeZoneInfo.GetSystemTimeZones().ToList(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void UpdateTime()
        {
            CurrentTime = SelectedTimeZone == null
                ? DateTime.Now.ToLongTimeString()
                : DateTime.UtcNow.AddHours(SelectedTimeZone.BaseUtcOffset.TotalHours).ToLongTimeString();
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}