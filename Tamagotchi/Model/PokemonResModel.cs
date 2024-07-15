using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tamagotchi.Model
{

    public class PokemonSpeciesResul 
    {
        public int Count { get; set; }
        public string Next { get; set; }

        public string Previous { get; set; }

        public List<PokemonResModel> Results{get;set;}
        
        
    }

    public class PokemonResModel
    {
        public string Name { get; set; }
        
        public string Url { get; set; }
        
    }
}