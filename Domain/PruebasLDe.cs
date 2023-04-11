using System;

namespace Domain
{
    public class PruebasLDe
    {
        public int IdPedido { get; set; }
        public DateTime FechaCPedido { get; set; }
        public DateTime FechaEPedido { get; set; }
        public string IdHiloPedido { get; set; }
        public string IdColorPedido { get; set; }
        public int IdCajaPedido { get; set; }
        public double CantPedido { get; set; }
        public string IdVendedorPedido { get; set; }
        public string IdClientePedido { get; set; }

        //*******************************************Reportes Almacen Materia Prima *******************************************
        public int IdMP { get; set; }
        public DateTime FechaMP { get; set; }
        public int IdProductoMP { get; set; }
        public string ProductoMP { get; set; }
        public double PesoMP { get; set; }
        public double CostoMP { get; set; }
        public DateTime FechaSMP { get; set; }

        //*******************************************Reportes Almacen Materia Prima *******************************************

        //********************************************     Reportes Hilatura   ************************************************

        public int IdBolsaB { get; set; }
        public DateTime FechaRegistroB { get; set; }
        public string IdHiloB { get; set; }
        public int LoteHilaturaB { get; set; }
        public int IdCajaB { get; set; }
        public double PesoBrutoB { get; set; }
        public double PesoNetoB { get; set; }
        public int LoteTenido { get; internal set; }
        public string NumeroRemision { get; internal set; }
        public string Titulo { get; internal set; }
        public string RazonSocial { get; internal set; }
        public string Edo { get; internal set; }
        public string Ciudad { get; internal set; }
        public string NumPedido { get; internal set; }
        public string Calle { get; internal set; }
        public string Numero { get; internal set; }
        public string Correo { get; internal set; }
        public string Malla { get; internal set; }
        public int NumConos { get; internal set; }
        public double PrecioUnitario { get; set; }
        public string Num { get; internal set; }
        public string LoteV { get; set; }
    }
}