using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Console.WriteLine($"\n            O que deseja escolher,{nomePessoa} ?");
            Console.Write(@"
            1 - Adotar um Pokemon
            2 - Interagir com seu Pokemon
            3 - Ver Mascotes Adotados
            4 - Sair do Jogo
            
            ");
            Console.Write("Escolha uma opção:");
        }
    }
}