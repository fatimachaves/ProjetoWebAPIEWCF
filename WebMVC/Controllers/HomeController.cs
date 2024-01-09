using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebAPI.Domain;
using WebMVC.Models;


namespace WebApplication.Solution.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _client;
        private object dbContext;

        public HomeController()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44355/"); 
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ActionResult> BuscarCliente()
        {
            HttpResponseMessage response = await _client.GetAsync("api/values");
            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<Cliente>>(responseData);
                Console.WriteLine(responseData);
                return View(result);
            }
            else
            {
              
                return View("Error");
            }
        }
        public async Task<ActionResult> SalvarDados(ClienteViewModel cliente)
        {
            if(cliente.IdCliente.Equals(0))
            {
                Cliente cliente1 = ConvertViewModelToObjectApi(cliente);
                var json = JsonConvert.SerializeObject(cliente1); // Serializa o objeto cliente para JSON

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PostAsync("api/values", content);

                if (response.IsSuccessStatusCode)
                {
                    
                    return RedirectToAction("BuscarCliente");
                }
                else
                {
                   
                    return View("Error");
                }
            }
            else
            {
                
                Cliente clienteApi = ConvertViewModelToObjectApi(cliente);

                
                var json = JsonConvert.SerializeObject(clienteApi);

               
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                
                string apiUrl = $"api/values/{cliente.IdCliente}"; 

                
                HttpResponseMessage response = await _client.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                   
                    return RedirectToAction("BuscarCliente");
                }
                else
                {
                   
                    return View("Error");
                }
            }
           
        }
        public async Task<ActionResult> DeletarCliente(int id)
        {

            string apiUrl = $"api/values/{id}";


            HttpResponseMessage response = await _client.DeleteAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("BuscarCliente");
            }
            else
            {

                return View("Error");
            }
        }
        private Cliente ConvertViewModelToObjectApi(ClienteViewModel cliente)
        {
            Cliente myClient = new Cliente()
            {

                IdCliente = cliente.IdCliente,
                CPF = cliente.CPF,
                Nome = cliente.Nome,
                RG = cliente.RG,
                Orgao_Expedicao = cliente.Orgao_Expedicao,
                UF_Expedicao = cliente.UF,
                Data_Nascimento = Convert.ToDateTime(cliente.Data_Nascimento),
                Sexo = cliente.Sexo,
                Estado_Civil = cliente.Estado_Civil,
                Address = new Address()
                {
                    CEP = cliente.address.CEP,
                    Logradouro = cliente.address.Logradouro,
                    Numero = cliente.address.Numero,
                    Complemento = cliente.address.Complemento,
                    Cidade = cliente.address.Cidade,
                    Bairro = cliente.address.Bairro,
                    UF = cliente.address.UF,
                }
            };

            if (cliente.Data_Expedicao == null)
            {
                myClient.Data_Expedicao = null;
            }
            else
            {
                myClient.Data_Expedicao = Convert.ToDateTime(cliente.Data_Expedicao);
            }
            return myClient;
        }
        private ClienteViewModel ConvertObjectApiToViewModel(Cliente cliente)
        {
            ClienteViewModel myClient = new ClienteViewModel()
            {

                IdCliente = cliente.IdCliente,
                CPF = cliente.CPF,
                Nome = cliente.Nome,
                RG = cliente.RG,
                Data_Expedicao = cliente.Data_Expedicao?.ToString("yyyy-MM-dd"),
                Orgao_Expedicao = cliente.Orgao_Expedicao,
                UF = cliente.UF_Expedicao,
                Data_Nascimento = cliente.Data_Nascimento.ToString("yyyy-MM-dd"),
                Sexo = cliente.Sexo,
                Estado_Civil = cliente.Estado_Civil,
                address = new Models.AddressViewModel()
                {
                    CEP = cliente.Address.CEP,
                    Logradouro = cliente.Address.Logradouro,
                    Numero = cliente.Address.Numero,
                    Complemento = cliente.Address.Complemento,
                    Cidade = cliente.Address.Cidade,
                    Bairro = cliente.Address.Bairro,
                    UF = cliente.Address.UF,
                }
            };

            return myClient;
        }
        public async Task<ActionResult> BuscarClientSpecific(int id)
        {
            string apiUrl = $"api/values/{id}"; 

            HttpResponseMessage response = await _client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                Cliente cliente = JsonConvert.DeserializeObject<Cliente>(responseData);
                ClienteViewModel clienteViewModel = ConvertObjectApiToViewModel(cliente);
                return Json(clienteViewModel, JsonRequestBehavior.AllowGet);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                
                return View("NotFound");
            }
            else
            {
                
                return View("Error");
            }
        }
         

    }

}

