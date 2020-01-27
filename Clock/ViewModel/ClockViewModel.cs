using System;
using System.Windows.Input;
using System.Windows.Threading;
using Clock.Internal.About;
using Clock.Internal.About.View;
using Clock.Internal.Core;

namespace Clock.ViewModel
{
    /// <inheritdoc />
    /// <summary>
    ///     MainViewModel of Clock
    /// </summary>
    public class ClockViewModel : MainViewModel
    {
        private string _currentTime;
        private int _hour;
        private int _minute;
        private int _second;

        /// <summary>
        ///     Constructor
        /// </summary>
        public ClockViewModel()
        {
            InitTimer();
            AboutWindowClick = new RelayCommand(rc => ShowAboutWindow());
        }


        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
#pragma warning disable 1591
        public ICommand AboutWindowClick { get; set; }
#pragma warning restore 1591

        /// <summary>
        ///     Current time as a string
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public string CurrentTime
        {
            // ReSharper disable once UnusedMember.Global
            get => _currentTime;
            set
            {
                if (_currentTime != value)
                {
                    _currentTime = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        ///     Hour of current time
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public int Hour
        {
            // ReSharper disable once UnusedMember.Global
            get => _hour;
            set
            {
                if (_hour != value)
                {
                    _hour = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        ///     Minute of current time
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public int Minute
        {
            // ReSharper disable once UnusedMember.Global
            get => _minute;
            set
            {
                if (_minute != value)
                {
                    _minute = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        ///     Second of current time
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public int Second
        {
            // ReSharper disable once UnusedMember.Global
            get => _second;
            set
            {
                if (_second != value)
                {
                    _second = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        ///     Initializes a new DispatcherTimer to update current time
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        public void InitTimer()
        {
            var timer = new DispatcherTimer(DispatcherPriority.Background)
                        {
                            Interval = TimeSpan.FromMilliseconds(1),
                            IsEnabled = true
                        };
            timer.Tick += (s, e) => { UpdateTime(); };
        }

        private void UpdateTime()
        {
            var now = DateTime.Now;
            CurrentTime = now.ToLongTimeString();
            Hour = now.Hour;
            Minute = now.Minute;
            Second = now.Second;
        }

        private void ShowAboutWindow()
        {
            var assembly = typeof(MainWindow).Assembly;
            IAboutWindowContent aboutWindowContent = new AboutWindowContent(assembly, $@"{AppDomain.CurrentDomain.BaseDirectory}\res\clock_512.png");

            var aboutWindow = new AboutWindow
                              {
                                  DataContext = new AboutViewModel(aboutWindowContent)
                              };


            aboutWindow.ShowDialog();
        }
    }
}