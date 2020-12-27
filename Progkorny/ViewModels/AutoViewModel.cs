using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Progkorny.Models;

namespace Progkorny.ViewModels
{
    public class AutoViewModel
    {
        public AutoViewModel(IEnumerable<Auto> autok)
        {
            Autok = new ObservableCollection<Auto>(autok);
        }

        public ObservableCollection<Auto> Autok {get;}
    }
}