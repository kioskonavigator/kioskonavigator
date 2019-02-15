<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidarEmail.aspx.cs" Inherits="kioskotem.ValidarEmail" %>

<!DOCTYPE >

<html >
<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Navigator</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.6 -->
  <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css"/>
  <!-- Font Awesome -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css"/>
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css"/>
  <!-- Theme style -->
  <link rel="stylesheet" href="dist/css/AdminLTE.min.css"/>
  <!-- iCheck -->
  <link rel="stylesheet" href="plugins/iCheck/square/blue.css"/>

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
    <style type="text/css">
        .style1
        {
            width: 200px;
            height: 180px;
        }
    </style>
</head>
<body class="hold-transition login-page" runat="server" >
   <div class="login-box">
  <div class="login-logo">
    
      <img alt="" class="style1" src="imagenes/logooperadora.png" />
  </div>
       <%--<div class="login-logo">
    <a href="#"><b>Operadora</b>Mx</a>
  </div>--%>
  <!-- /.login-logo -->
  <div class="login-box-body" >
    <p class="login-box-msg">
        <span style="color: rgb(102, 102, 102); font-family: &quot;Source Sans Pro&quot;, &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);display: inline !important; float: none;">
        Ingrese un correo electronico</span></p>

    <form id="Form1"  runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           <div class="form-group has-feedback">
        
                    <asp:TextBox ID="txtCorreo" runat="server" type="text" class="form-control" placeholder="Correo electronico"></asp:TextBox>
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
              </div>
              <div class="row">
                <div class="col-xs-8"> 
                <asp:RequiredFieldValidator ID="rfv" runat="server" 
                          ControltoValidate="txtCorreo" initialvalue=" ">
                    Debe ingresar un correo
                    </asp:RequiredFieldValidator>
                 
                </div>
                <!-- /.col -->
                <div class="col-xs-4">
            
                        <asp:Button ID="cmdSend" runat="server" Text="Enviar" type="submit" 
                            class="btn btn-primary btn-block btn-flat" onclick="cmdenviar_Click" />
          
                </div>
                <!-- /.col -->
                  <asp:Label ID="lblMensaje" runat="server" 
                      Text="Este correo sera asociado a su cuenta, debe ingresar un correo valido para poder continuar."></asp:Label>
              </div>
      </ContentTemplate>
    </asp:UpdatePanel>
    </form>


    </div>

    <script type="text/javascript">
        //      var boton = document.getElementById("cmdSend");
        //       // cuando se pulsa en el enlace
        function validarart(form) {
            var seleccion = confirm("Revise su correo electronico se le ha enviado un mensaje de verificación.");
            if (seleccion)
                location.href = "../default.aspx";
            //usado para que no haga postback el boton de asp.net cuando 
            //no se acepte el confirm
            return seleccion;
        }
    </script>
</body>
</html>
