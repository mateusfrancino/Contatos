using System;
using System.Collections.Generic;
using System.Linq;

namespace teste
{
    class Program
    {
        private static List<Cliente> clientes = new List<Cliente>();
        static void Main(string[] args)
        {
            bool fechar = false;
            while (true)
            {
                if (fechar)
                {
                    break;
                }
                Console.WriteLine("1 - Cadastrar Cliente");
                Console.WriteLine("2 - Ver Cliente");
                Console.WriteLine("3 - Ver Clientes");
                Console.WriteLine("4 - Remover Cliente");
                Console.WriteLine("5 - Fechar");
                var opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        {
                            var cliente = new Cliente();
                            Console.WriteLine("Qual é o nome?");
                            cliente.Nome = Console.ReadLine();
                            Console.WriteLine("Qual é a Idade?");
                            cliente.Idade = byte.Parse(Console.ReadLine());
                            clientes.Add(cliente);
                            Console.WriteLine("Cliente adicionado com sucesso!");
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Digite o nome do cliente");
                            var nome = Console.ReadLine();
                            var cliente = clientes.FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());
                            if (cliente == null)
                            {
                                Console.WriteLine("Cliente não existe!");
                                break;
                            }
                            bool sair = false;
                            while (true)
                            {
                                if (sair)
                                {
                                    break;
                                }
                                Console.WriteLine("1 - Cadastrar Contato");
                                Console.WriteLine("2 - Ver Contatos");
                                Console.WriteLine("3 - Remover Contato");
                                Console.WriteLine("4 - Voltar");

                                var opcaoContato = int.Parse(Console.ReadLine());
                                switch (opcaoContato)
                                {
                                    case 1:
                                        {
                                            var contato = new Contato();
                                            Console.WriteLine("Informe um nome");
                                            contato.Nome = Console.ReadLine();
                                            var relacionamentos = Enum.GetValues(typeof(TipoRelacionamento)).Cast<TipoRelacionamento>();
                                            Console.WriteLine($"Informe um tipo de relacionamento: {string.Join(", ", relacionamentos)}");
                                            var relacionamento = Console.ReadLine();
                                            contato.TipoRelacionamento = relacionamentos.SingleOrDefault(x => x.ToString().ToLower() == relacionamento.ToLower());
                                            Console.WriteLine("Informe um numero");
                                            contato.Numero = Console.ReadLine();
                                            cliente.AddContato(contato);
                                            Console.WriteLine("O contato foi adicionado com sucesso");
                                            break;
                                        }
                                    case 2:
                                        {
                                            var contatos = cliente.GetContatos();
                                            if (contatos.Count == 0)
                                            {
                                                Console.WriteLine("Não possui nenhum contato");
                                            }
                                            foreach (var contato in contatos)
                                            {
                                                Console.WriteLine($"{contato.Codigo}-{contato.Nome}({contato.TipoRelacionamento}): {contato.Numero}");
                                            }
                                            break;
                                        }
                                    case 3:
                                        {

                                            Console.WriteLine("Digite o codigo do contato");
                                            var codigo = int.Parse(Console.ReadLine());
                                            cliente.RemoveContato(codigo);

                                            Console.WriteLine("Cliente removido com sucesso!");
                                            break;
                                        }
                                    case 4:
                                        {
                                            sair = true;
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("Você precisa informar uma das opções");
                                            break;
                                        }


                                }
                            }
                            break;

                        }
                    case 3:
                        {
                            if (clientes.Count == 0)
                            {
                                Console.WriteLine("Não possui nenhum cliente");
                            }
                            foreach (var cliente in clientes)
                            {
                                Console.WriteLine($"{cliente.Nome} ({cliente.Idade} anos)");
                            }
                            break;

           
                        }
                    case 4:
                        {
                            Console.WriteLine("Digite o nome do cliente");
                            var nome = Console.ReadLine();
                            var cliente = clientes.FirstOrDefault(x => x.Nome.ToLower() == nome.ToLower());
                            if (cliente == null)
                            {
                                Console.WriteLine("Cliente não existe!");
                                break;
                            }

                            Console.WriteLine("Cliente removido com sucesso!");
                            break;
                        }
                    case 5:
                        {
                            fechar = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Você precisa informar uma opção válida!");
                            break;
                        }

                }

            }
        }
    }
}
