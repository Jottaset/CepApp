using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using CepApp.Model;
using Newtonsoft.Json;

namespace CepApp
{
    public partial class MainPage : ContentPage
    {
        async void Handle_Completed(object sender, System.EventArgs e)
        {
            var client = new HttpClient();
            string cep = entry_cep.Text;
            var json   = await client.GetStringAsync($"https://viacep.com.br/ws/{cep}/json/");
            var dados = JsonConvert.DeserializeObject<Endereco>(json);

            lblLogradouro.Text  = dados.logradouro;
            lblComplemento.Text = dados.complemento;
            lblBairro.Text      = dados.bairro;
            lblLocalidade.Text  = dados.localidade;
            lblUf.Text          = dados.uf;
            lblUnidade.Text     = dados.unidade;
            lblIbge.Text        = dados.ibge;
            lblGia.Text         = dados.gia;
        }

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
