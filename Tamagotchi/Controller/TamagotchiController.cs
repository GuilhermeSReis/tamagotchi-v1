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
            int opcao = 0;
            do
            {
                tamagotchiView.MenuInicial();
                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        //TODO: fazer parte de adoção
                    break;
                    case 2: 
                        //TODO: fazer parte Interagir com seu Pokemon
                    break;
                    case 3: 
                        //TODO: fazer parte Ver Mascotes Adotados
                    break;
                    case 4:
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
            } while (opcao != 4);
        
        }
        

    }
}