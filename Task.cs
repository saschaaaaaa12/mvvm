using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace qwerty
{
    public class Task: INotifyPropertyChanged, IDataErrorInfo
    {
        private string zagolovok;
        private string opisanie;
        private string date;
        private bool status;

        public string this[string columnName]
        {
            get
            {
                string err = String.Empty;

                switch (columnName)
                {
                    case "Zagolovok":
                        if (zagolovok == null || zagolovok == "")
                            err = "Заполните заголовок";
                        break;

                    case "Date":
                        if (new Regex(@"[0-9]{2}\.[0-9]{2}\.[0-9]{2}").Matches(date).Count == 0)
                            err = "Неверный формат даты";
                        break;
                }
                return err;
            }
        }

        public string Zagolovok
        {
            set
            {
                zagolovok = value;
                OnPropertyChanged("Zagolovok");
            }
            get
            {
                return zagolovok;
            }
        }

        public string Opisanie
        {
            set
            {
                opisanie = value;
                OnPropertyChanged("Opisanie");
            }
            get
            {
                return opisanie;
            }
        }

        public string Date
        {
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
            get
            {
                return date;
            }
        }

        public bool Status
        {
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
            get
            {
                return status;
            }
        }

        public string Error => throw new NotImplementedException();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
