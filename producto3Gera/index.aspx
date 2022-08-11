eew<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="producto3Gera.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <script src="Recursos/sweetalert2.all.min.js"></script>
    <link href="Recursos/sweetalert2.min.css" rel="stylesheet" />
    <script type="text/javascript">
    function Mensaje(t,m,tipo)
    {
            Swal.fire(
                t, m, tipo
            )
    }
    </script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light bg-light">    
        <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav">
        <li class="nav-item">
          <a class="nav-link" href="marcas.aspx">MARCAS</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="categoria.aspx">CATEGORIA</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="componentes.aspx">COMPONENTES</a>
        </li> 
        <li class="nav-item">
          <a class="nav-link" href="factura.aspx">ALTA DE INFORMACION</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="mosfactura.aspx">FACTURAS</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="detallescomponente.aspx">DETALLES DE COMPONENTES</a>
        </li>
      </ul>
    </div>
  </nav>
        <div>
           <center><h2>BIENVENIDO AL INVENTARIO </h2></center> 
        </div>
    </form>
</body>
</html>
