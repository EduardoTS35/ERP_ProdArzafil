using System;
using System.Collections.Generic;
using System.Text;

namespace Commun.Cache
{
    public class AppCache
    {
        string nombre, apelldios, usuario, password;
        int edad,booleano;


        public static string ActualIdHilo { get; set; }
        public static string ActualDescHilo { get; set; }
        public static string ActualTituloHilo { get; set; }
        public static string ActualIdColor { get; set; }
        public static string ActualDescColor { get; set; }
        public static string ActualIdCaja { get; set; }
        public static string ActualDescCaja { get; set; }
        public static string ActualNumConos { get; set; }
        public static string ActualIdCliente { get; set; }
        public static string ActualDescCliente { get; set; }
        public static string ActualIdVendedor { get; set; }
        public static string ActualDescVendedor { get; set; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apelldios { get => apelldios; set => apelldios = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }
        public string IdLogeo { get => idLogeo; set => idLogeo = value; }
        public int Edad { get => edad; set => edad = value; }
        public int Booleano { get => booleano; set => booleano = value; }
        public string IdAdmin { get => idAdmin; set => idAdmin = value; }
        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Idadmin_usuario1 { get => Idadmin_usuario; set => Idadmin_usuario = value; }
        public static string ActualIdMP { get; set; }
        public static string ActualDescMP { get; set; }
        public static string ActualCostoMP { get; set; }
        public static int StatusBascula { get; set; }
        public static string ActualPesoCono { get; set; }
        public static string ActualPesoBolsa { get; set; }

        public static bool modificarBolsafrm { get; set; }

        String idLogeo, idAdmin, idUsuario, Idadmin_usuario;

        //TablaBolsa

        public static int IdBolsa { get; set; }
        public static DateTime FechaRegistro { get; set; }
        public static int NumPedidoBolsa { get; set; }
        public static string IdHilo { get; set; }
        public static string Hilo { get; set; }
        public static string IdColor { get; set; }
        public static int LoteHilatura { get; set; }
        public static int LoteTenido { get; set; }
        public static int IdCaja { get; set; }
        public static double PesoBruto { get; set; }
        public static double PesoNeto { get; set; }
        public static int NumConos { get; set; }
        public static string Malla { get; set; }
        public static string ColorCono { get; set; }

        //Tabla Materia Prima

        public static int IDMateriaPrima { get; set; }
        public static DateTime FechaEntradaMP { get; set; }
        public static DateTime FechaSalidaMP { get; set; }
        public static int IdProductoMP { get; set; }
        public static string ProductoMP { get; set; }
        public static double PesoMP { get; set; }
        public static double CostoMP { get; set; }
        public static int StatusProceso { get; set; }
        public static string ActualColorLoteT { get; set; }
    }
}
