using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace Zoo_API
{
    public class Zoo_AnimalsRepo : IZoo_AnimalsRepo
    {

        private readonly IDbConnection _connection;

        // Constructor with Connection
        public Zoo_AnimalsRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        // Methods
        public IEnumerable<Zoo_Animals> GetAllAnimals()
        {
            return _connection.Query<Zoo_Animals>("SELECT * FROM zoo.zoo_animals;");
        }

        public Zoo_Animals GetAnimal(int animal_id)
        {
            return _connection.QuerySingleOrDefault<Zoo_Animals>("SELECT * FROM zoo.zoo_animals WHERE animal_id = @animal_id;", new { animal_id = animal_id });
        }

        public void InsertAnimal(Zoo_Animals animal)
        {
            _connection.Execute("INSERT INTO zoo.zoo_animals (animal_name, hair, feathers, eggs, milk, airborne, aquatic, predator, toothed, backbone, breathes, venomous, fins, legs, tail, domestic, catsize, class_type)" +
            " VALUES (@animal_name, @hair, @feathers, @eggs, @milk, @airborne, @aquatic, @predator, @toothed, @backbone, @breathes, @venomous, @fins, @legs, @tail, @domestic, @catsize, @class_type);",
                new
                {
                    animal_name = animal.animal_name,
                    hair = animal.hair,
                    feathers = animal.feathers,
                    eggs = animal.eggs,
                    milk = animal.milk,
                    airborne = animal.airborne,
                    aquatic = animal.aquatic,
                    predator = animal.predator,
                    toothed = animal.toothed,
                    backbone = animal.backbone,
                    breathes = animal.breathes,
                    venomous = animal.venomous,
                    fins = animal.fins,
                    legs = animal.legs,
                    tail = animal.tail,
                    domestic = animal.domestic,
                    catsize = animal.catsize,
                    class_type = animal.class_type,
                });
        }

        public void UpdateAnimal(Zoo_Animals animal)
        {
            _connection.Execute("UPDATE zoo.zoo_animals SET animal_name = @animal_name, hair = @hair, feathers = @feathers, eggs = @eggs, milk = @milk, airborne = @airborne, aquatic = @aquatic, predator = @predator, toothed = @toothed, backbone = @backbone, breathes = @breathes, venomous = @venomous, fins = @fins, legs = @legs, tail = @tail, domestic = @domestic, catsize = @catsize, class_type = @class_type WHERE animal_id = @animal_id",
                new
                {
                    animal_name = animal.animal_name,
                    hair = animal.hair,
                    feathers = animal.feathers,
                    eggs = animal.eggs,
                    milk = animal.milk,
                    airborne = animal.airborne,
                    aquatic = animal.aquatic,
                    predator = animal.predator,
                    toothed = animal.toothed,
                    backbone = animal.backbone,
                    breathes = animal.breathes,
                    venomous = animal.venomous,
                    fins = animal.fins,
                    legs = animal.legs,
                    tail = animal.tail,
                    domestic = animal.domestic,
                    catsize = animal.catsize,
                    class_type = animal.class_type,
                    animal_id = animal.animal_id
                });
        }

        public void DeleteAnimal(Zoo_Animals animal)
        {
            _connection.Execute("DELETE from zoo.zoo_animals WHERE animal_id = @animal_id",
                new
                {
                    animal_id = animal.animal_id
                });
        }

    }
}
