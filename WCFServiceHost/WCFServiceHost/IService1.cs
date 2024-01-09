using System.Collections.Generic;
using System.ServiceModel;
using WCFServiceHost.Domain;

namespace WCFServiceHost
{
   
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Cliente> ObterDados();
        [OperationContract]
        Cliente ObterDadosID(int id);
        [OperationContract]
        void SalvarClientes(Cliente cliente);
        [OperationContract]
        void EditarCliente(Cliente cliente, int id);
        [OperationContract]
        void DeletarCliente(int id);
    }

}
