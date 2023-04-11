namespace Domain
{
    public class PruebasL
    {
        public string ProductoRP { get; set; }
        public string ColorRP { get; set; }
        public double CantidadRP { get; set; }


        //*******************************************Reportes Almacen Materia Prima *******************************************
        public string ProductoMP { get; set; }
        public double PesoTotalMP { get; set; }
        public double CostoTotalMP { get; set; }
        //*******************************************Reportes Almacen Materia Prima *******************************************

        //********************************************     Reportes Hilatura   ************************************************
        public string IdHiloH { get; set; }
        public string HiloH { get; set; }
        public double PesoTotalH { get; set; }
        public double CostoTotalH { get; set; }
        public int Bolsas { get; set; }

        public int LoteT { get; set; }

        //********************************************     Reportes Hilatura   ************************************************
    }
}