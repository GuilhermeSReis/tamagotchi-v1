using System;
using System.Collections.Generic;
using System.Linq;
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
                Thread.Sleep(100);
            }
            foreach (var m in msg2)
            {
                Console.Write(m);
                Thread.Sleep(100);
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
            Console.Clear();
            TextoTamagotchi();
            Console.WriteLine("            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ POKEMONS ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n");

            int columns = 2;
            int rows = (int)Math.Ceiling((double)pokemons.Count / columns);

            for(var row = 0; row < rows;row++)
            {
                for (var col  = 0; col < columns; col++)
                {
                    int index = row + col * rows;
                    if (index < pokemons.Count)
                    {
                        Console.Write($"            Pokemon {index + 1}: {pokemons[index].Name.ToUpper(),-20}");
                    }
                }
                Console.WriteLine();
            }

            Console.Write($"\n            Escolha uma opção: ");
            
        }

        public void MostrarDetalhePokemons(PokemonsDetailResModel pokemon)
        {
            Console.Clear();
            TextoTamagotchi();
            Console.WriteLine($"            ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░ {pokemon.Name.ToUpper()} ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░\n\n");
            Console.WriteLine($"                                    Base XP: {pokemon.BaseExperience}");
            Console.WriteLine($"                                    Altura: {pokemon.Height}            Peso: {pokemon.Weight}");
            Console.Write($"                                    Habilidades: ");
            
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

            Thread.Sleep(5000);
        }
    }
}