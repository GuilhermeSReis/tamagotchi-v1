using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Tamagotchi.Model;

namespace Tamagotchi.Service
{
    public class PokemonApiService
    {
        /* 
            Toda a parte de serviço com a ApiPokemon, será realizada nessa classe. Seja Post ou Get
            Path da Api: https://pokeapi.co/api/v2/pokemon/{nomePokemon}
        */

        string pathApi = "https://pokeapi.co/api/v2/pokemon/";

        public PokemonSpeciesResul GetPokemonDisponiveis()
        {
            try
            {
                //Criando e preparando o camingo para a request com RestSharp 
                var client = new RestClient(pathApi);
                //Fazendo o request
                var request = new RestRequest("", Method.Get);
                //Execultando a Request e recebendo uma Response
                var response = client.Execute(request);
                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //Dezerializando o json para objeto
                    var pokemonResposta = JsonConvert.DeserializeObject<PokemonSpeciesResul>(response.Content);
                    return pokemonResposta;
                }
                Console.WriteLine($"Erro de status,não foi póssivel obter a lista. {response.Content} ");
                return null;
            }
            catch(HttpRequestException ex)
            {
                Console.WriteLine($"Erro no request. {ex.Message}");
                return null;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro não previsto. {ex.Message}");
                return null;
            }       
        }
    
        
    }
}