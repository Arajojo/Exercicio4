using System.Collections;
using System.ComponentModel;
using System.Data.Common;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Xml.Serialization;
using Microsoft.VisualBasic;

namespace Ex4{

    public class Ex4{

        public static void Main(String[]args){

            string nome;
            double valorUnico;
            int id;
            int continuar;
            double valorTotal;

            Funcionario func1 = new Funcionario(1, "José");
            Cliente cliente1 = new Cliente(1, "João");
            Produtos prod = new Produtos();
            Venda venda = new Venda();
            
            Console.WriteLine("\nBem vindo ao Cadastro de Vendas do Matheus Araujo Ferreira!\n\nPara começar se identifique como funcionário:\n\nQual seu nome:");
            func1.nome = Console.ReadLine();
            Console.WriteLine($"Ótimo, Bem vindo {func1.nome}, agora só me informe seu ID:");
            func1.id = int.Parse(Console.ReadLine());
            Console.WriteLine("Maravilha!\nAgora preciso das informações do cliente que esta sendo atendido.\nNome:");
            cliente1.nome = Console.ReadLine();
            Console.WriteLine("Agora qual o Id desse cliente: ");
            cliente1.id = int.Parse(Console.ReadLine());
            Console.WriteLine("Maravilha agora vamos adicionar os produtos:");

            do
            {
                Console.WriteLine("Digite o nome do produto: ");
                nome = Console.ReadLine();
                Console.WriteLine("Agora digite o id deste produto: ");
                id = int.Parse(Console.ReadLine());
                Console.WriteLine("Quanto custa este produto: ");
                valorUnico = double.Parse(Console.ReadLine());
                prod.adicionarProduto(id, nome, valorUnico); 
                Console.WriteLine($"Item {nome} Cadastrado com sucesso, com o preço R$ {valorUnico}\n\nDeseja adicionar outro produto(0 - não, 1 - sim)?");
                
                continuar = int.Parse(Console.ReadLine());

            }while (continuar == 1);
            
            venda.cliente = cliente1;
            venda.funcionario = func1;
            Console.WriteLine("Os itens da venda são:\n");
            prod.ListarProdutos();
            valorTotal = venda.valorFinal(prod.valorUnico);
            Console.WriteLine($"O valor total da Venda foi R$ {valorTotal}. Obrigado pela compra!");


        }

        //classe Produto
        public class Produtos{
            public List<int> id = new List<int>();
            public List<string> nome = new List<string>();
            public List<double> valorUnico = new List<double>();
            public Produtos(){
              
            }

            

            public Produtos(List<int> id, List<string> nome, List<double> valorUnico){
                
                this.nome = nome;
                this.id = id;
                this.valorUnico = valorUnico;
            }
            public void adicionarProduto(int id, string nome, double valorUnico){

                this.nome.Add(nome);
                this.id.Add(id);
                this.valorUnico.Add(valorUnico);
            }
            public void ListarProdutos(){

                int c = 0;
                foreach (var i in nome){
                    Console.WriteLine($"\n{c+1} - {i} R$ {valorUnico[c]}\n");
                c++;
            }
            }

        }
        
        //classe funcionario
        public class Funcionario{

            public Funcionario(){}


            public int id{get; set;}
            public string nome{get; set;}


            public Funcionario(int id, string nome){
                this.id = id;
                this.nome = nome; 
            }

        }

        //classe cliente
        public class Cliente{
            public Cliente(){}

            public int id{get; set;}
            public string nome{get; set;}

            public Cliente(int id, string nome){
                this.id = id;
                this.nome = nome;
            }
        }

        //classe Venda
        public class Venda{
            public Venda(){
                
            }

            public int id;

            public Cliente cliente = new Cliente();

            public Funcionario funcionario = new Funcionario();

            public double valorFinal(List<double> valores){
                double total = 0;
                for(int i = 0; i < valores.Count; i++){
                    total = total + valores[i];
                    
                }
                return total;
            }

        }
    }

}