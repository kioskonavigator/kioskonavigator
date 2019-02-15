<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buscar.aspx.cs" Inherits="kioskotem.usuario.Buscar" %>
<!DOCTYPE >

<html >
<head id="Head1" runat="server">
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
        .register-box-msg
        {
            width: 647px;
        }
    </style>
</head>
<body class="hold-transition login-page">
   <div class="login-box">

  <div class="login-logo">
   <div class="login-logo">
      <img alt="" class="style1" src="imagenes/logooperadora.png" />
  </div>
  </div>

  <!-- /.login-logo -->
  <div class="login-box-body">
    <p class="login-box-msg">
        <span style="color: rgb(102, 102, 102); font-family: &quot;Source Sans Pro&quot;, &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); display: inline !important; float: none;">
        </span></p>

    <form id="Form1"  runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        
        
              <div class="form-group has-feedback">
        
                     Seleccione un Usuario
              </div>
              <div class="form-group has-feedback">
        
                    <asp:DropDownList ID="cboClientes" runat="server" Width="330px"></asp:DropDownList>
              </div>
              <div class="form-group has-feedback">
                <asp:Button ID="cmdIniciar" runat="server" Text="Iniciar Sesión" type="submit" 
                            class="btn btn-primary btn-block btn-flat" onclick="cmdIniciar_Click"  />
              </div>
              <div class="row">
                <div class="col-xs-8">
                    </div>
                <!-- /.col -->
                <div class="col-xs-4">
            
                        
          
                </div>
                <!-- /.col -->
              </div>
      </ContentTemplate>
    </asp:UpdatePanel>
    </form>

    

  </div>
  <!-- /.login-box-body -->
</div>
</body>
</html>
