using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Clock.ViewModel
{
    /// <inheritdoc />
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     INotifyPropertyChanged - method to synchronize UI and Property.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}