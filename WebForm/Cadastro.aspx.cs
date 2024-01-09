using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web;
using System.Web.UI;
using WCFServiceHost;
using WCFServiceHost.Domain;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class Contact : Page
    {
        Service1 cFServiceHost = new Service1();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Carregue e vincule os dados aqui (simulação de dados)
                List<Cliente> listaClientes = cFServiceHost.ObterDados(); // Função para obter dados de clientes
                ClienteGridView.DataSource = listaClientes;
                ClienteGridView.DataBind();
            }
        }
        protected void AdicionarCliente_Click(object sender, EventArgs e)
        {
            Cliente myClient = new Cliente();
            myClient.CPF = txtCPF.Text;
            myClient.Nome = txtNome.Text;
            myClient.RG = txtRG.Text;
            myClient.Data_Expedicao = Convert.ToDateTime(txtData_Expedicao.Text);
            myClient.Orgao_Expedicao = txtOrgao_Expedicao.Text;
            myClient.UF_Expedicao = txtUF.Text;
            myClient.Data_Nascimento = Convert.ToDateTime(txtData_Nascimento.Text);
            myClient.Sexo = txtSexo.Text;
            myClient.Estado_Civil = txtEstado_Civil.Text;
            myClient.Address = new Address()
            {
                CEP = txtCEP.Text,
                Logradouro = txtLogradouro.Text,
                Numero = txtNumero.Text,
                Complemento = txtComplemento.Text,
                Cidade = txtCidade.Text,
                Bairro = txtBairro.Text,
                UF = txtUFEndereco.Text,
            };


            cFServiceHost.SalvarClientes(myClient);

            LimparCamposFormulario();

            Response.Redirect(Request.RawUrl);
        }

        private void LimparCamposFormulario()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtNome.Text = "";
            txtRG.Text = "";
            txtData_Expedicao.Text = "";
            txtOrgao_Expedicao.Text = "";
            txtUF.Text = "";
            txtData_Nascimento.Text = "";
            txtSexo.Text = "";
            txtEstado_Civil.Text = "";
            txtCEP.Text = "";
            txtLogradouro.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtCidade.Text = "";
            txtBairro.Text = "";
            txtUFEndereco.Text = "";
        }

        protected void EditarCliente(object sender, GridViewEditEventArgs e)
        {
            ClienteGridView.EditIndex = e.NewEditIndex;
            BindGridData();
        }

        protected void CancelarEdicao(object sender, GridViewCancelEditEventArgs e)
        {
            ClienteGridView.EditIndex = -1;
            BindGridData();
        }

        protected void AtualizarCliente(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = ClienteGridView.Rows[e.RowIndex];

            int idCliente = Convert.ToInt32(row.Cells[0].Text); 

            string cpf = ((TextBox)row.Cells[1].Controls[0]).Text;

            string nome = ((TextBox)row.Cells[2].Controls[0]).Text;

            string rg = ((TextBox)row.Cells[3].Controls[0]).Text;

            string data_expedicao = ((TextBox)row.Cells[4].Controls[0]).Text;

            string orgao_Expedicao = ((TextBox)row.Cells[5].Controls[0]).Text;

            string uf_expedicao = ((TextBox)row.Cells[6].Controls[0]).Text;

            string data_nascimento = ((TextBox)row.Cells[7].Controls[0]).Text;

            string sexo = ((TextBox)row.Cells[8].Controls[0]).Text;

            string estado_civil = ((TextBox)row.Cells[9].Controls[0]).Text;

            string cep = ((TextBox)row.Cells[10].Controls[0]).Text;

            string logradouro = ((TextBox)row.Cells[11].Controls[0]).Text;

            string numero = ((TextBox)row.Cells[12].Controls[0]).Text;

            string complemento = ((TextBox)row.Cells[13].Controls[0]).Text;

            string cidade = ((TextBox)row.Cells[14].Controls[0]).Text;

            string bairro = ((TextBox)row.Cells[15].Controls[0]).Text;

            string uf = ((TextBox)row.Cells[16].Controls[0]).Text;

            Cliente myClient = new Cliente();
            myClient.CPF = cpf;
            myClient.Nome = nome;
            myClient.RG = rg;
            myClient.Data_Expedicao = Convert.ToDateTime(data_expedicao);
            myClient.Orgao_Expedicao = orgao_Expedicao;
            myClient.UF_Expedicao = uf_expedicao;
            myClient.Data_Nascimento = Convert.ToDateTime(data_nascimento);
            myClient.Sexo = sexo;
            myClient.Estado_Civil = estado_civil;
            myClient.Address = new Address()
            {
                CEP = cep,
                Logradouro = logradouro,
                Numero = numero,
                Complemento = complemento,
                Cidade = cidade,
                Bairro = bairro,
                UF = uf,
        
            };


            cFServiceHost.EditarCliente(myClient, idCliente);

                ClienteGridView.EditIndex = -1;

                BindGridData();

        }
        protected void ExcluirCliente(object sender, GridViewDeleteEventArgs e)
        {
            // Obter o ID do cliente a ser excluído
            int idCliente = Convert.ToInt32(ClienteGridView.DataKeys[e.RowIndex].Value);

            cFServiceHost.DeletarCliente(idCliente);

            // Cancelar a operação de exclusão (opcional)
            ClienteGridView.EditIndex = -1;
            ClienteGridView.DataBind();
            BindGridData();
        }



        private void BindGridData()
        {
            List<Cliente> listaClientes = cFServiceHost.ObterDados(); // Obter dados atualizados dos clientes
            ClienteGridView.DataSource = listaClientes;
            ClienteGridView.DataBind();
        }
    }
}