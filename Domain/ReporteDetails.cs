using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace Domain
{
    public class ReporteDetails
    {
        public List<PruebasLDe> pruebasLDe { get; set; }

        //*******************************************Reportes Pedidos *******************************************
        public void GenerarOrdenReporteD(DateTime fromDate, DateTime toDate)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDPedidos(fromDate, toDate);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdPedido = Convert.ToInt32(rows[1]),
                    FechaCPedido = Convert.ToDateTime(rows[2]),
                    FechaEPedido = Convert.ToDateTime(rows[3]),
                    IdHiloPedido = Convert.ToString(rows[4]),
                    IdColorPedido = Convert.ToString(rows[5]),
                    Correo = Convert.ToString(rows[6]),
                    CantPedido = Convert.ToDouble(rows[7]),
                    IdVendedorPedido = Convert.ToString(rows[8]),
                    IdClientePedido = Convert.ToString(rows[9])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }
        public void GenerarOrdenReporteDID(int ID)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDPedidosID(ID);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdPedido = Convert.ToInt32(rows[1]),
                    FechaCPedido = Convert.ToDateTime(rows[2]),
                    FechaEPedido = Convert.ToDateTime(rows[3]),
                    IdHiloPedido = Convert.ToString(rows[4]),
                    IdColorPedido = Convert.ToString(rows[5]),
                    Correo = Convert.ToString(rows[6]),
                    CantPedido = Convert.ToDouble(rows[7]),
                    IdVendedorPedido = Convert.ToString(rows[8]),
                    IdClientePedido = Convert.ToString(rows[9])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }
        //*******************************************Reportes Pedidos *******************************************

        //*******************************************Reportes Almacen Materia Prima *******************************************

        public void GetOrderDetallesEntMP(DateTime fromDate, DateTime toDate)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesEntMP(fromDate, toDate);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdMP = Convert.ToInt32(rows[0]),
                    FechaMP = Convert.ToDateTime(rows[1]),
                    IdProductoMP = Convert.ToInt32(rows[2]),
                    ProductoMP = Convert.ToString(rows[3]),
                    PesoMP = Convert.ToDouble(rows[4]),
                    CostoMP = Convert.ToDouble(rows[5])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }
        public void GetOrderDetallesSalMP(DateTime fromDate, DateTime toDate)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesSalMP(fromDate, toDate);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdMP = Convert.ToInt32(rows[0]),
                    FechaMP = Convert.ToDateTime(rows[1]),
                    IdProductoMP = Convert.ToInt32(rows[2]),
                    ProductoMP = Convert.ToString(rows[3]),
                    PesoMP = Convert.ToDouble(rows[4]),
                    CostoMP = Convert.ToDouble(rows[5])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }
        public void GetOrderDetallesProdMP(int IdProducto, DateTime fromDate, DateTime toDate)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesProdMP(IdProducto,fromDate,toDate);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdMP = Convert.ToInt32(rows[0]),
                    IdProductoMP = Convert.ToInt32(rows[1]),
                    ProductoMP = Convert.ToString(rows[2]),
                    PesoMP = Convert.ToDouble(rows[3]),
                    CostoMP = Convert.ToDouble(rows[4])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }

        public void GetOrderDetallesInvMP()
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesInvMP();

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdMP = Convert.ToInt32(rows[0]),
                    IdProductoMP = Convert.ToInt32(rows[1]),
                    ProductoMP = Convert.ToString(rows[2]),
                    PesoMP = Convert.ToDouble(rows[3]),
                    CostoMP = Convert.ToDouble(rows[4])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }
        public void GetOrderDetallesMaterialSinConfirmarMP()
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesMaterialSinConfirmarMP();

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdMP = Convert.ToInt32(rows[0]),
                    IdProductoMP = Convert.ToInt32(rows[1]),
                    ProductoMP = Convert.ToString(rows[2]),
                    PesoMP = Convert.ToDouble(rows[3]),
                    CostoMP = Convert.ToDouble(rows[4])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }
        public void GetOrderDetallesProveedoresMP(int idProveedor, DateTime fromDate, DateTime toDate)
        {
            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesProveedoresMP(idProveedor,fromDate, toDate);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdMP = Convert.ToInt32(rows[0]),
                    IdProductoMP = Convert.ToInt32(rows[3]),
                    ProductoMP = Convert.ToString(rows[4]),
                    PesoMP = Convert.ToDouble(rows[5]),
                    CostoMP = Convert.ToDouble(rows[6])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }

        //*******************************************Reportes Almacen Materia Prima *******************************************

        //********************************************     Reportes Hilatura   ************************************************

        public void GetOrderDetallesEntH(DateTime fromDate, DateTime toDate)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesEntH(fromDate, toDate);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdMP = Convert.ToInt32(rows[0]),
                    FechaMP = Convert.ToDateTime(rows[1]),
                    IdProductoMP = Convert.ToInt32(rows[2]),
                    ProductoMP = Convert.ToString(rows[3]),
                    PesoMP = Convert.ToDouble(rows[4]),
                    CostoMP = Convert.ToDouble(rows[5])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }
        public void GetOrderDetallesSalH(DateTime fromDate, DateTime toDate)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesSalH(fromDate, toDate);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdBolsaB = Convert.ToInt32(rows[0]),
                    FechaRegistroB = Convert.ToDateTime(rows[1]),
                    IdHiloB = Convert.ToString(rows[2]),
                    LoteHilaturaB = Convert.ToInt32(rows[3]),
                    IdCajaB = Convert.ToInt32(rows[4]),
                    PesoBrutoB = Convert.ToDouble(rows[5]),
                    PesoNetoB = Convert.ToDouble(rows[6]),
                    Malla=Convert.ToString(rows[7])
                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }

        public void GetOrderDetallesInvH()
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesInvH();

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdMP = Convert.ToInt32(rows[0]),
                    IdProductoMP = Convert.ToInt32(rows[1]),
                    ProductoMP = Convert.ToString(rows[2]),
                    PesoMP = Convert.ToDouble(rows[3]),
                    CostoMP = Convert.ToDouble(rows[4])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }


        public void GetOrderDetallesBolsa(DateTime fromDate, DateTime toDate,int StatusProceso)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesBolsa(fromDate, toDate,StatusProceso);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdBolsaB = Convert.ToInt32(rows[0]),
                    FechaRegistroB = Convert.ToDateTime(rows[1]),
                    IdHiloB = Convert.ToString(rows[2]),
                    LoteHilaturaB = Convert.ToInt32(rows[3]),
                    IdCajaB = Convert.ToInt32(rows[4]),
                    PesoBrutoB = Convert.ToDouble(rows[5]),
                    PesoNetoB = Convert.ToDouble(rows[6]),
                    Malla=Convert.ToString(rows[7])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }


        public void GetOrderDetallesBolsaInv(int StatusProceso)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesBolsaInv(StatusProceso);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdBolsaB = Convert.ToInt32(rows[0]),
                    FechaRegistroB = Convert.ToDateTime(rows[1]),
                    IdHiloB = Convert.ToString(rows[2]),
                    LoteHilaturaB = Convert.ToInt32(rows[3]),
                    IdCajaB = Convert.ToInt32(rows[4]),
                    PesoBrutoB = Convert.ToDouble(rows[5]),
                    PesoNetoB = Convert.ToDouble(rows[6]),
                    Malla = Convert.ToString(rows[7])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }
        

        public void GetOrderDetallesHiloEnProceso()
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesHiloEnProceso();

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdBolsaB = Convert.ToInt32(rows[0]),
                    FechaRegistroB = Convert.ToDateTime(rows[1]),
                    IdHiloB = Convert.ToString(rows[2]),
                    LoteHilaturaB = Convert.ToInt32(rows[3]),
                    IdCajaB = Convert.ToInt32(rows[4]),
                    PesoBrutoB = Convert.ToDouble(rows[5]),
                    PesoNetoB = Convert.ToDouble(rows[6]),
                    Malla=Convert.ToString(rows[7])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }

        public void GetOrderDetallesHiloEnProcesoSinConfirmar()
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesHiloEnProcesoSinConfirmar();

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdBolsaB = Convert.ToInt32(rows[0]),
                    FechaRegistroB = Convert.ToDateTime(rows[1]),
                    IdHiloB = Convert.ToString(rows[2]),
                    LoteHilaturaB = Convert.ToInt32(rows[3]),
                    IdCajaB = Convert.ToInt32(rows[4]),
                    PesoBrutoB = Convert.ToDouble(rows[5]),
                    PesoNetoB = Convert.ToDouble(rows[6])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }


        //********************************************     Reportes Almacén Crudo   ************************************************

        //********************************************     Reportes Tintorería  ************************************************

        public void GetOrderDetallesBolsaT(DateTime fromDate, DateTime toDate, int StatusProceso)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesBolsaT(fromDate, toDate, StatusProceso);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdBolsaB = Convert.ToInt32(rows[0]),
                    FechaRegistroB = Convert.ToDateTime(rows[1]),
                    IdHiloB = Convert.ToString(rows[2]),
                    IdColorPedido = Convert.ToString(rows[3]),
                    LoteTenido = Convert.ToInt32(rows[4]),
                    PesoBrutoB = Convert.ToDouble(rows[5]),
                    PesoNetoB = Convert.ToDouble(rows[6])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }


        public void GetOrderDetallesBolsaInvT(int StatusProceso)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesBolsaInvT(StatusProceso);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdBolsaB = Convert.ToInt32(rows[0]),
                    FechaRegistroB = Convert.ToDateTime(rows[1]),
                    IdHiloB = Convert.ToString(rows[2]),
                    IdColorPedido = Convert.ToString(rows[3]),
                    LoteTenido = Convert.ToInt32(rows[4]),
                    PesoBrutoB = Convert.ToDouble(rows[5]),
                    PesoNetoB = Convert.ToDouble(rows[6])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }

        //********************************************     Reportes Tintorería  ************************************************

        //********************************************     Reportes Almacén Final  ************************************************

        public void GetOrderDetallesBolsaAF(DateTime fromDate, DateTime toDate, int StatusProceso)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesBolsaAF(fromDate, toDate, StatusProceso);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdBolsaB = Convert.ToInt32(rows[0]),
                    //LoteTenido = Convert.ToInt32(rows[1]),
                    IdHiloB = Convert.ToString(rows[2]),
                    IdColorPedido = Convert.ToString(rows[3]),
                    PesoBrutoB = Convert.ToDouble(rows[4]),
                    PesoNetoB = Convert.ToDouble(rows[5]),
                    Titulo = Convert.ToString(rows[6]),

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }


        public void GetOrderDetallesBolsaInvAF(int StatusProceso)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesBolsaInvAF(StatusProceso);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdBolsaB = Convert.ToInt32(rows[0]),
                    LoteTenido = Convert.ToInt32(rows[1]),
                    IdHiloB = Convert.ToString(rows[2]),
                    IdColorPedido = Convert.ToString(rows[3]),
                    PesoBrutoB = Convert.ToDouble(rows[4]),
                    PesoNetoB = Convert.ToDouble(rows[5]),
                    Titulo = Convert.ToString(rows[6]),

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }

        public void GetOrderDetallesBolsaSAF(DateTime fromDate, DateTime toDate)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesBolsaSAF(fromDate, toDate);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdBolsaB = Convert.ToInt32(rows[0]),
                    LoteTenido = Convert.ToInt32(rows[1]),
                    IdHiloB = Convert.ToString(rows[2]),
                    IdColorPedido = Convert.ToString(rows[3]),
                    PesoBrutoB = Convert.ToDouble(rows[4]),
                    PesoNetoB = Convert.ToDouble(rows[5]),
                    Titulo = Convert.ToString(rows[6])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }
        public void GetOrderDetallesNumRemisionAF(int numRemision)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDetallesNumRemisionAF(numRemision);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdBolsaB = Convert.ToInt32(rows[0]),
                    LoteTenido = Convert.ToInt32(rows[1]),
                    IdHiloB = Convert.ToString(rows[2]),
                    IdColorPedido = Convert.ToString(rows[3]),
                    PesoBrutoB = Convert.ToDouble(rows[4]),
                    PesoNetoB = Convert.ToDouble(rows[5]),
                    Titulo= Convert.ToString(rows[6]),
                    RazonSocial=Convert.ToString(rows[7]),
                    Edo = Convert.ToString(rows[8]),
                    Ciudad = Convert.ToString(rows[9]),
                    Calle=Convert.ToString(rows[10]),
                    Numero=Convert.ToString(rows[11]),
                    NumPedido=Convert.ToString(rows[12]),
                    NumeroRemision=Convert.ToString(rows[13]),
                    Correo= Convert.ToString(rows[14]),
                    IdClientePedido=Convert.ToString(rows[15])

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }

        //********************************************     Reportes Almacén Final  ************************************************

        public void GetOrderDNumRemisionSucursal(int numRemision,int statusProceso)
        {

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderDNumRemisionSucursal(numRemision,statusProceso);

            pruebasLDe = new List<PruebasLDe>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModelDe = new PruebasLDe()
                {
                    IdBolsaB = Convert.ToInt32(rows[0]),
                    LoteTenido = Convert.ToInt32(rows[1]),
                    IdHiloB = Convert.ToString(rows[2]),
                    IdColorPedido = Convert.ToString(rows[3]),
                    Titulo = Convert.ToString(rows[4]),
                    NumConos = Convert.ToInt32(rows[5]),
                    PrecioUnitario= Convert.ToDouble(rows[6]),
                    PesoNetoB = Convert.ToDouble(rows[7]),
                    RazonSocial = Convert.ToString(rows[8]),
                    Num = Convert.ToString(rows[9]),
                    LoteV = Convert.ToString(rows[10]),
                    Calle= Convert.ToString(rows[11]),
                    Edo = Convert.ToString(rows[12]),
                    Ciudad = Convert.ToString(rows[13]),

                };
                pruebasLDe.Add(pruebasModelDe);
            }
        }
    }
}
