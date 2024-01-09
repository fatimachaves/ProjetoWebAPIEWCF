using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFServiceHost.Domain;
using WebAPI.MyConecction;

namespace WCFServiceHost
{
   
    public class Service1 : IService1
    {
        ApplicationDBContext dBContext = new ApplicationDBContext();
        public List<Cliente> ObterDados()
        {
            var clientes = dBContext.Clientes.ToList();
            var enderecos = dBContext.Addresss.ToList();

            var listClients = (from C in clientes
                               join A in enderecos on C.IdCliente equals A.ClienteRef
                               select new Cliente()
                               {
                                   IdCliente = C.IdCliente,
                                   CPF = C.CPF,
                                   Nome = C.Nome,
                                   RG = C.RG,
                                   Data_Expedicao = C.Data_Expedicao,
                                   Orgao_Expedicao = C.Orgao_Expedicao,
                                   UF_Expedicao = C.UF_Expedicao,
                                   Data_Nascimento = C.Data_Nascimento,
                                   Sexo = C.Sexo,
                                   Estado_Civil = C.Estado_Civil,
                                   Address = new Address()
                                   {
                                       CEP = A.CEP,
                                       Logradouro = A.Logradouro,
                                       Numero = A.Numero,
                                       Complemento = A.Complemento,
                                       Cidade = A.Cidade,
                                       Bairro = A.Bairro,
                                       UF = A.UF,
                                   }
                               }).ToList();
            return listClients;
        }
        public Cliente ObterDadosID(int id)
        {
            Cliente clienteComEndereco = dBContext.Clientes
         .Where(c => c.IdCliente == id)
         .Join(dBContext.Addresss,
             cliente => cliente.IdCliente,
             endereco => endereco.ClienteRef,
             (cliente, endereco) => new Cliente
             {
                 IdCliente = cliente.IdCliente,
                 CPF = cliente.CPF,
                 Nome = cliente.Nome,
                 RG = cliente.RG,
                 Data_Expedicao = cliente.Data_Expedicao,
                 Orgao_Expedicao = cliente.Orgao_Expedicao,
                 UF_Expedicao = cliente.UF_Expedicao,
                 Data_Nascimento = cliente.Data_Nascimento,
                 Sexo = cliente.Sexo,
                 Estado_Civil = cliente.Estado_Civil,
                 Address = new Address
                 {
                     CEP = endereco.CEP,
                     Logradouro = endereco.Logradouro,
                     Numero = endereco.Numero,
                     Complemento = endereco.Complemento,
                     Cidade = endereco.Cidade,
                     Bairro = endereco.Bairro,
                     UF = endereco.UF,
                 }
             })
         .FirstOrDefault();

            return clienteComEndereco;
        }

        public void SalvarClientes(Cliente cliente)
        {
            dBContext.Clientes.Add(cliente);
            dBContext.SaveChanges();
        }
        public void EditarCliente(Cliente cliente, int id)
        {
            dBContext.Clientes.First(x => x.IdCliente == id).CPF = cliente.CPF;
            dBContext.Clientes.First(x => x.IdCliente == id).Nome = cliente.Nome;
            dBContext.Clientes.First(x => x.IdCliente == id).RG = cliente.RG;
            dBContext.Clientes.First(x => x.IdCliente == id).Data_Expedicao = cliente.Data_Expedicao;
            dBContext.Clientes.First(x => x.IdCliente == id).Orgao_Expedicao = cliente.Orgao_Expedicao;
            dBContext.Clientes.First(x => x.IdCliente == id).UF_Expedicao = cliente.UF_Expedicao;
            dBContext.Clientes.First(x => x.IdCliente == id).Data_Nascimento = cliente.Data_Nascimento;
            dBContext.Clientes.First(x => x.IdCliente == id).Sexo = cliente.Sexo;
            dBContext.Clientes.First(x => x.IdCliente == id).Estado_Civil = cliente.Estado_Civil;
            dBContext.Addresss.First(x => x.ClienteRef == id).CEP = cliente.Address.CEP;
            dBContext.Addresss.First(x => x.ClienteRef == id).Logradouro = cliente.Address.Logradouro;
            dBContext.Addresss.First(x => x.ClienteRef == id).Numero = cliente.Address.Numero;
            dBContext.Addresss.First(x => x.ClienteRef == id).Complemento = cliente.Address.Complemento;
            dBContext.Addresss.First(x => x.ClienteRef == id).Bairro = cliente.Address.Bairro;
            dBContext.Addresss.First(x => x.ClienteRef == id).Cidade = cliente.Address.Cidade;
            dBContext.Addresss.First(x => x.ClienteRef == id).UF = cliente.Address.UF;
          
            dBContext.SaveChanges();
        }

        public void DeletarCliente(int id)
        {
            dBContext.Clientes.Remove(dBContext.Clientes.First(x => x.IdCliente == id));
            dBContext.SaveChanges();
        }
    }
}
