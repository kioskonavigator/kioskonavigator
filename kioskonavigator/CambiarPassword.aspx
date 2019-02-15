<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="kioskotem.CambiarPassword" %>

<!DOCTYPE>

<html>
<head unat="server">
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
<body id="Body1" class="hold-transition login-page" runat="server" >
   <div class="login-box">
  <div class="login-logo">
    
      <img alt="" class="style2" src="imagenes/logooperadora.png" 
          style="page-break-inside: avoid; max-width: 100%;" />
  </div>
     
 <div class="login-box-body" >
    <p class="login-box-msg">
        <span style="color: rgb(102, 102, 102); font-family: &quot;Source Sans Pro&quot;, &quot;Helvetica Neue&quot;, Helvetica, Arial, sans-serif; font-size: 14px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: center; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);display: inline !important; float: none;">
        Actualizar contraseña</span></p>

     <form id="Form1"  runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           <div class="form-group has-feedback">
        
                    <asp:TextBox ID="txtCodigo" runat="server" type="text" class="form-control" 
                        placeholder="Usuario"></asp:TextBox>
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
              </div>
           <div class="form-group has-feedback">
        
                    <asp:TextBox ID="txtPass" runat="server" type="password" class="form-control" 
                        placeholder="Nueva contraseña"></asp:TextBox>
                    <span  class="glyphicon glyphicon-lock form-control-feedback"></span>
              </div>
               <div class="form-group has-feedback">
        
                    <asp:TextBox ID="txtConfirmar" runat="server" type="password" class="form-control" 
                        placeholder="Confirme contraseña"></asp:TextBox>
                    <span  class="glyphicon glyphicon-lock form-control-feedback"></span>
              </div>
              <div class="row">
                <!-- /.col -->
                <div class="col-xs-4">
                    <asp:Button ID="cmdUpdate" runat="server"  
                        class="btn btn-primary btn-block btn-flat" 
                        Text="Actualizar" type="submit" onclick="cmdUpdate_Click" />
                </div>
                <!-- /.col -->
                  
              </div>
      </ContentTemplate>
    </asp:UpdatePanel>

    </div>
    
    </div>
    </form>
</body>
</html>
