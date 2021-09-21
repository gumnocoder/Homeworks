using System.ComponentModel;

namespace Homework_11_ConsUI.employeBin
{
    /// <summary>
    /// содержит событие которое будет информировать об изменении свойств
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void onPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}