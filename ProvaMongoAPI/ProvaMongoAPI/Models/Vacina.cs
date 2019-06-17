using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaMongoAPI.Models
{
    public class Vacina
    {
        public ObjectId Id { get; set; }
        public int idAnimal { get; set; }
        public Double peso { get; set; }
        public Double dosagem { get; set; }
        public string aplicador { get; set; }
        public string descricaoMedicamento { get; set; }
    }
}
