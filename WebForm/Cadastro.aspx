<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="WebForm.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        
        .grid-cell {
            padding: 5px;
        }

        
        .grid-container {
            margin: 20px 10px;
            overflow-x: auto; 
        }

        .form-group {
            margin-bottom: 15px;
        }
    </style>

    <h2>Cadastro de Clientes</h2>
     <div class="grid-container">
<asp:GridView ID="ClienteGridView" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="IdCliente" onrowediting="EditarCliente" onrowcancelingedit="CancelarEdicao" 
    onrowupdating="AtualizarCliente" Onrowdeleting ="ExcluirCliente"
    CssClass="table table-striped table-bordered">
    <Columns>
        <asp:BoundField DataField="IdCliente" HeaderText="ID Cliente" ReadOnly="true" />
        <asp:BoundField DataField="CPF" HeaderText="CPF" />
        <asp:BoundField DataField="Nome" HeaderText="Nome" />
        <asp:BoundField DataField="RG" HeaderText="RG" />
        <asp:BoundField DataField="Data_Expedicao" HeaderText="Data de Expedição" />
        <asp:BoundField DataField="Orgao_Expedicao" HeaderText="Órgão de Expedição" />
        <asp:BoundField DataField="UF_Expedicao" HeaderText="UF" />
        <asp:BoundField DataField="Data_Nascimento" HeaderText="Data de Nascimento" />
        <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
        <asp:BoundField DataField="Estado_Civil" HeaderText="Estado Civil" />     
        <asp:BoundField DataField="address.CEP" HeaderText="CEP" />
        <asp:BoundField DataField="address.Logradouro" HeaderText="Logradouro" />
        <asp:BoundField DataField="address.Numero" HeaderText="Numeroo" />
        <asp:BoundField DataField="address.Complemento" HeaderText="Complemento" />
        <asp:BoundField DataField="address.Cidade" HeaderText="Cidade" />
        <asp:BoundField DataField="address.Bairro" HeaderText="Bairro" />
        <asp:BoundField DataField="address.UF" HeaderText="UF" />

       <asp:CommandField ShowEditButton="true" ShowCancelButton="true"  ShowDeleteButton="true" ButtonType="Link" EditText="Editar" UpdateText="Atualizar" CancelText="Cancelar" DeleteText="Excluir" />
    </Columns>
</asp:GridView>
         </div>

<h3>Adicionar Cliente</h3>
<div class="container mt-4">
    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtCPF">CPF(*)</label>
                <asp:TextBox ID="txtCPF" runat="server" class="form-control" placeholder="CPF"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtNome">Nome(*)</label>
                <asp:TextBox ID="txtNome" runat="server" class="form-control" placeholder="Nome"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtRG">RG</label>
                <asp:TextBox ID="txtRG" runat="server" class="form-control" placeholder="RG"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtData_Expedicao">Data de Expedição</label>
                <asp:TextBox ID="txtData_Expedicao" runat="server" class="form-control" type="date" placeholder="Data Expedição"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtOrgao_Expedicao">Orgao_Expedicao</label>
                <asp:TextBox ID="txtOrgao_Expedicao" runat="server" class="form-control" placeholder="Orgao_Expedicao"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtUF">UF</label>
                <asp:TextBox ID="txtUF" runat="server" class="form-control" placeholder="UF"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtData_Nascimento">Data Nascimento(*)</label>
                <asp:TextBox ID="txtData_Nascimento" runat="server" class="form-control" type="date" placeholder="Data Nascimento"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtSexo">Sexo(*)</label>
                <asp:TextBox ID="txtSexo" runat="server" class="form-control" placeholder="Sexo"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtEstado_Civil">Estado Civil(*)</label>
                <asp:TextBox ID="txtEstado_Civil" runat="server" class="form-control" placeholder="Estado Civil"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtCEP">CEP(*)</label>
                <asp:TextBox ID="txtCEP" runat="server" class="form-control" placeholder="CEP"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtLogradouro">Logradouro(*)</label>
                <asp:TextBox ID="txtLogradouro" runat="server" class="form-control" placeholder="Logradouro"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtNumero">Número(*)</label>
                <asp:TextBox ID="txtNumero" runat="server" class="form-control" placeholder="Número"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtComplemento">Complemento</label>
                <asp:TextBox ID="txtComplemento" runat="server" class="form-control" placeholder="Complemento"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtBairro">Bairro(*)</label>
                <asp:TextBox ID="txtBairro" runat="server" class="form-control" placeholder="Bairro"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtCidade">Cidade(*)</label>
                <asp:TextBox ID="txtCidade" runat="server" class="form-control" placeholder="Cidade"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="txtUFEndereco">UF_Endereco(*)</label>
                <asp:TextBox ID="txtUFEndereco" runat="server" class="form-control" placeholder="UF Endereco"></asp:TextBox>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar Cliente" CssClass="btn btn-primary" OnClientClick="return validarFormulario();" OnClick="AdicionarCliente_Click" />
            </div>
        </div>
    </div>
</div>


    <script>
        function validarFormulario() {
            var cpf = document.getElementById('<%= txtCPF.ClientID %>').value;
            var nome = document.getElementById('<%= txtNome.ClientID %>').value;
            var rg = document.getElementById('<%= txtRG.ClientID %>').value;
            var dataExpedicao = document.getElementById('<%= txtData_Expedicao.ClientID %>').value;
            var orgaoExpedicao = document.getElementById('<%= txtOrgao_Expedicao.ClientID %>').value;
            var uf = document.getElementById('<%= txtUF.ClientID %>').value;
            var dataNascimento = document.getElementById('<%= txtData_Nascimento.ClientID %>').value;
            var sexo = document.getElementById('<%= txtSexo.ClientID %>').value;
            var sexo = document.getElementById('<%= txtSexo.ClientID %>').value;
            var cep = document.getElementById('<%= txtCEP.ClientID %>').value;
            var logradouro = document.getElementById('<%= txtLogradouro.ClientID %>').value;
            var numero = document.getElementById('<%= txtNumero.ClientID %>').value;
            var complemento = document.getElementById('<%= txtComplemento.ClientID %>').value;
            var bairro = document.getElementById('<%= txtBairro.ClientID %>').value;
            var cidade = document.getElementById('<%= txtCidade.ClientID %>').value;
            var ufEndereco = document.getElementById('<%= txtUFEndereco.ClientID %>').value;

            if (!validarCPF(cpf)) {
                alert('CPF inválido.');
                return false;
            }
            debugger;
            if (validarDataSqlServer(dataExpedicao) == false) {
                return false
            }
            if (validarDataSqlServer(dataNascimento) == false) {
                return false
            }

            if (cpf.trim() === '' || nome.trim() === '' || dataNascimento.trim() === '' || sexo.trim() === '' || estadoCivil.trim() === ''
                || cep.trim() === '' || logradouro.trim() === '' || numero.trim() === '' || bairro.trim() === '' || cidade.trim() === '' ||
                ufEndereco.trim() === '') {
                alert('Por favor, preencha todos os campos obrigatórios.');
                return false;
            }

            return true;
        }

            function validarCPF(cpf) {
                cpf = cpf.replace(/[^\d]+/g, '');
            if(cpf == '') return false;
            
            if (cpf.length != 11 ||
            cpf == "00000000000" ||
            cpf == "11111111111" ||
            cpf == "22222222222" ||
            cpf == "33333333333" ||
            cpf == "44444444444" ||
            cpf == "55555555555" ||
            cpf == "66666666666" ||
            cpf == "77777777777" ||
            cpf == "88888888888" ||
            cpf == "99999999999")
            return false;

            
            add = 0;
            for (i = 0; i < 9; i++)
            add += parseInt(cpf.charAt(i)) * (10 - i);
            rev = 11 - (add % 11);
            if (rev == 10 || rev == 11)
            rev = 0;
            if (rev != parseInt(cpf.charAt(9)))
            return false;

           
            add = 0;
            for (i = 0; i < 10; i++)
            add += parseInt(cpf.charAt(i)) * (11 - i);
            rev = 11 - (add % 11);
            if (rev == 10 || rev == 11)
            rev = 0;
            if (rev != parseInt(cpf.charAt(10)))
            return false;

            return true;
            }

            function validarDataSqlServer(data) {
            try {
                    var dataJS = new Date(data);

                if (isNaN(dataJS.getTime()) || dataJS < new Date('1753-01-01') || dataJS > new Date('9999-12-31')) {
                    alert("Sua Data Está com o Valor Inválido");
                    return false;
                }

                    return true;
            } catch (error) {
                alert("Erro na validação da data:", error.message);
                    return false; 
                }
            }
    </script>
</asp:Content>
