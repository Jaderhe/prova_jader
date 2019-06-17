using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaMongoAPI.Models
{
    public class MongoContext
    {
        private IMongoDatabase _database { get; }
        public MongoContext()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl("mongodb://localhost:27017"));
            var mongoClient = new MongoClient(settings);
            _database = mongoClient.GetDatabase("Vacina");
        }

        public IMongoCollection<Vacina> Vacinas
        {
            get
            {
                return _database.GetCollection<Vacina>("vacinas");
            }

        }
    }
}
