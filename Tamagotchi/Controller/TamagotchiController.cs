using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private List<TamagotchiDtoModel> pokemonsAdotados { get; set; }
        
        IMapper mapper{get;set;}

        //Contrutor da Controller
        public TamagotchiController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfileService>(); 
            });

            mapper = config.CreateMapper();

            tamagotchiView = new TamagotchiPokeView();
            pokemonApiService = new PokemonApiService();
            pokemonsCadastrados = pokemonApiService.GetPokemonDisponiveis().Results;
            pokemonsAdotados = new List<TamagotchiDtoModel>();
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
                        string pokemonEscolhido = Console.ReadLine().ToLower();

                        bool pokemonExisteporNome = pokemonsCadastrados.Any(x => x.Name == pokemonEscolhido);
                        bool pokemonExistePorIndice = int.TryParse(pokemonEscolhido, out var index) && index > 0 && index <= pokemonsCadastrados.Count;

                        if (pokemonExisteporNome || pokemonExistePorIndice)
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
                                        if (pokemonsAdotados.Any(x => x.Nome == detalhePokemons.Name))
                                        {
                                            Console.WriteLine($"            Você já possui esse pokemon!!");
                                            tamagotchiView.MensagemDeVoltandoOuSaindo("Voltando");
                                            opcao = "3";
                                        }else
                                        {
                                            TamagotchiDtoModel tamagotchi = mapper.Map<TamagotchiDtoModel>(detalhePokemons);
                                            pokemonsAdotados.Add(tamagotchi);
                                            tamagotchiView.MensagemAdocao(detalhePokemons);
                                            opcao = "3";    
                                        }
                                    break;
                                    case "2":
                                        tamagotchiView.MostrarDetalhePokemons(detalhePokemons);
                                    break;
                                    case "3":
                                        tamagotchiView.MensagemDeVoltandoOuSaindo("Voltando");
                                    break;
                                    default:
                                        tamagotchiView.MensagemOpcaoInvalida();
                                    break;
                                }
                            } while (opcao != "3");
                        }
                        else
                        {
                            tamagotchiView.MensagemDeErro();
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
                        tamagotchiView.MensagemDeVoltandoOuSaindo("Saindo");
                    break;
                    default:
                        tamagotchiView.MensagemOpcaoInvalida();
                    break;
                }                
            } while (opcao != "4");
        }
    }
}