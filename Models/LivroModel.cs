using CrudChallengeClient.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudChallengeClient.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public decimal Valor { get; set; }
        public string Autor { get; set; }
        public string Tipo { get; set; }


        public List<LivroModel> ListarTodosLivros()
        {
            List<LivroModel> retorno = new List<LivroModel>();
            string json = WebAPI.RequestGET("listagem", string.Empty);
            retorno = JsonConvert.DeserializeObject<List<LivroModel>>(json);
            return retorno;
        }


        public LivroModel Carregar(int? id)
        {
            LivroModel retorno = new LivroModel();
            string json = WebAPI.RequestGET("id", id.ToString());
            retorno = JsonConvert.DeserializeObject<LivroModel>(json);
            return retorno;
        }


        public void Inserir()
        {
            string jsonData = JsonConvert.SerializeObject(this);
            string json = string.Empty;

            if (Id == 0)
            {
                WebAPI.RequestPOST("registrarlivro", jsonData);
            }
            else
            {
                WebAPI.RequestPUT("atualizar/" + Id, jsonData);
            }

        }


        public void Excluir(int id)
        {
            string json = WebAPI.RequestDELETE("excluir", id.ToString());
        }
    }
}
