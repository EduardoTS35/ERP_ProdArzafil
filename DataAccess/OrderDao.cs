using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class OrderDao:ConnectionToSql
    {
        //*******************************************Reportes Pedidos *******************************************
        public DataTable GetOrderRPedidos(DateTime fromDate, DateTime toDate)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Select h.Hilo as Producto,c.Color as Color,Sum(PesoPedido) as PesoPedido from Pedidos  p
                    inner join Hilos2 h
                    on p.IdHilo=h.IDHilo
                    inner join Colores c
                    on p.IdColor=c.IDColor
                    where FechaEntrega between @fromdate and @todate 
                    group by h.Hilo,c.Color";
                    command.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                    command.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    connection.Close();

                    return table;
                }
            }
        }

        public DataTable GetOrderRPedidosID(int IdPedido)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Select h.Hilo as Producto,c.Color as Color,Sum(PesoPedido) as PesoPedido from Pedidos  p
                    inner join Hilos2 h
                    on p.IdHilo=h.IDHilo
                    inner join Colores c
                    on p.IdColor=c.IDColor 
                    where IDPedido=@IdPedido 
                    group by h.Hilo,c.Color";
                    command.Parameters.Add("@IdPedido", SqlDbType.Int).Value = IdPedido;
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    connection.Close();

                    return table;
                }
            }
        }

        public DataTable GetOrderDPedidos(DateTime fromDate, DateTime toDate)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Select P.IdPrimario,P.IDPedido,P.FechaCreacion,P.FechaEntrega,H.Hilo,C.Color,P.IdColor,P.PesoPedido,V.Nombre+' '+V.Apellido AS Vendedor,CL.RazonSocial from Pedidos p
                    INNER JOIN Hilos2 H
                    ON P.IdHilo=H.IDHilo
                    INNER JOIN Colores C
                    ON C.IDColor=P.IdColor
                    INNER JOIN Vendedores V
                    ON V.IDVendedor=P.IdVendedor
                    INNER JOIN Clientes CL
                    ON CL.IDCliente=P.IdCliente
                    where FechaEntrega between @fromDate and @toDate";
                    command.Parameters.Add("@fromDate", SqlDbType.Date).Value = fromDate;
                    command.Parameters.Add("@toDate", SqlDbType.Date).Value = toDate;
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    connection.Close();

                    return table;
                }
            }
        }

        public DataTable GetOrderDPedidosID(int IdPedido)
        {
            using (var connection = GetConnection())
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Select P.IdPrimario,P.IDPedido,P.FechaCreacion,P.FechaEntrega,H.Hilo,C.Color,P.IdColor,P.PesoPedido,V.Nombre+' '+V.Apellido AS Vendedor,CL.RazonSocial from Pedidos p
                    INNER JOIN Hilos2 H
                    ON P.IdHilo=H.IDHilo
                    INNER JOIN Colores C
                    ON C.IDColor=P.IdColor
                    INNER JOIN Vendedores V
                    ON V.IDVendedor=P.IdVendedor
                    INNER JOIN Clientes CL
                    ON CL.IDCliente=P.IdCliente
                    where IDPedido=@IdPedido";
                    command.Parameters.Add("@IdPedido", SqlDbType.Int).Value = IdPedido;
                    command.CommandType = CommandType.Text;

                    var reader = command.ExecuteReader();
                    var table = new DataTable();
                    table.Load(reader);
                    connection.Close();

                    return table;
                }
            }
        }
        //*******************************************Reportes Pedidos *******************************************

        //*******************************************Reportes Almacen Materia Prima *******************************************

        //Mostrar Resumen Entradas MP
        public DataTable GetOrderResumenEntradasMP(DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenEntMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Resumen Salidas MP
        public DataTable GetOrderResumenSalidasMP(DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenSalMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Entradas MP
        public DataTable GetOrderDetallesEntMP(DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesEntMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Salidas MP
        public DataTable GetOrderDetallesSalMP(DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesSalMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        //Mostrar Detalles Proveedores MP
        public DataTable GetOrderResumenProveedoresMP(int idProveedor,DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenProveedoresMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Proveedor", idProveedor);
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Proveedores MP
        public DataTable GetOrderDetallesProveedoresMP(int idProveedor, DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesProveedoresMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idProveedor", idProveedor);
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Resumen por Producto MP
        public DataTable GetOrderResumenProdMP( int IdProducto, DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenProdMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdProducto", IdProducto);
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Entradas MP
        public DataTable GetOrderDetallesProdMP( int IdProducto, DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesProdMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdProducto", IdProducto);
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Resumen Inventario MP
        public DataTable GetOrderResumenInvMP()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenInvMP";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Entradas MP
        public DataTable GetOrderDetallesInvMP()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesInvMP";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        //Mostrar Resumen Material sin Confirmar MP
        public DataTable GetOrderResumenMaterialSinConfirmarMP()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenMaterialSinConfirmarMP";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Material Sin Confirmar MP
        public DataTable GetOrderDetallesMaterialSinConfirmarMP()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesMaterialSinConfirmarMP";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        //*******************************************Reportes Almacen Materia Prima *******************************************

        //********************************************     Reportes Hilatura   ************************************************

        //Mostrar Resumen Entradas Hilatura
        public DataTable GetOrderResumenEntradasH(DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenEntH";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@todate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Resumen Salidas Hilatura
        public DataTable GetOrderResumenSalidasH(DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenSalH";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Entradas Hilatura
        public DataTable GetOrderDetallesEntH(DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesEntH";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@todate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Salidas Hilatura
        public DataTable GetOrderDetallesSalH(DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesSalH";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Resumen Inventario Hilatura
        public DataTable GetOrderResumenInvH()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenInvH";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Entradas Hilatura
        public DataTable GetOrderDetallesInvH()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesInvH";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Resumen Hilo en Proceso Hilatura
        public DataTable GetOrderResumenHiloEnProceso()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenHiloEnProceso";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Hilo en Proceso Hilatura
        public DataTable GetOrderDetallesHiloEnProceso()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesHiloEnProceso";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Resumen Hilo en Proceso Hilatura sin Confirmar
        public DataTable GetOrderResumenHiloEnProcesoSinConfirmar()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenHiloEnProcesoSinConfirmar";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Hilo en Proceso Hilatura sin Confirmar
        public DataTable GetOrderDetallesHiloEnProcesoSinConfirmar() 
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesHiloEnProcesoSinConfirmar";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        //********************************************     Reportes Hilatura   ************************************************

        //********************************************     Reportes Almacén Crudo   ************************************************

        //Mostrar Resumen Bolsas 
        public DataTable GetOrderResumenBolsa(DateTime fromDate, DateTime toDate,int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenBolsa";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Bolsas
        public DataTable GetOrderDetallesBolsa(DateTime fromDate, DateTime toDate, int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesBolsa";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Resumen Bolsas Inventario
        public DataTable GetOrderResumenBolsaInv(int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenBolsaInv";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Bolsas Inventario
        public DataTable GetOrderDetallesBolsaInv(int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesBolsaInv";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //********************************************     Reportes Almacén Crudo   ************************************************

        //********************************************     Reportes Tintorería   ************************************************


        //Mostrar Resumen Bolsas 
        public DataTable GetOrderResumenBolsaT(DateTime fromDate, DateTime toDate, int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenBolsaT";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Bolsas
        public DataTable GetOrderDetallesBolsaT(DateTime fromDate, DateTime toDate, int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesBolsaT";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Resumen Bolsas Inventario
        public DataTable GetOrderResumenBolsaInvT(int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenBolsaInvT";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Bolsas Inventario
        public DataTable GetOrderDetallesBolsaInvT(int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesBolsaInvT";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
       

        //********************************************     Reportes Tintorería   ************************************************

        //********************************************     Reportes Almacén Final   ************************************************

        //Mostrar Resumen Bolsas 
        public DataTable GetOrderResumenBolsaAF(DateTime fromDate, DateTime toDate, int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenBolsaAF";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Bolsas
        public DataTable GetOrderDetallesBolsaAF(DateTime fromDate, DateTime toDate, int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesBolsaAF";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Resumen Bolsas Inventario
        public DataTable GetOrderResumenBolsaInvAF(int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenBolsaInvAF";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Bolsas Inventario
        public DataTable GetOrderDetallesBolsaInvAF(int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesBolsaInvAF";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Resumen Bolsas Salidas
        public DataTable GetOrderResumenBolsaSAF(DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenBolsaSAF";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Bolsas Salidas
        public DataTable GetOrderDetallesBolsaSAF(DateTime fromDate, DateTime toDate)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesBolsaSAF";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@fromDate", fromDate);
                    command.Parameters.AddWithValue("@toDate", toDate);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        //Mostrar Resumen Bolsas Inventario
        public DataTable GetOrderResumenNumRemisionAF(int numRemision)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderResumenNumRemisionAF";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@numRemision", numRemision);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Bolsas Inventario
        public DataTable GetOrderDetallesNumRemisionAF(int numRemision)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDetallesNumRemisionAF";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NUM", numRemision);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        //********************************************     Reportes Almacén Final   ************************************************

        //********************************************     Reportes Almacén Final   ************************************************
        public DataTable GetOrderRSucursal(int numRemision, int statusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderRSucursal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NumRemision", numRemision);
                    command.Parameters.AddWithValue("@status", statusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Bolsas Inventario
        public DataTable GetOrderDNumRemisionSucursal(int numRemision, int statusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "GetOrderDNumRemisionSucursal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NumRemision", numRemision);
                    command.Parameters.AddWithValue("@statusProceso", statusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //********************************************     Reportes Almacén Final   ************************************************
    }
}
