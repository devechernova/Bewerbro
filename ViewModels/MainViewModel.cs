using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bewerbro.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _applicationTitle;

        public string ApplicationTitle
        {
            get { return _applicationTitle; }
            set
            {
                _applicationTitle = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            ApplicationTitle = "Bewerbro - Dein smarter Bewerbungsassistent";
        }
    }
}
