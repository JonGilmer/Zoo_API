using System;
using System.Collections.Generic;

namespace Zoo_API
{
    public interface IZoo_AnimalsRepo
    {

        public IEnumerable<Zoo_Animals> GetAllAnimals();
        public Zoo_Animals GetAnimal(int animal_id);
        public void InsertAnimal(Zoo_Animals animal);
        public void UpdateAnimal(Zoo_Animals animal);
        public void DeleteAnimal(Zoo_Animals animal);

    }
}
