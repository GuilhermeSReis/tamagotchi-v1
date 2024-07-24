using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tamagotchi.Model
{
    public class PokemonsDetailResModel
    {
        public List<AbilitiesDetail>Abilities { get; set; }
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        public bool IsDefault { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public int Weight { get; set; }
    }
    public class AbilitiesDetail
    {
        public Ability Ability { get; set; }    
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
        
    }

    public class Ability
    {
        public string Name { get; set; }
        public string Url{get;set;}
    }
}