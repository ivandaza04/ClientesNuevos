using ClientesNuevos.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesNuevos.Implement
{
    public class AbogadoImplement
    {
        private readonly IMongoCollection<Abogado> _Abogados;
        private List<Abogado> ListaAbogados;
        private Abogado Abogado;

        public AbogadoImplement(SettingsDatabase abogadosDatabase)
        {
            var client = new MongoClient(abogadosDatabase.ConnectionString);
            var database = client.GetDatabase(abogadosDatabase.MonolegalDatabaseName);

            _Abogados = database.GetCollection<Abogado>(abogadosDatabase.AbogadosCollectionName);

            ListaAbogados = new List<Abogado>();
        }

        public List<Abogado> GetAbogados()
        {
            var Query = _Abogados.Find(Abogado => true).ToList();
            foreach (Abogado result in Query)
                ListaAbogados.Add(new Abogado(result._id, result.Activo, result.Nombre, result.Email, result.Ciudad));
            return ListaAbogados;
        }

        public Abogado CreateAbogado(Abogado abogado)
        {
            _Abogados.InsertOne(abogado);
            return abogado;
        }
    }
}
