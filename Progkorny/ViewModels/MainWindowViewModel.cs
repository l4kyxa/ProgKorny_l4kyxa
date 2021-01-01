using Progkorny.Assets;
using ReactiveUI;

namespace Progkorny.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private string _message = "";
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                ((IReactiveObject) this).RaisePropertyChanged(nameof(Message));
            }
        }

        public AutoViewModel List { get; }

        public MainWindowViewModel(AutoManager db)
        {
            List = new AutoViewModel(db.autok());
        }

        public string Greeting => "";
    }
}