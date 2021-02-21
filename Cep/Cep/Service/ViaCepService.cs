using System;
using System.Collections.Generic;
using System.Net;
using Cep.Service.Model;
using Newtonsoft.Json;

namespace Cep.Service
{
    public class ViaCepService
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";
        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEnderecoURL);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (end.cep == null) return null;
            return end;
        }
    }
}
