<%@ Page Title="Actualizar Información" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="Actualizar.aspx.cs" Inherits="kioskotem.configurar.Actualizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

         <section class="content-header">
              <h1>
               Configuración
                <small><asp:Label ID="lblnombre2" runat="server" Text=""></asp:Label></small>
              </h1>
              <ol class="breadcrumb">
                <li><a href="../inicio/inicio.aspx"><i class="fa fa-dashboard"></i> Inicio</a></li>
                <%--<li><a href="#">Bienvenido</a></li>--%>
                <li class="active">Configuración</li>
              </ol>
            </section>

            <section class="content">
                <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">

                <ContentTemplate>
                 <div class="register-box">
                 
                 <div class="register-box-body">
                        <p class="login-box-msg">Configuración de Cuenta</p>

                        <form action="../../index.html" method="post">
                            <!-- /.col -->
                            <div class="col-xs-4">
                                <asp:Button ID="cmdcontra" class="btn btn-primary btn-block btn-flat" 
                                    runat="server" Text="Cambiar Contraseña" 
                                    Width="319px" onclick="cmdcontra_Click" ></asp:Button>
                              
                            </div>
                            <!-- /.col -->
                              <br />
                              <br />
                              <br />

                              <div class="row">
                                  <p class="login-box-msg">Cambiar Correo </p>

                                       <div class="col-xs-4">
                                      <asp:Button ID="cmdCambiar" runat="server" 
                                          class="btn btn-primary btn-block btn-flat" Text="Cambiar Correo" 
                                          Width="318px" onclick="cmdCambiar_Click" />
                                    </div>
                                  <!-- /.col -->
                              </div>
                          </div>
                        </form>                
                 </div>

                </ContentTemplate>
                </asp:UpdatePanel>
            
            </section>
</asp:Content>
