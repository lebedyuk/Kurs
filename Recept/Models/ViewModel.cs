using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Recept
{
    public class ViewModel
    {
        //списки рецептов
        private ObservableCollection<OneRecept> recepts = new ObservableCollection<OneRecept>();
        public ViewModel()
        {
            recepts.Add(new OneRecept
            {
                Name = "Салат Щастя",
                Type = "Борщ",
                Kitchen = "Англ",
                Instruction = "Бла-бла",
                Like = false,
                
              
            });

            recepts.Add(new OneRecept
            {
                Name = "Салат Воля",
                Type = "Салат",
                Kitchen = "Англ",
                Instruction = "Бла-бла",
                Like = true,


            });

            recepts.Add(new OneRecept
            {
                Name = "Суп",
                Type = "Борщ",
                Kitchen = "Англ",
                Instruction = "Бла-бла",
                Like = false,


            });

            findByName = new RelayCommand(o => Find_ByName());
            findByLike = new RelayCommand(o => Find_ByMyLike());
            addRec = new RelayCommand(o => Add_Recept());
            TextBoxText = "Поиск рецепта";
        }

        public IEnumerable<OneRecept> OneRecept => recepts;
        public OneRecept SelectedRecept { get; set; }

        //списки  ингридиентов текущего рецепта
        private ObservableCollection<Ingridient> ingridients = new ObservableCollection<Ingridient>();
        public IEnumerable<Ingridient> Ingridients => ingridients;
        public Ingridient OneIngridident { get; set; }

        //поиск по имени
        RelayCommand findByName;
        public ICommand FindByName => findByName;
        public string TextBoxText;

        public void Find_ByName()
        {
            if (TextBoxText == "Поиск рецепта")
                return;
            for(int i = 0; i < recepts.Count; i++)
            {
                if (!recepts[i].Name.Contains(TextBoxText))
                {
                    recepts.Remove(recepts[i]);
                }
            }
        }

        //поиск по любимым
        bool is_like = false;
        RelayCommand findByLike;
        public ICommand FindByLike => findByLike;
        public void Find_ByMyLike()
        {
            for (int i = 0; i < recepts.Count; i++)
            {
                //улюблені рецепти
                if(!is_like)
                if (!recepts[i].Like)
                {
                    recepts.Remove(recepts[i]);
                }

                //всі рецепти
                //TODO
            }
        }

        //добавить рецепт
        RelayCommand addRec;
        public ICommand AddRecept => addRec;
        public void Add_Recept()
        {
            SelectedRecept = new OneRecept();
            SelectedRecept.Name = "Введите название блюда";
            SelectedRecept.Instruction = "Как готовить не известно";
            SelectedRecept.Kitchen = "К какой кухне отнести?";
            SelectedRecept.Like = false;
            SelectedRecept.Type = "Тип блюда";

            WindowOneRecept w = new WindowOneRecept();
            if (w.ShowDialog() == true)
            {
                recepts.Add(SelectedRecept);
            }
        }
    }
}
