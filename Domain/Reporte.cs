using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace Domain
{
    public class Reporte
    {
        public DateTime reportDate { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public List<PruebasL> pruebasL { get; set; }

        //*******************************************Reportes Pedidos *******************************************
        public void GenerarOrdenRPF(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderRPedidos(fromDate, toDate);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    ProductoRP = Convert.ToString(rows[0]),
                    ColorRP = Convert.ToString(rows[1]),
                    CantidadRP = Convert.ToDouble(rows[2])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        public void GenerarOrdenRPID(int IdPedido)
        {
            reportDate = DateTime.Now;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderRPedidosID(IdPedido);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    ProductoRP = Convert.ToString(rows[0]),
                    ColorRP = Convert.ToString(rows[1]),
                    CantidadRP = Convert.ToDouble(rows[2])
                };
                pruebasL.Add(pruebasModel);
            }
        }
        //*******************************************Reportes Pedidos *******************************************

        //*******************************************Reportes Almacen Materia Prima *******************************************

        public void GetOrderResumenEntMP(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenEntradasMP(fromDate, toDate);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    ProductoMP = Convert.ToString(rows[0]),
                    PesoTotalMP = Convert.ToDouble(rows[1]),
                    CostoTotalMP = Convert.ToDouble(rows[2])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        public void GetOrderResumenSalMP(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenSalidasMP(fromDate,toDate);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    ProductoMP = Convert.ToString(rows[0]),
                    PesoTotalMP = Convert.ToDouble(rows[1]),
                    CostoTotalMP = Convert.ToDouble(rows[2])
                };
                pruebasL.Add(pruebasModel);
            }
        }
        public void GetOrderResumenProdMP( int IdProducto, DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenProdMP(IdProducto,fromDate,toDate);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    ProductoMP = Convert.ToString(rows[0]),
                    PesoTotalMP = Convert.ToDouble(rows[1]),
                    CostoTotalMP = Convert.ToDouble(rows[2])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        public void GetOrderResumenInvMP()
        {
            reportDate = DateTime.Now;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenInvMP();

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    ProductoMP = Convert.ToString(rows[0]),
                    PesoTotalMP = Convert.ToDouble(rows[1]),
                    CostoTotalMP = Convert.ToDouble(rows[2])
                };
                pruebasL.Add(pruebasModel);
            }
        }
        public void GetOrderResumenMaterialSinConfirmarMP()
        {
            reportDate = DateTime.Now;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenMaterialSinConfirmarMP();

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    ProductoMP = Convert.ToString(rows[0]),
                    PesoTotalMP = Convert.ToDouble(rows[1]),
                    CostoTotalMP = Convert.ToDouble(rows[2])
                };
                pruebasL.Add(pruebasModel);
            }
        }
        public void GetOrderResumenProveedoresMP(int idProveedor, DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenProveedoresMP(idProveedor,fromDate, toDate);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    ProductoMP = Convert.ToString(rows[0]),
                    PesoTotalMP = Convert.ToDouble(rows[1]),
                    CostoTotalMP = Convert.ToDouble(rows[2])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        //*******************************************Reportes Almacen Materia Prima *******************************************

        //********************************************     Reportes Hilatura   ************************************************

        public void GetOrderResumenEntH(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenEntradasH(fromDate, toDate);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    ProductoMP = Convert.ToString(rows[0]),
                    Bolsas= Convert.ToInt16(rows[1]),
                    PesoTotalMP = Convert.ToDouble(rows[2]),
                    CostoTotalMP = Convert.ToDouble(rows[3])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        public void GetOrderResumenSalH(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenSalidasH(fromDate, toDate);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    IdHiloH = Convert.ToString(rows[0]),
                    HiloH = Convert.ToString(rows[1]),
                    Bolsas=Convert.ToInt32(rows[2]),
                    PesoTotalH = Convert.ToDouble(rows[3]),
                    CostoTotalMP=Convert.ToDouble(rows[4])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        public void GetOrderResumenInvH()
        {
            reportDate = DateTime.Now;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenInvH();

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    ProductoMP = Convert.ToString(rows[0]),
                    PesoTotalMP = Convert.ToDouble(rows[1]),
                    CostoTotalMP = Convert.ToDouble(rows[2])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        public void GetOrderResumenHiloEnProceso()
        {
            reportDate = DateTime.Now;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenHiloEnProceso();

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    IdHiloH = Convert.ToString(rows[0]),
                    HiloH = Convert.ToString(rows[1]),
                    Bolsas=Convert.ToInt32(rows[2]),
                    PesoTotalH = Convert.ToDouble(rows[3]),
                    CostoTotalMP = Convert.ToDouble(rows[4])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        public void GetOrderResumenHiloEnProcesoSinConfirmar()
        {
            reportDate = DateTime.Now;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenHiloEnProcesoSinConfirmar();

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    IdHiloH = Convert.ToString(rows[0]),
                    HiloH = Convert.ToString(rows[1]),
                    Bolsas=Convert.ToInt32(rows[2]),
                    PesoTotalH = Convert.ToDouble(rows[3]),
                    CostoTotalMP = Convert.ToDouble(rows[4])
                };
                pruebasL.Add(pruebasModel);
            }
        }
        //********************************************     Reportes Hilatura   ************************************************

        //********************************************     Reportes Almacén Crudo   ************************************************

        public void GetOrderResumenBolsa(DateTime fromDate, DateTime toDate,int StatusProceso)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenBolsa(fromDate, toDate,StatusProceso);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    IdHiloH = Convert.ToString(rows[0]),
                    HiloH = Convert.ToString(rows[1]),
                    Bolsas=Convert.ToInt32(rows[2]),
                    PesoTotalH = Convert.ToDouble(rows[3]),
                    CostoTotalMP = Convert.ToDouble(rows[4])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        public void GetOrderResumenBolsaInv(int StatusProceso)
        {
            reportDate = DateTime.Now;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenBolsaInv(StatusProceso);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    IdHiloH = Convert.ToString(rows[0]),
                    HiloH = Convert.ToString(rows[1]),
                    Bolsas=Convert.ToInt32(rows[2]),
                    PesoTotalH = Convert.ToDouble(rows[3]),
                    CostoTotalMP = Convert.ToDouble(rows[4])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        //********************************************     Reportes Almacén Crudo   ************************************************

        //********************************************     Reportes Tintorería  ************************************************

        public void GetOrderResumenBolsaT(DateTime fromDate, DateTime toDate, int StatusProceso)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenBolsaT(fromDate, toDate, StatusProceso);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    IdHiloH = Convert.ToString(rows[0]),
                    HiloH = Convert.ToString(rows[1]),
                    ColorRP=Convert.ToString(rows[2]),
                    PesoTotalH = Convert.ToDouble(rows[3]),
                    CostoTotalMP = Convert.ToDouble(rows[4]),
                    Bolsas=Convert.ToInt32(rows[5])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        public void GetOrderResumenBolsaInvT(int StatusProceso)
        {
            reportDate = DateTime.Now;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenBolsaInvT(StatusProceso);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    IdHiloH = Convert.ToString(rows[0]),
                    HiloH = Convert.ToString(rows[1]),
                    ColorRP = Convert.ToString(rows[2]),
                    PesoTotalH = Convert.ToDouble(rows[3]),
                    CostoTotalMP = Convert.ToDouble(rows[4]),
                    Bolsas=Convert.ToInt32(rows[5])
                };
                pruebasL.Add(pruebasModel);
            }
        }
        public void GetOrderResumenNumRemisionAF( int numRemision)
        {
            reportDate = DateTime.Now;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenNumRemisionAF(numRemision);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    IdHiloH = Convert.ToString(rows[0]),
                    HiloH = Convert.ToString(rows[1]),
                    ColorRP = Convert.ToString(rows[2]),
                    PesoTotalH = Convert.ToDouble(rows[3]),
                    CostoTotalMP = Convert.ToDouble(rows[4]),
                    Bolsas=Convert.ToInt32(rows[5])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        //********************************************     Reportes Tintorería  ************************************************

        //********************************************     Reportes Almacén Final  ************************************************

        public void GetOrderResumenBolsaAF(DateTime fromDate, DateTime toDate, int StatusProceso)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenBolsaAF(fromDate, toDate, StatusProceso);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    IdHiloH = Convert.ToString(rows[0]),
                    HiloH = Convert.ToString(rows[1]),
                    ColorRP = Convert.ToString(rows[2]),
                    PesoTotalH = Convert.ToDouble(rows[3]),
                    CostoTotalMP = Convert.ToDouble(rows[4]),
                    Bolsas=Convert.ToInt32(rows[5])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        public void GetOrderResumenBolsaInvAF(int StatusProceso)
        {
            reportDate = DateTime.Now;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenBolsaInvAF(StatusProceso);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    IdHiloH = Convert.ToString(rows[0]),
                    HiloH = Convert.ToString(rows[1]),
                    ColorRP = Convert.ToString(rows[2]),
                    PesoTotalH = Convert.ToDouble(rows[3]),
                    CostoTotalMP = Convert.ToDouble(rows[4]),
                    Bolsas=Convert.ToInt32(rows[5])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        public void GetOrderResumenBolsaSAF(DateTime fromDate, DateTime toDate)
        {
            reportDate = DateTime.Now;
            startDate = fromDate;
            endDate = toDate;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderResumenBolsaSAF(fromDate, toDate);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    IdHiloH = Convert.ToString(rows[0]),
                    HiloH = Convert.ToString(rows[1]),
                    ColorRP = Convert.ToString(rows[2]),
                    PesoTotalH = Convert.ToDouble(rows[3]),
                    CostoTotalMP = Convert.ToDouble(rows[4]),
                    Bolsas=Convert.ToInt32(rows[5])
                };
                pruebasL.Add(pruebasModel);
            }
        }

        //********************************************     Reportes Almacén Final  ************************************************

        public void GetOrderRSucursal(int numRemision, int statusProceso)
        {
            reportDate = DateTime.Now;

            var orderDao = new OrderDao();
            var result = orderDao.GetOrderRSucursal( numRemision,  statusProceso);

            pruebasL = new List<PruebasL>();

            foreach (System.Data.DataRow rows in result.Rows)
            {
                var pruebasModel = new PruebasL()
                {
                    IdHiloH = Convert.ToString(rows[0]),
                    HiloH = Convert.ToString(rows[1]),
                    LoteT = Convert.ToInt32(rows[2]),
                    ColorRP = Convert.ToString(rows[3]),
                    PesoTotalH = Convert.ToDouble(rows[5]),
                    CostoTotalMP = Convert.ToDouble(rows[6]),
                    Bolsas = Convert.ToInt32(rows[7])
                };
                pruebasL.Add(pruebasModel);
            }
        }
    }
}
