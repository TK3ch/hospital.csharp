using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_CSharp
{
    using System;

    class Paciente  //Cria as caracteristicas necessarias de um paciente
    {
        public string Nome;
        public int Idade;
        public bool Preferencial;
    }

    class Program
    {
        //Cria uma fila (array) com até 15 Pacientes, caso tentem cadastrar mais de 15 pacientes uma mensagem de erro aparecera. 
        static Paciente[] fila = new Paciente[15];
        static int total = 0;

        static void Main()
        {
            while (true)
            {
                //Esse bloco cria o menu com as opções que o usuario pode escolher.
                Console.WriteLine("\n1 - Cadastrar");
                Console.WriteLine("2 - Listar");
                Console.WriteLine("3 - Atender");
                Console.WriteLine("4 - Alterar");
                Console.WriteLine("5 - Sair");
                Console.Write("Opção: ");
                string op = Console.ReadLine();

                //Cria um "IF" ligando as funções a um numero, ou seja, cada numero equivale a uma função.
                if (op == "1") Cadastrar();
                else if (op == "2") Listar();
                else if (op == "3") Atender();
                else if (op == "4") Alterar();
                else if (op == "5") break;
                else Console.WriteLine("Inválido.");
            }
        }

        //Cria o metodo de cadastro de dados dos usuarios.
        static void Cadastrar()
        {
            //Cria o limite de pacientes que podem ser cadastrados.
            if (total >= 15)
            {
                Console.WriteLine("Fila cheia!");
                return;
            }

            //Cria a area de cadastro do paciente.
            Paciente p = new Paciente();
            Console.Write("Nome: ");
            p.Nome = Console.ReadLine();
            Console.Write("Idade: ");
            p.Idade = int.Parse(Console.ReadLine());
            //Cria uma condição ligada a idade do usuario, onde caso a idade do usuario seja maior ou igual a 60 ou menor ou igual a 7 anos de idade a pessoa irá ser classificada como preferencial e ficara em primeiro na fila. 
            p.Preferencial = p.Idade >= 60 || p.Idade <= 7;
          
            if (p.Preferencial) // <= cria uma condição que verifica se a pessoa é preferencial ou não.
            {
                //cria uma condição que desloca o paciente preferencial para o inicio da fila. 
                for (int i = total; i > 0; i--)
                    fila[i] = fila[i - 1];
                fila[0] = p;
            }

            //desloca o paciente não preferencial para o final da fila. 
            else
            {
                fila[total] = p;
            }

            total++;
            Console.WriteLine("Cadastrado!"); // <= mensagem que aparece ao cadastrar o paciente.
        }

        //Cria o metodo que lista os pacientes cadastrados anteriormente.
        static void Listar()
        {
            //Verifica os pacientes cadastrados na fila e os mostra no console.
            for (int i = 0; i < total; i++)
            {
            //Mostra em qual posição o paciente está cadastrado. 
                var p = fila[i];
            //Mostra no console as informações do paciente (Nome, idade etc).
                Console.WriteLine($"{i + 1}. {p.Nome} - {p.Idade} anos - {(p.Preferencial ? "Preferencial" : "Comum")}");
            }
        }

        //Cria um metodo de atendimento ao paciente 
        static void Atender()
        {
        //Verifica se a fila está vazia (0).
            if (total == 0)
            {
        //Mensagem que irá aparecer caso a fila esteja vazia.
                Console.WriteLine("Fila vazia!");
                return;
            }

        //Exibe o nome do paciente que está em primeiro na fila (ou seja, oq foi atendido).
            Console.WriteLine($"Atendido: {fila[0].Nome}");
        //Move todos os pacientes a uma casa a frente na fila e diminuindo a quantidade pacientes na fila.
            for (int i = 0; i < total - 1; i++)
                fila[i] = fila[i + 1];
            total--;
        }

        //Cria um metodo para alterar as informações de pacientes já cadastrados.
        static void Alterar()
        {
        //Lista os pacientes cadastrados, para escolher um basta digitar o numero do cadastro.
            Listar();
            Console.Write("Número do paciente: "); // <= digita o numero do paciente que quer alterar.
            int pos = int.Parse(Console.ReadLine()) - 1;

        //Delimita a digitação do numero sendo somente valido os numeros da lista de pacientes
            if (pos < 0 || pos >= total) 
            {
                Console.WriteLine("Inválido."); // <= caso a pessoa digite um numero fora da lista de pacientes, essa msg aparecera.
                return;
            }

        //Permite o usuario cadastrar os novos dados do paciente escolhido.
        //Obs: o 'pos' é uma variavel que guarda a posição do paciente na fila.
            Console.Write("Novo nome: ");
            fila[pos].Nome = Console.ReadLine();
            Console.Write("Nova idade: ");
            fila[pos].Idade = int.Parse(Console.ReadLine());
            fila[pos].Preferencial = fila[pos].Idade >= 60 || fila[pos].Idade <= 7;

            Console.WriteLine("Alterado!"); // <= mensagem de conclusão de atualizações.
        }
    }
}