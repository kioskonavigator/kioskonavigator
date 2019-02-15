<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="contra.aspx.cs" Inherits="kioskotem.configurar.contra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
      <h1>
        Cambiar contraseña
        <small><asp:Label ID="lblnombre" runat="server" Text=""></asp:Label></small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="../inicio/inicio.aspx"><i class="fa fa-dashboard"></i> Inicio</a></li>
        <li><a href="../configurar/Actualizar.aspx">Configuación</a></li>
        <li class="active">Cambiar Contraseña</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="register-box">
                      <div class="register-logo">
                        
                      </div>

                      <div class="register-box-body">
                        <p class="login-box-msg">Cambiar contraseña</p>

                        <form action="../../index.html" method="post">
                          <div class="form-group has-feedback">
                            <asp:TextBox ID="txtid" runat="server" type="text" class="form-control" placeholder="Id Empleado"></asp:TextBox>
                            
                            <span class="glyphicon glyphicon-user form-control-feedback"></span>
                          </div>
                          <div class="form-group has-feedback">
                            <asp:TextBox ID="txtusuario" runat="server" type="text" class="form-control" placeholder="Usuario"></asp:TextBox>
                            
                            <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                          </div>
                          <div class="form-group has-feedback">
                           
                            <asp:TextBox ID="txtpass" runat="server" type="password" TextMode="Password" class="form-control" placeholder="Nueva contraseña"></asp:TextBox>
                            <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                          </div>
                          <div class="form-group has-feedback">
                            <asp:TextBox ID="txtrepass" runat="server" type="password" TextMode="Password" class="form-control" placeholder="Repetir nueva contraseña"></asp:TextBox>
                            <span class="glyphicon glyphicon-log-in form-control-feedback"></span>
                          </div>
                          <div class="row">
                            
                            <!-- /.col -->
                            <div class="col-xs-4">
                                <asp:Button ID="cmdguardar" class="btn btn-primary btn-block btn-flat" 
                                    runat="server" Text="Guardar" onclick="cmdguardar_Click"></asp:Button>
                              
                            </div>
                            <!-- /.col -->
                          </div>
                        </form>

                        
                        
                      </div>
                      <!-- /.form-box -->
                    </div>
                    <!-- /.register-box -->
            
            </ContentTemplate>
        </asp:UpdatePanel>
        

    </section>
</asp:Content>
