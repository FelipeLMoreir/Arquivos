using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCarros
{
    public class Carro
    {

        public int Id { get; private set; }
        public string Marca { get; private set; }
        public string Modelo { get; private set; }
        public int Ano { get; private set; }
        public string Cor { get; private set; }
        public string Placa { get; private set; }

        public Carro(int id, string marca, string modelo, 
            int ano, string cor, string placa)
        {
            Id = id;
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            Cor = cor;
            Placa = placa;
        }

        public void setCor(string cor)
        {
            Cor = cor;
        }

        public override string ToString()
        {
            return $"{Id}\n{Marca}\n{Modelo}\n{Ano}\n{Cor}\n{Placa}";
        }

        public string ToFile()
        {
            return $"{Id},{Marca},{Modelo},{Ano},{Cor},{Placa}";
        }
    }
}
