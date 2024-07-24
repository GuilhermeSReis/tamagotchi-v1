using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tamagotchi.Model;
using Tamagotchi.Service;
using Tamagotchi.View;

namespace Tamagotchi.Controller
{
    public class TamagotchiController
    {
        //Propriedades 
        private TamagotchiPokeView tamagotchiView {get;set;}
        private PokemonApiService pokemonApiService { get; set; }
        private List<PokemonResModel> pokemonsCadastrados{get;set;}

        

        //Contrutor da Controller
        public TamagotchiController()
        {
            tamagotchiView = new TamagotchiPokeView();
            pokemonApiService = new PokemonApiService();
            pokemonsCadastrados = pokemonApiService.GetPokemonDisponiveis().Results;
        }

        //Método Start Tamagotchi
        public void Start()
        {
            tamagotchiView.MensagemBoasVindas();
            string opcao ;
            do
            {
                tamagotchiView.MenuInicial();
                opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        tamagotchiView.MostrarPokemons(pokemonsCadastrados);
                        string pokemonEscolhido = Console.ReadLine();
                        if (pokemonsCadastrados.Any(x => x.Name == pokemonEscolhido))
                        {
                            var detalhePokemons = pokemonApiService.GetPokemonEscolhido(pokemonEscolhido);
                            do
                            {
                                
                                tamagotchiView.MenuPokemonEscolhido(detalhePokemons);
                                opcao = Console.ReadLine();
                                
                                switch (opcao)
                                {
                                    case "1":
                                    //TODO: fazer parte de adoção
                                    break;
                                    case "2":
                                    //TODO: fazer parte das informações
                                    break;
                                    case "3":
                                        Console.Write($"            Voltando");
                                        foreach (var c in "......")
                                        {
                                            Console.Write(c);
                                            Thread.Sleep(250);
                                        }
                                    break;
                                    default:
                                        Console.WriteLine($"            Opção ínvalida!!!");
                                        Thread.Sleep(2000);
                                    break;
                                }
                            } while (opcao != "3");
                        }else
                        {
                            Console.WriteLine($"            Esse pokemon não existe ou não está cadastrado!!");
                            Thread.Sleep(1000);
                        }
                        opcao = "";
                    break;
                    case "2": 
                        //TODO: fazer parte Interagir com seu Pokemon
                    break;
                    case "3": 
                        //TODO: fazer parte Ver Mascotes Adotados
                    break;
                    case "4":
                        Console.Write($"            Saindo");
                        foreach (var c in "......")
                        {
                            Console.Write(c);
                            Thread.Sleep(500);
                        }
                    
                    break;
                    default:
                        Console.WriteLine($"            Opção ínvalida!!!");
                        Thread.Sleep(2000);
                    break;
                }                
            } while (opcao != "4");
        
        }
        

    }
}