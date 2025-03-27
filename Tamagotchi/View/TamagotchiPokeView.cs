using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Tamagotchi.Model;

namespace Tamagotchi.View
{
    public class TamagotchiPokeView
    {
        string nomePessoa;
        
        private void TextoTamagotchi()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"
            ████████░▄████▄░▄██▄▄██▄░▄████▄░▄██████░▄█████▄░████████░▄█████░██░░░██░██████
            ░░░██░░░░██░░██░██░██░██░██░░██░██░░░░░░██░░░██░░░░██░░░░██░░░░░██░░░██░░░██░░
            ░░░██░░░░██░░██░██░██░██░██░░██░██░░███░██░░░██░░░░██░░░░██░░░░░███████░░░██░░
            ░░░██░░░░██████░██░██░██░██████░██░░░██░██░░░██░░░░██░░░░██░░░░░██░░░██░░░██░░
            ░░░██░░░░██░░██░██░██░██░██░░██░▀█████▀░▀█████▀░░░░██░░░░▀█████░██░░░██░██████
            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            
            Console.ResetColor();
            Console.WriteLine();
            
        }

        public void MensagemBoasVindas()
        {

            TextoTamagotchi();
            string msg1 =@"            
                                    Bem Vindo ao Tamagotchi!";
            string msg2 =@"
                        Aqui você será capaz de adotar e cuidar de seu mascote!!";

            foreach (var m in msg1)
            {
                Console.Write(m);
                Thread.Sleep(30);
            }
            foreach (var m in msg2)
            {
                Console.Write(m);
                Thread.Sleep(30);
            }
            
            Console.Write($"\n\n            Qual seu nome jogador ? ");
            
            nomePessoa = Console.ReadLine();
                
        }

        public void MenuInicial()
        {
            Console.Clear();
            TextoTamagotchi();
            Console.WriteLine("            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ MENU PRINCIPAL ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            Console.WriteLine($"\n            O que deseja escolher, {nomePessoa.ToUpper()} ?");
            Console.Write(@"
            1 - Adotar um Pokemon
            2 - Interagir com seu Pokemon
            3 - Ver Mascotes Adotados
            4 - Sair do Jogo
            
            ");
            Console.Write("Escolha uma opção:");
        }

        public void MenuPokemonEscolhido(PokemonsDetailResModel pokemon)
        {
            Console.Clear();
            TextoTamagotchi();
            Console.WriteLine("            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ MENU POKEMON ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            Console.WriteLine($"\n            O que deseja escolher, {nomePessoa.ToUpper()} ?");
            Console.WriteLine($"            1 - Adotar {pokemon.Name.ToUpper()}");
            Console.Write(@"            2 - Informação sobre o Pokemon
            3 - Voltar    
            ");
            Console.Write("Escolha uma opção: ");
        }

        public void MostrarPokemons(List<PokemonResModel> pokemons)
        {
            

            int pageSize = 20; // Número total de Pokémon por página
            int columns = 2; // Número de colunas
            int rowsPerPage = pageSize / columns;

            int totalPokemons = pokemons.Count;
            int totalPages = (int)Math.Ceiling((double)totalPokemons / pageSize);

            int currentPage = 0;

            while (true)
            {
                Console.Clear();
                TextoTamagotchi();
                Console.WriteLine("            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ POKEMONS ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n");
                Console.WriteLine($"            Página {currentPage + 1}/{totalPages}\n");

                // Exibir Pokémon em duas colunas
                for (int row = 0; row < rowsPerPage; row++)
                {
                    for (int col = 0; col < columns; col++)
                    {
                        int index = (currentPage * pageSize) + (row + col * rowsPerPage);
                        if (index < totalPokemons)
                        {
                            Console.Write($"            Pokemon {index + 1}: {pokemons[index].Name.ToUpper(),-20}");
                        }
                    }
                    Console.WriteLine();
                }

                // Navegação
                Console.WriteLine("\n            Opções: (n) Próxima Página, (p) Página Anterior, (e)escolher opção");
                var input = Console.ReadKey(true).Key;

                if (input == ConsoleKey.N && currentPage < totalPages - 1)
                {
                    currentPage++;
                }
                else if (input == ConsoleKey.P && currentPage > 0)
                {
                    currentPage--;
                }
               
                else if (input == ConsoleKey.E)
                {
                    Console.Write($"\n            Escolha um pokemon: ");
                    break;
                }
            }
           
        }

        public void MostrarDetalhePokemons(PokemonsDetailResModel pokemon)
        {
            Console.Clear();
            TextoTamagotchi();
            Console.WriteLine($"            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ {pokemon.Name.ToUpper()} ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n\n");
            Console.WriteLine($"            Base XP: {pokemon.BaseExperience}");
            Console.WriteLine($"            Altura: {pokemon.Height}");
            Console.WriteLine($"            Peso: {pokemon.Weight}");
            Console.Write($"            Habilidades: ");
            
            for (var i = 0; i < pokemon.Abilities.Count; i++)
            {
                Console.Write($"{pokemon.Abilities[i].Ability.Name}     ");
                
            }
            Console.ReadLine();
        }

        public void MensagemDeErro(){
            Console.WriteLine("            Esse pokemon não existe ou não está cadastrado!!");
            Thread.Sleep(1000);
        }

        public void MensagemDeVoltandoOuSaindo(string msg)
        {
            Console.Write($"            {msg}");
            foreach (var c in "......")
            {
                Console.Write(c);
                Thread.Sleep(500);
            }
        }

        public void MensagemOpcaoInvalida()
        {
            Console.WriteLine($"            Opção ínvalida!!!");
            Thread.Sleep(2000);
        }

        public void MensagemAdocao(PokemonsDetailResModel pokemon)
        {
            Console.Clear();
            TextoTamagotchi();
            Console.WriteLine($"            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ {pokemon.Name.ToUpper()} ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n\n");
            Console.WriteLine("                                     Parabéns! Você adotou um " + pokemon.Name + "!\n");
            Console.WriteLine("                                                ──────────────");
            Console.WriteLine("                                                ────▄████▄────");
            Console.WriteLine("                                                ──▄████████▄──");
            Console.WriteLine("                                                ──██████████──");
            Console.WriteLine("                                                ──▀████████▀──");
            Console.WriteLine("                                                ─────▀██▀─────");
            Console.WriteLine("                                                ──────────────");

            Thread.Sleep(3000);
        }

        public void MensagemVerMascote() 
        {
            Console.Clear();
            TextoTamagotchi();
            Console.WriteLine("            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ MEUS POKEMONS ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");


        }

        public void MensagemMascotesAdotados(List<TamagotchiDtoModel> pokemonsAdotados) 
        {
           
                MensagemVerMascote();
                Console.WriteLine();
                int columns = 3;
                int totalPokemons = pokemonsAdotados.Count();
                int rows = (int)Math.Ceiling((double) totalPokemons / columns);
                
                for (int row = 0; row < rows; row++ )
                {
                    for (int col = 0; col < columns; col++) 
                    {
                        int index = row * columns + col;
                        if (index < totalPokemons)
                        {
                            Console.Write($"            Pokemon {index + 1}: {pokemonsAdotados[index].Nome.ToUpper()}");
                        }
                    }
                    Console.WriteLine(); // Finaliza a linha
                }
                Console.WriteLine("\n            0 - Sair;\n");
        }

        public void MensagemMeuPokemon(TamagotchiDtoModel pokemon) 
        {
            Console.Clear();
            TextoTamagotchi();
            Console.WriteLine($"            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ {pokemon.Nome.ToUpper()} ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░");
            Console.WriteLine($"\n            O que deseja escolher, {nomePessoa.ToUpper()} ?");
            Console.WriteLine($"            1 - Informação sobre o Pokemon");
            Console.WriteLine($"            2 - Abandonar o {pokemon.Nome.ToUpper()}");
            Console.WriteLine($"            3 - Voltar");
            Console.Write("\n            Escolha uma opção: ");
            Console.ReadLine();
        }










    }
}