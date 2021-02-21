using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Cep.Service.Model;
using Cep.Service;

namespace Cep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BOTAO.Clicked += BuscarCEP;
        }
        
        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();
            if (isValid(cep))
            {
                try {
                    Endereco end = ViaCepService.BuscarEnderecoViaCep(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = "Endereço para o CEP " + cep + ": "
                            + end.logradouro + ", "
                            + end.complemento + ", "
                            + end.bairro + ", "
                            + end.localidade + ", "
                            + end.uf + ".";
                    }
                    else
                    {
                        DisplayAlert("Erro", "O endereço não foi encontrado, para o CEP informado: " + cep, "OK");
                    }
                }catch(Exception e)
                {
                    DisplayAlert("Erro", e.Message, "OK");
                }
            }

           
        }
        private bool isValid(string cep)
        {
            int CepValido = 0;
            if ((cep.Length != 8) || !int.TryParse(cep, out CepValido))
            {
                DisplayAlert("Erro", "O cep deve conter somente os 8 números!", "OK");
                return false;
            }
            
           return true;
        }
    }
}
