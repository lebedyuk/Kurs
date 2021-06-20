using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Recept
{
    public class Ingridient: INotifyPropertyChanged
    {
        private string _name;
        private double _number;
        private string _ed; 
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public double Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }
        public string Ed
        {
            get
            {
                return _ed;
            }
            set
            {
                _ed = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return $"{_name} {_number} {_ed}";
        }
        public Ingridient() { }

        public Ingridient(string name, double number, string ed)
        {
            _name = name;
            _number = number;
            _ed = ed;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
