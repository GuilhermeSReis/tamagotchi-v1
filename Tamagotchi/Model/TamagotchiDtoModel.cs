using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tamagotchi.Model
{
    public class TamagotchiDtoModel
    {
        public string Nome { get; set; }
        public int Altura {get;set;}
        public int Peso { get; set; }
        public int XpBase { get; set; }
        public List<AbilitiesDetail> Habilidades { get; set; }
    
    }
}