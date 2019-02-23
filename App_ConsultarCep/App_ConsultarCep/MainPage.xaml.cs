using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultarCep.Servico.Modelo;
using ConsultarCep.Servico;

namespace App_ConsultarCep {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            btnBuscar.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs e) {

            if (ValidarCep(txtCep.Text.Trim())) {
                try {
                    Endereco endereco = ViaCepServico.BuscarEnderecoViaCep(txtCep.Text.Trim());
                    if (endereco != null) {
                        lblResultado.Text = $"Endereço: {endereco.logradouro}" + 
                                            $"\nBairro: {endereco.bairro}" +
                                            $"\nCidade: {endereco.localidade}" +
                                            $"\nEstado: {endereco.uf}";
                    }else{
                        DisplayAlert("Erro", "O endereço não foi encontrado para o cep informado: " + txtCep.Text, "Ok");
                        txtCep.Text = string.Empty;
                    }
                }catch(Exception ex){
                    DisplayAlert("Erro Critíco", ex.Message, "Ok");
                    txtCep.Text = string.Empty;
                }
            }
        }

        private bool ValidarCep(string cep) {

            bool valido = true;
            if (cep.Length != 8) {

                DisplayAlert("Erro", "Cep Invalido! O cep deve conter 8 caracteres", "Ok");
                txtCep.Text = string.Empty;
                valido = false;
            }

            int novoCep = 0;

            if(!int.TryParse(cep, out novoCep)){

                DisplayAlert("Erro", "Cep Invalido! O cep deve conter apenas números", "Ok");
                txtCep.Text = string.Empty;
                valido = false;
            }

            return valido;
        }
    }
}
