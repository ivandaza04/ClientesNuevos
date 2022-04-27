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

        public AbogadoImplement()
        {
            var client = new MongoClient("mongodb://monito:M1c43l4T13n3UnC0ch3#@3.23.228.28:27017");
            var database = client.GetDatabase("Monolegal");

            _Abogados = database.GetCollection<Abogado>("Abogados");

            ListaAbogados = new List<Abogado>();

            Abogado = new Abogado();
        }

        public List<Abogado> GetAbogados()
        {
            var Query = _Abogados.Find(Abogado => true).ToList();
            foreach (Abogado result in Query)
                ListaAbogados.Add(new Abogado(result._id, result.Activo, result.Nombre, result.Email, result.Ciudad));
            return ListaAbogados;
        }
    }
}
