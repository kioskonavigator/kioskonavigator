<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="correo.aspx.cs" Inherits="kioskotem.configurar.correo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<section class="content-header">
      <h1>
        Cambiar correo  
        <small><asp:Label ID="lblnombre" runat="server" Text=""></asp:Label></small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="../inicio/inicio.aspx"><i class="fa fa-dashboard"></i> Inicio</a></li>
      <li><a href="../configurar/Actualizar.aspx">Configuación</a></li>
        <li class="active">Cambiar correo</li>
      </ol>
    </section>

     <section class="content">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div class="register-box">
              <div class="register-logo">
                        
                </div>
                        
               <div class="register-box-body">
                 <p class="login-box-msg">Cambiar correo</p>

                  <form action="../../index.html" method="post">
                          <%--<div class="form-group has-feedback" Visible="False">
                            <asp:TextBox ID="txtmailold" runat="server" type="text" class="form-control" 
                                  placeholder="" Visible="False"></asp:TextBox>
                            
                           <span class="glyphicon glyphicon-envelope form-control-feedback" Visible="False" ></span>
                          </div>--%>

                          <div class="form-group has-feedback">
                            <asp:TextBox ID="txtmailnew" runat="server" type="text" class="form-control" placeholder="Correo electronico"></asp:TextBox>
                            
                            <span class="glyphicon glyphicon-envelope form-control-feedback"></spn>
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


            </div>
                </span>
              </ContentTemplate>
        </asp:UpdatePanel>
    </section>
</asp:Content>
