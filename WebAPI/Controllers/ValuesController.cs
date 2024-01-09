using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using WebAPI.Domain;
using WebAPI.MyConecction;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ApplicationDBContext dBContext = new ApplicationDBContext();
        // GET api/values
        public List<Cliente> Get()
        {
            IQueryable<Cliente> queryClients = from C in dBContext.Clientes
                                               join A in dBContext.Addresss on C.IdCliente equals A.ClienteRef
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
                                               };
            List<Cliente> listClients = queryClients.ToList();
            return listClients;
        }

        // GET api/values/5
        public Cliente Get(int id)
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
        // POST api/values
        public void Post([FromBody] Cliente cliente1)
        {
            dBContext.Clientes.Add(cliente1);
            dBContext.SaveChanges();

        }

        // PUT api/values/5
        public void Put(int id, [FromBody] Cliente cliente1)
        {
            dBContext.Clientes.First(x => x.IdCliente == id).CPF = cliente1.CPF;
            dBContext.Clientes.First(x => x.IdCliente == id).Nome = cliente1.Nome;
            dBContext.Clientes.First(x => x.IdCliente == id).RG = cliente1.RG;
            dBContext.Clientes.First(x => x.IdCliente == id).Data_Expedicao = cliente1.Data_Expedicao;
            dBContext.Clientes.First(x => x.IdCliente == id).Orgao_Expedicao = cliente1.Orgao_Expedicao;
            dBContext.Clientes.First(x => x.IdCliente == id).UF_Expedicao = cliente1.UF_Expedicao;
            dBContext.Clientes.First(x => x.IdCliente == id).Data_Nascimento = cliente1.Data_Nascimento;
            dBContext.Clientes.First(x => x.IdCliente == id).Sexo = cliente1.Sexo;
            dBContext.Clientes.First(x => x.IdCliente == id).Estado_Civil = cliente1.Estado_Civil;
            dBContext.Addresss.First(x => x.ClienteRef == id).CEP = cliente1.Address.CEP;
            dBContext.Addresss.First(x => x.ClienteRef == id).Logradouro = cliente1.Address.Logradouro;
            dBContext.Addresss.First(x => x.ClienteRef == id).Numero = cliente1.Address.Numero;
            dBContext.Addresss.First(x => x.ClienteRef == id).Complemento = cliente1.Address.Complemento;
            dBContext.Addresss.First(x => x.ClienteRef == id).Bairro = cliente1.Address.Bairro;
            dBContext.Addresss.First(x => x.ClienteRef == id).Cidade = cliente1.Address.Cidade;
            dBContext.Addresss.First(x => x.ClienteRef == id).UF = cliente1.Address.UF;
            
            dBContext.SaveChanges();
        }
            
        // DELETE api/values/5
        public void Delete(int id)
        {
            dBContext.Clientes.Remove(dBContext.Clientes.First(x => x.IdCliente == id));
            dBContext.SaveChanges();
        }
    }
}
