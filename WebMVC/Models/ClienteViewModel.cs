using System;
using WebApplication.Solution.Models;

namespace WebMVC.Models
{
    public class ClienteViewModel
    {
        public int IdCliente { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Data_Expedicao { get; set; }
        public string Orgao_Expedicao { get; set; }
        public string UF { get; set; }
        public string Data_Nascimento { get; set; }
        public string Sexo { get; set; }
        public string Estado_Civil { get; set; }
        public AddressViewModel address { get; set; }

    }
}