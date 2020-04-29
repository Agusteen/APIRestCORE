using ChistesAPIRest.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Linq;

namespace ChistesAPIRest.Services
{
    public class ChisteService
    {
        private readonly IMongoCollection<Chiste> _chistes;

        public ChisteService(IChistesDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _chistes = database.GetCollection<Chiste>(settings.ChistesCollectionName);
        }

        public List<Chiste> Get() =>
            _chistes.Find(chiste => true).ToList();

        public Chiste Get(string id) =>
            _chistes.Find<Chiste>(chiste => chiste.Id == id).FirstOrDefault();

        public Chiste Create(Chiste chiste)
        {
            chiste.Likes = 0;
            chiste.Unlikes = 0;     
            chiste.Enabled = true;       
            _chistes.InsertOne(chiste);
            return chiste;
        }

        public Chiste GetRandom()
        {
            IQueryable<Chiste> query = _chistes.AsQueryable().Sample(1); 
            return query.ToList().FirstOrDefault(); 
        }

        public void Like(string id) {
            Chiste chisteUpdated = _chistes.Find<Chiste>(chiste => chiste.Id == id).FirstOrDefault();
            if(chisteUpdated == null) return;
            chisteUpdated.Likes++;
             _chistes.ReplaceOne(chiste => chiste.Id == id, chisteUpdated);
        }

        public void Unlike(string id) {
            Chiste chisteUpdated = _chistes.Find<Chiste>(chiste => chiste.Id == id).FirstOrDefault();
            if(chisteUpdated == null) return;
            chisteUpdated.Unlikes++;
            _chistes.ReplaceOne(chiste => chiste.Id == id, chisteUpdated);
        }

    }
}