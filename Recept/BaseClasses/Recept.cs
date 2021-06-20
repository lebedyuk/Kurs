using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Recept
{
    [Serializable]
    public class OneRecept: INotifyPropertyChanged
    {
        private string name;
        private string type;
        private string kitchen;
        private string instruction;
        private bool like;
        private List<string> images;
        private ObservableCollection<Ingridient> ingridients;
        public string Name { get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                if (type != value)
                {
                    type = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Kitchen
        {
            get { return kitchen; }
            set
            {
                if (kitchen != value)
                {
                    kitchen = value;
                    OnPropertyChanged();
                }
            }
        }
        public List<string> Images { get; }
        public string FirstImage
        {
            get
            {
                if (images != null)
                    return images[0];
                else
                    return @"Resources\null.png";
            }
        }
        public void AddImage(string image)
        {
            if (images == null)
                images = new List<string>();
            if (!images.Contains(image))
            {
                images.Add(image);
                OnPropertyChanged(nameof(FirstImage));
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Ingridient> Ingridients { get; }
        public void AddIngridient(Ingridient ingridient)
        {
            if (!ingridients.Contains(ingridient))
            {
                ingridients.Add(ingridient);
                OnPropertyChanged(nameof(ingridients));
                OnPropertyChanged();
            }
        }
        public string Instruction
        {
            get { return instruction; }
            set
            {
                if (instruction != value)
                {
                    instruction = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool Like
        {
            get { return like; }
            set
            {
                if (like != value)
                {
                    like = value;
                    OnPropertyChanged();
                }
            }
        }
        public OneRecept()
        {
            ingridients = new ObservableCollection<Ingridient>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
