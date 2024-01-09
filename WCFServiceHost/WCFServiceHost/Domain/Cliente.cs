using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WCFServiceHost.Domain
{
    public class Cliente { 
     [Key]
    public int IdCliente { get; set; }
    public string CPF { get; set; }
    public string Nome { get; set; }
    public string RG { get; set; }
    public DateTime? Data_Expedicao { get; set; }
    public string Orgao_Expedicao { get; set; }
    public string UF_Expedicao { get; set; }
    public DateTime Data_Nascimento { get; set; }
    public string Sexo { get; set; }
    public string Estado_Civil { get; set; }

    public Address Address { get; set; }


        }
    }