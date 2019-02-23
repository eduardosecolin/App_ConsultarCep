using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ConsultarCep.Servico.Modelo;
using Newtonsoft.Json;

namespace ConsultarCep.Servico {
    public class ViaCepServico {

        private static string enderecoUrl = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep){

            string novoEnderecoUrl = string.Format(enderecoUrl, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoUrl);

            Endereco endereco = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if(endereco.logradouro == null){
                return null;
            }

            return endereco;
        }
    }
}
