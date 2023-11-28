using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace qwerty
{
    public class Model : INotifyPropertyChanged
    {
        private string text;
        public string Text 
        { 
            set 
            {
                text = value; 
                OnPropertyChanged("Text");
            }
            get 
            {
                return text; 
            } 
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
