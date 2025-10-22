using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCarros
{
    internal class Locadora
    {
        public List<Carro> Carros { get; } = new List<Carro>();

        public Locadora(List<Carro> carros)
        {
            this.Carros = carros;
        }

        public void CadastrarCarro()
        {
            Console.WriteLine("Digite o Id do carro: ");
            var id = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite a marca do carro: ");
            var marca = Console.ReadLine()!;
            Console.WriteLine("Digite o Modelo do carro:");
            var modelo = Console.ReadLine()!;
            Console.WriteLine("Digite o ano do carro: ");
            var ano = int.Parse(Console.ReadLine()!);
            Console.WriteLine("Digite a cor do carro: ");
            var cor = Console.ReadLine()!;
            Console.WriteLine("Digite a palca do carro: ");
            var placa = Console.ReadLine()!;

            this.Carros.Add( new Carro(id, marca, modelo, ano, cor, placa));
        }
        public void ListarTodosCarros()
        {
            foreach (var carro in this.Carros)
            {
                Console.WriteLine(carro + "\n");
            }
        }
        private Carro BuscarCarro(int id)
        {
            return this.Carros.Find(c => c.Id == id)!;
        }
        public void AtualizarCarro()
        {
            Console.WriteLine("Qual o Id do carro: ");
            var id = int.Parse(Console.ReadLine()!);
            var carro = BuscarCarro(id);

            if (carro is null)
            {
                Console.WriteLine("Carro não encontrado");
            }
            else
            {
                Console.WriteLine("Qual a nova cor do carro");
                var corNova = Console.ReadLine()!;
                carro.setCor(corNova);
                Console.WriteLine(carro);
            }
        }
        public void RemoverCarro()
        {
            Console.WriteLine("Digite o id do carro que deseja remover");
            var id = int.Parse(Console.ReadLine()!);
            var carro = BuscarCarro(id);
            if (carro is null)
            {
                Console.WriteLine("Carro não existe!");
            }
            else
            {
                this.Carros.Remove(carro);
                Console.WriteLine("Carro removido com sucesso!");
            }
        }
    }
}
