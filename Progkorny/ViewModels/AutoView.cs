using Progkorny.Models;

namespace Progkorny.ViewModels
{
    public class AutoView
    {
        public AutoView(Auto auto)
        {
            SelectedAuto = auto;
        }

        public Auto SelectedAuto { get; }
    }
}