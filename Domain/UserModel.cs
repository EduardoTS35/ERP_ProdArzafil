using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DataAccess;
using Commun.Cache;
namespace Domain
{
    public class UserModel
    {
        UserDao userDao = new UserDao();
        AppCache ent = new AppCache();
        public bool LoginUser(string user, string pass)
        {
            return userDao.Login(user, pass);
        }

        public DataTable MostrarUsuarios()
        {
            DataTable table = new DataTable();
            table = userDao.MostrarUsuarios();
            return table;
        }

        public DataTable MostrarPedidos()
        {
            DataTable table = new DataTable();
            table = userDao.MostrarPedidos();
            return table;
        }

        public DataTable MostrarCatalogoHilos()
        {
            DataTable table = new DataTable();
            table = userDao.MostrarCatalgoHilos();
            return table;
        }

        public DataTable MostrarCatalogoColores()
        {
            DataTable table = new DataTable();
            table = userDao.MostrarCatalgoColores();
            return table;
        }

        public DataTable MostrarCatalogoCajas()
        {
            DataTable table = new DataTable();
            table = userDao.MostrarCatalgoCajas();
            return table;
        }

        public DataTable MostrarCatalogoVendedores()
        {
            DataTable table = new DataTable();
            table = userDao.MostrarCatalgoVendedores();
            return table;
        }

        public DataTable MostrarCatalogoClientes()
        {
            DataTable table = new DataTable();
            table = userDao.MostrarCatalgoClientes();
            return table;
        }

        //Insertar Pedidos
        public int IdPrimario { get; set; }
        public int IDPedido { get; set; }
        public DateTime FechaC { get; set; }
        public DateTime FechaE { get; set; }
        public string IdHilo { get; set; }
        public string IdColor { get; set; }
        public int IdCaja { get; set; }
        public int CantPedido { get; set; }
        public int IdVendedor { get; set; }
        public int IdCliente { get; set; }

        public void InsertarDatosMasivo(IEnumerable<UserModel> salidasLotes)
        {
            var userDao = new UserDao();
            var table = new DataTable();

            table.Columns.Add("IdPrimario", typeof(int));
            table.Columns.Add("IDPedido", typeof(int));
            table.Columns.Add("FechaC", typeof(DateTime));
            table.Columns.Add("FechaE", typeof(DateTime));
            table.Columns.Add("IdHilo", typeof(string));
            table.Columns.Add("IdColor", typeof(string));
            table.Columns.Add("IdCaja", typeof(int));
            table.Columns.Add("CantPedido", typeof(int));
            table.Columns.Add("IdVendedor", typeof(int));
            table.Columns.Add("IdCliente", typeof(int));

            foreach (var itemDetail in salidasLotes)
            {
                table.Rows.Add(new object[]
                {
                    itemDetail.IdPrimario,
                    itemDetail.IDPedido,
                    itemDetail.FechaC,
                    itemDetail.FechaE,
                    itemDetail.IdHilo,
                    itemDetail.IdColor,
                    itemDetail.IdCaja,
                    itemDetail.CantPedido,
                    itemDetail.IdVendedor,
                    itemDetail.IdCliente
                });
            }
            userDao.InsertarMasivoPedido(table);
        }

        public void CorregirBulk()
        {
            userDao.CorregirErrorBulk();
        }

        public void ModificarPedidos( DateTime FechaE, string IDPedido)
        {
            userDao.ModificarPedidos(Convert.ToDateTime(FechaE), Convert.ToInt32(IDPedido));
        }
        public void ModificarPedidos(string idHilo, string idColor, string idCaja, string pesoPedido, string idPrimario)
        {
            userDao.ModificarPedidos(idHilo,idColor,Convert.ToInt32(idCaja),Convert.ToDouble(pesoPedido),Convert.ToInt32(idPrimario));
        }

        public void BorrarPedido(string IdPedido)
        {
            userDao.BorrarPedido(Convert.ToInt32(IdPedido));
        }

        //Insertar Pedidos

        public void InsertarUSuarios(string Nombre, string Apellido, string Usuario, string Contraseña, string Cargo, string Area, string CorreoE)
        {
            userDao.InsertarUsuarios(Nombre, Apellido, Usuario, Contraseña, Cargo, Area, CorreoE);
        }

        public void EditarUSuarios(string Nombre, string Apellido, string Usuario, string Contraseña, string Cargo, string Area, string CorreoE, string IdUsuario)
        {
            userDao.ModificarUsuarios(Nombre, Apellido, Usuario, Contraseña, Cargo, Area, CorreoE, Convert.ToInt32(IdUsuario));
        }

        public void BorrarUsuario(string IdUsuario)
        {
            userDao.BorrarUsuario(Convert.ToInt32(IdUsuario));
        }

        public void InsertarClientes(string RazaonSocial, string Calle, string Ciudad, string Edo, string RFC, string Etiqueta, string Caja, string Plaza, string Contacto)
        {
            userDao.InsertarClientes(RazaonSocial, Calle, Ciudad, Edo, RFC,Etiqueta, Convert.ToInt32(Caja), Plaza, Contacto);
        }

        public void EditarClientes(string RazaonSocial, string Calle, string Ciudad, string Edo, string RFC, string Etiqueta, string Caja, string Plaza, string Contacto, string IdCliente)
        {
            userDao.ModificarClientes(RazaonSocial, Calle, Ciudad, Edo, RFC,Etiqueta, Convert.ToInt32(Caja), Plaza, Contacto, Convert.ToInt32(IdCliente));
        }

        public void BorrarClientes(string IdCliente)
        {
            userDao.BorrarCliente(Convert.ToInt32(IdCliente));
        }

        //----------------------------------------------graba_admin_usuario
        public DataTable graba_admin_usuario(AppCache ent)
        {
            return userDao.graba_admin_usuario(ent);
        }
        //----------------------------------------------graba_cuenta_usuario
        public DataTable graba_cuenta_usuario(AppCache ent)
        {
            return userDao.graba_cuenta_usuario(ent);
        }
        //----------------------------------------------actualizar_cuenta_usuario
        public DataTable actualizar_cuenta_usuario(AppCache ent)
        {
            return userDao.actualizar_cuenta_usuario(ent);
        }
        //----------------------------------------------------Ver_Cod_login
        public DataTable Ver_admin_usuario()
        {
            return userDao.Ver_admin_usuario();
        }
        //----------------------------------------------------Ver_Cod_login
        public DataTable Mostrar_admin_usuario()
        {
            return userDao.Mostrar_admin_usuario();
        }
        //----------------------------------------------------ver_datos_admin_usuario
        public DataTable ver_datos_logueo()
        {
            return userDao.ver_datos_logueo();
        }
        //----------------------------------------------------Ver_Cod_login
        public DataTable Ver_Cod_login()
        {
            return userDao.Ver_Cod_login();
        }
        //----------------------------------------------------Ver_Cod_login
        public DataTable Ver_Cod_Admin()
        {
            return userDao.Ver_Cod_Admin();
        }
        //--------------------------------------------------Consultar_Contra
        public DataTable Consultar_Contra(string usuario)
        {
            return userDao.Consultar_Contraseña(usuario);
        }
        //--------------------------------------------------Mostrar_Administradores
        public DataTable Mostrar_Admin()
        {
            return userDao.Mostrar_Administradores();
        }
        //--------------------------------------------------Mostrar_Usuarios
        public DataTable Mostrar_Usuarios()
        {
            return userDao.Mostrar_Usuarios();
        }
        //---------------------------------------------------Guardar_Admin
        public DataTable graba_administrador(AppCache ent)
        {
            return userDao.graba_administrador(ent);
        }

        //---------------------------------------------------Guardar_Usuario

        public DataTable graba_usuarios(AppCache ent)
        {
            return userDao.graba_usuarios(ent);
        }
        //---
        //----------------------------------------------------Eliminar_Admin
        public void Eliminar_Admin(string idAdmin)
        {
            userDao.Eliminar_Admin(idAdmin);
        }
        //----------------------------------------------------Eliminar_Usuario
        public void Eliminar_Usuario(string idUsuario)
        {
            userDao.Eliminar_Usuario(idUsuario);
        }
        //----------------------------------------------------Mostrar Cod Admin
        public DataTable Mostrar_Cod_Admin()
        {
            return userDao.Mostrar_Cod_Admin();
        }
        //----------------------------------------------------Mostrar Cod Usuario
        public DataTable Mostrar_Cod_Usuario()
        {
            return userDao.Mostrar_Cod_Usuario();
        }

        //----------------------------------------Módulo Materia Prima ----------------------------------------------------------------

        //Mostrar Cátalogo MP
        public DataTable MostrarCatalogoMP()
        {
            return userDao.MostrarCatalogoMP();
        }
        public DataTable MostrarCatalogoMP2()
        {
            return userDao.MostrarCatalogoMP2();
        }

        //Mostrar Entradas MP
        public DataTable MostrarEntradasMP()
        {
            return userDao.MostrarEntradasMP();
        }

        //Insertar Entradas MP
        public void InsertarEntradasMP(string IdProducto, string Producto, string Peso, string Costo,int proveedor)
        {
            userDao.InsertarEntradas(IdProducto, Producto, Convert.ToDouble(Peso), Convert.ToDouble(Costo),proveedor);
        }

        //Mostrar Material existente MP
        public DataTable MostrarMaterialExistenteMP(string Producto)
        {
            return userDao.MostrarMaterialExistenteMP(Producto);
        }

        //Insertar Salidas MP
        public void InsertarSalidasMP(string IdProducto, string Producto, string Peso, string Costo,int proveedor)
        {
            userDao.InsertarSalidasMP(IdProducto, Producto, Convert.ToDouble(Peso), Convert.ToDouble(Costo),proveedor);
        }

        //Mostrar Salidas MP
        public DataTable MostrarSalidasMP()
        {
            return userDao.MostrarSalidasMP();
        }

        //Eliminar Movimiento MP
        public void EliminarMovimientoMP(string ID)
        {
            userDao.EliminarMovimientoMP(Convert.ToInt32(ID));
        }

        //----------------------------------------Módulo Hilatura ----------------------------------------------------------------

        // Mostrar Material Existente Hilatura
        public DataTable MostrarMaterialHilatura(string producto)
        {
            return userDao.MostrarMaterialHilatura(producto);
        }

        //Insertar Entradas MP
        public void InsertarEntradasHilaturaMP(string IdProducto, string Producto, string Peso, string Costo)
        {
            userDao.InsertarEntradasHilaturaMP(IdProducto, Producto, Convert.ToDouble(Peso), Convert.ToDouble(Costo));
        }

        //Insertar Componentes MP
        public void InsertarComponentesHilatura(string IdProducto, string Producto, string Peso,string Costo)
        {
            userDao.InsertarComponentesHilatura(IdProducto, Producto, Convert.ToDouble(Peso)*-1,Convert.ToDouble(Costo)*-1);
        }

        //Insertar Entradas Hilatura Bolsa
        public void InsertarSalidasH(string IdBolsa, string IdHilo, string LoteHilatura, string IdCaja, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso,string Malla,string ColorCono,string Notas)
        {
            userDao.InsertarSalidasH(Convert.ToInt32(IdBolsa), IdHilo, Convert.ToInt32(LoteHilatura), Convert.ToInt32(IdCaja), Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToInt32(NumConos), Convert.ToInt32(StatusProceso),Malla,ColorCono,Notas);
        }

        //Insertar Entradas Hilatura Reportes Bolsa
        public void InsertarSalidasHReporte(string IdBolsa, string IdHilo, string LoteHilatura, string IdCaja, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso, string Malla, string ColorCono,string Notas)
        {
            userDao.InsertarSalidasHReporte(Convert.ToInt32(IdBolsa), IdHilo, Convert.ToInt32(LoteHilatura), Convert.ToInt32(IdCaja), Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToInt32(NumConos), Convert.ToInt32(StatusProceso),Malla,ColorCono,Notas);
        }

        public void InsertarSalidasH(string IdBolsa, string idPedido,string IdHilo,string idColor, string LoteHilatura,string LoteT, string IdCaja, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso, string Malla, string ColorCono, string Notas)
        {
            userDao.InsertarSalidasH(Convert.ToInt32(IdBolsa),Convert.ToInt32(idPedido), IdHilo,idColor, Convert.ToInt32(LoteHilatura),Convert.ToInt32(LoteT), Convert.ToInt32(IdCaja), Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToInt32(NumConos), Convert.ToInt32(StatusProceso), Malla, ColorCono,Notas);
        }

        //Insertar Entradas Hilatura Reportes Bolsa
        public void InsertarSalidasHReporte(string IdBolsa, string idPedido, string IdHilo, string idColor, string LoteHilatura, string LoteT, string IdCaja, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso, string Malla, string ColorCono,string Notas)
        {
            userDao.InsertarSalidasHReporte(Convert.ToInt32(IdBolsa), Convert.ToInt32(idPedido), IdHilo, idColor, Convert.ToInt32(LoteHilatura), Convert.ToInt32(LoteT), Convert.ToInt32(IdCaja), Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToInt32(NumConos), Convert.ToInt32(StatusProceso), Malla, ColorCono,Notas);
        }

        //Mostrar IdBolsa
        public DataTable MostrarIdBolsa()
        {
            return userDao.MostrarIdBolsa();
        }

        //Calcular Peso Componente
        public DataTable CalcularPesoComponente(string IdHilo, string PesoNeto)
        {
            return userDao.CalcularPesoComponente(IdHilo,Convert.ToDouble(PesoNeto));
        }

        //Mostrar Entrada Config Hilatura Bolsa
        public DataTable MostrarEHilatura(string IdBolsa)
        {
            return userDao.MostrarEHilatura(Convert.ToInt32(IdBolsa));
        }

        //Eliminar Entrada Config Hilatura Bolsa
        public void EliminarEHilatura(string IdBolsa)
        {
            userDao.EliminarEHilatura(Convert.ToInt32(IdBolsa));
        }

        //Eliminar Entrada Config Hilatura Reporte Bolsa
        public void EliminarEHilaturaReporte(string IdBolsa)
        {
            userDao.EliminarEHilaturaReporte(Convert.ToInt32(IdBolsa));
        }

        //Eliminar Entrada MP
        public void EliminarEntradaMP(string IdProducto,string Producto,string Peso,string Costo)
        {
            userDao.EliminarEntradaMP(Convert.ToInt32(IdProducto),Producto,Convert.ToDouble(Peso),Convert.ToDouble(Costo));
        }

        //Mostrar Entradas
        public DataTable MostrarEntradasH()
        {
            return userDao.MostrarEntradasH();
        }

        //Mostrar Entradas
        public DataTable MostrarSalidasH()
        {
            return userDao.MostrarSalidasH();
        }

        //GuardarInfoBolsa
        public bool GuardarInfoBolsa(int IdBolsa)
        {
            return userDao.GuardarInfoBolsaConfigH(IdBolsa);
        }

        //----------------------------------------Módulo Almacén Crudo----------------------------------------------------------------

        //Mostrar Datos Bolsa
        public DataTable MostrarDBolsaAC(string IdBolsa,string StatusProceso)
        {
            return userDao.MostrarDBolsaAC(Convert.ToInt32(IdBolsa),Convert.ToInt32(StatusProceso));
        }

        //Mostrar Datos Entradas
        public DataTable MostrarDEntradasAC()
        {
            return userDao.MostrarDEntradasAC();
        }

        //Insertar Entradas Almacén Crudo Reporte Bolsa
        public void InsertarEntradaAC(string IdBolsa, string IdHilo, string LoteHilatura, string IdCaja, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso,string Malla,string ColorCono)
        {
            string Notas = "";
            userDao.InsertarEntradaAC(Convert.ToInt32(IdBolsa), IdHilo, Convert.ToInt32(LoteHilatura), Convert.ToInt32(IdCaja), Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToInt32(NumConos), Convert.ToInt32(StatusProceso),Malla,ColorCono,Notas);
        }

        //Insertar Salidas Almacén Crudo Reporte Bolsa
        public void InsertarSalidasAC(string IdBolsa, string NumPedido,string IdHilo, string LoteHilatura, string IdCaja, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso, string Malla, string ColorCono)
        {
            userDao.InsertarSalidasAC(Convert.ToInt32(IdBolsa), Convert.ToInt32(NumPedido), IdHilo, Convert.ToInt32(LoteHilatura), Convert.ToInt32(IdCaja), Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToInt32(NumConos), Convert.ToInt32(StatusProceso), Malla, ColorCono);
        }

        //Actualizar Entradas Almacén Crudo Bolsa
        public void ActualizarStatusBolsa(string IdBolsa, string StatusProceso)
        {
            userDao.ActualizarStatusBolsa(Convert.ToInt32(IdBolsa), Convert.ToInt32(StatusProceso));
        }

        //Mostrar Datos Salidas
        public DataTable MostrarDSalidasAC()
        {
            return userDao.MostrarDSalidasAC();
        }

        //Eliminar Movimiento Reporte Bolsa
        public void EliminarMovimientoReporteBolsa(string IdBolsa, string StatusProceso)
        {
            userDao.EliminarMovimientoReporteBolsa(Convert.ToInt32(IdBolsa), Convert.ToInt32(StatusProceso));
        }


        //----------------------------------------Módulo Almacén Crudo----------------------------------------------------------------

        //----------------------------------------Módulo Tintoreriía----------------------------------------------------------------
        

        //Mostrar Datos Entradas
        public DataTable MostrarEntradasT()
        {
            return userDao.MostrarEntradasT();
        }

        //Actualizar Entradas Tintoreia
        public void AgregarDatosT(string IdBolsa, string LoteT,string Color)
        {
            userDao.AgregarDatosT(Convert.ToInt32(IdBolsa), Convert.ToInt32(LoteT),Color);
        }

        //Insertar Entradas Tintoreria Reporte Bolsa
        public void InsertarEntradasTRB(string IdBolsa, string NumPedido,string IdHilo,string IdColor, string LoteHilatura,string LoteT, string IdCaja, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso, string Malla, string ColorCono)
        {
            userDao.InsertarEntradasTRB(Convert.ToInt32(IdBolsa),Convert.ToInt32(NumPedido) ,IdHilo,IdColor, Convert.ToInt32(LoteHilatura), Convert.ToInt32(LoteT), Convert.ToInt32(IdCaja), Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToInt32(NumConos), Convert.ToInt32(StatusProceso), Malla, ColorCono);
        }

        //Mostrar Lote Teñido
        public DataTable MostrarLoteActualT()
        {
            return userDao.MostrarLoteActualT();
        }

        //Mostrar Datos Salidas
        public DataTable MostrarSalidasT()
        {
            return userDao.MostrarSalidasT();
        }

        //Mostrar Datos Lote
        public DataTable MostrarLoteT(string LoteT)
        {
            return userDao.MostrarLoteT(Convert.ToInt32(LoteT));
        }

        //Mostrar Datos Bolsa
        public DataTable MostrarBolsaT1(string IdBolsa)
        {
            return userDao.MostrarBolsaT1(Convert.ToInt32(IdBolsa));
        }

        //Mostrar Datos Bolsa
        public DataTable MostrarBolsaT(string IdBolsa)
        {
            return userDao.MostrarBolsaT(Convert.ToInt32(IdBolsa));
        }

        // Cambiar Datos Lote
        public void ActualizarLote(string LoteT)
        {
            userDao.ActualizarLote(Convert.ToInt32(LoteT));
        }
        //VALIDAR ENTRADA TINTORERIA
        public bool ValidarEntradaT(int idBolsa,string idColor)
        {
            return userDao.ValidarEntradaT(idBolsa,idColor);
        }
        public bool ValidarColorLoteT(int loteT)
        {
            return userDao.ValidarColorLoteT(loteT);
        }
        //----------------------------------------Módulo Tintoreriía----------------------------------------------------------------

        //----------------------------------------Módulo Hilatura Reenconado----------------------------------------------------------------
        public DataTable MostrarEntradasHR()
        {
            return userDao.MostrarEntradasHR();
        }

        //Insertar Entradas HR
        public void InsertarEntradasHR(string IdBolsa, string IdHilo, string IdColor, string LoteHilatura, string LoteT, string IdCaja, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso, string Malla, string ColorCono)
        {
            userDao.InsertarEntradasHR(Convert.ToInt32(IdBolsa), IdHilo, IdColor, Convert.ToInt32(LoteHilatura), Convert.ToInt32(LoteT), Convert.ToInt32(IdCaja), Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToInt32(NumConos), Convert.ToInt32(StatusProceso), Malla, ColorCono);
        }

        //Mostrar Datos Salidas
        public DataTable MostrarSalidasHr()
        {
            return userDao.MostrarSalidasHR();
        }

        //Mostrar Datos Bolsa
        public DataTable MostrarBolsaHR(string IdBolsa)
        {
            return userDao.MostrarBolsaHR(Convert.ToInt32(IdBolsa));
        }

        //Mostrar Datos Bolsa Salidas
        public DataTable MostrarBolsaSHR(string IdBolsa)
        {
            return userDao.MostrarBolsaSHR(Convert.ToInt32(IdBolsa));
        }

        //----------------------------------------Módulo Hilatura Reenconado----------------------------------------------------------------

        //----------------------------------------Módulo Almacén Final----------------------------------------------------------------
        public DataTable MostrarEntradasAF()
        {
            return userDao.MostrarEntradasAF();
        }

        //Insertar Entradas HR
        public void InsertarEntradasAF(string IdBolsa, string NumPedido,string IdHilo, string IdColor, string LoteHilatura, string LoteT, string IdCaja, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso, string Malla, string ColorCono)
        {
            userDao.InsertarEntradasAF(Convert.ToInt32(IdBolsa), Convert.ToInt32(NumPedido), IdHilo, IdColor, Convert.ToInt32(LoteHilatura), Convert.ToInt32(LoteT), Convert.ToInt32(IdCaja), Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToInt32(NumConos), Convert.ToInt32(StatusProceso), Malla, ColorCono);
        }

        //Mostrar Datos Salidas
        public DataTable MostrarSalidasAF()
        {
            return userDao.MostrarSalidasAF();
        }

        //Mostrar Datos Bolsa
        public DataTable MostrarBolsaAF(string IdBolsa)
        {
            return userDao.MostrarBolsaAF(Convert.ToInt32(IdBolsa));
        }

        //Mostrar Datos Bolsa Salidas
        public DataTable MostrarBolsaSAF(string IdBolsa)
        {
            return userDao.MostrarBolsaSAF(Convert.ToInt32(IdBolsa));
        }

        //Mostrar Datos Bolsa Salidas
        public DataTable MostrarBolsaSAF2(string IdBolsa, string NumPedido)
        {
            return userDao.MostrarBolsaSAF2(Convert.ToInt32(IdBolsa), Convert.ToInt32(NumPedido));
        }

        //Insertar Salidas HR
        public void InsertarSalidasAF(string IdBolsa, string NumPedido, string IdHilo, string IdColor, string LoteHilatura, string LoteT, string IdCaja, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso,string NumRemision ,string Malla, string ColorCono)
        {
            userDao.InsertarSalidasAF(Convert.ToInt32(IdBolsa), Convert.ToInt32(NumPedido), IdHilo, IdColor, Convert.ToInt32(LoteHilatura), Convert.ToInt32(LoteT), Convert.ToInt32(IdCaja), Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToInt32(NumConos), Convert.ToInt32(StatusProceso),Convert.ToInt32(NumRemision), Malla, ColorCono);
        }

        //Mostrar Nuevo Pedido
        public DataTable MostrarNuevoPedido()
        {
            return userDao.MostrarNuevoPedido();
        }

        //Mostrar Nuevo Pedido
        public DataTable MostrarNuevoNRemision()
        {
            return userDao.MostrarNuevoNRemision();
        }

        //Mostrar Nuevo Pedido
        public DataTable MostrarNumeroRemision()
        {
            return userDao.MostrarNumeroRemision();

        }

        public bool ValidarSalidasAF(int idBolsa, int idPedido)
        {
            return userDao.ValidarSalidasAF(idBolsa,idPedido);
        }
        //----------------------------------------Módulo Almacén Final----------------------------------------------------------------

        //----------------------------------------Módulo Sucursales----------------------------------------------------------------
        public DataTable MostrarBolsaSucursales(string IdBolsa, string statusProceso)
        {
            return userDao.MostrarBolsaSucursales(Convert.ToInt32(IdBolsa), Convert.ToInt32(statusProceso));
        }
        public DataTable MostrarSucursal( string statusProceso)
        {
            return userDao.MostrarSucursal( Convert.ToInt32(statusProceso));
        }
        public void InsertarEntradaSucursales(string IdBolsa, string NumPedido, string IdHilo, string IdColor, string IdCaja, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso)
        {
            userDao.InsertarEntradaSucursal(Convert.ToInt32(IdBolsa), Convert.ToInt32(NumPedido), IdHilo, IdColor, Convert.ToInt32(IdCaja), Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToInt32(NumConos), Convert.ToInt32(StatusProceso));
        }
        public void InsertarSalidaSucursales(string IdBolsa, string NumPedido, string IdHilo, string IdColor, string IdCaja, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso,string NumRemision,string Precio,int idCliente)
        {
            try
            {
                userDao.InsertarSalidaSucursal(Convert.ToInt32(IdBolsa), Convert.ToInt32(NumPedido), IdHilo, IdColor, Convert.ToInt32(IdCaja), Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToInt32(NumConos), Convert.ToInt32(StatusProceso), Convert.ToInt32(NumRemision), Convert.ToDouble(Precio),idCliente);
            }
            catch
            {

            }
            
        }
        public void InsertarClienteSucursal(string nombre, Int64 contacto, int plaza,string calle,string edo,string ciudad)
        {
            userDao.InsertarClienteSucursal(nombre, contacto, plaza,calle,edo,ciudad);
        }
        public void EliminarClienteSucursal(int idCliente)
        {
            userDao.EliminarClienteSucursal(idCliente);
        }

        public void EditarClienteSucursal(string nombre, Int64 contacto, int plaza, string calle, string edo, string ciudad, int idCliente)
        {
            userDao.EditarClienteSucursal(nombre, contacto, plaza,calle,edo,ciudad,idCliente);
        }
        public DataTable MostrarClienteSucursal()
        {
            return userDao.MostrarClienteSucursal();
        }
        public void EliminarVenta(int idBolsa)
        {
            userDao.EliminarVenta(idBolsa);
        }
        public DataTable MostrarLoteDeVentaSig()
        {
            return userDao.MostrarLoteDeVentaSig();
        }

        //----------------------------------------Módulo Sucursales----------------------------------------------------------------

        //----------------------------------------Configuración Hilos----------------------------------------------------------------
        //Seleccionar Componentes Hilos
        public DataTable SeleccionarComponentesH(string IdHilo)
        {
            return userDao.SeleccionarComponentesH(IdHilo);
        }

        public DataTable MostrarHilos()
        {
            return userDao.MostrarHilos();
        }

        public void InsertarHilo(string IdHilo, string Hilo, string Titulo, string Precio)
        {
            userDao.InsertarHilo(IdHilo,Hilo,Titulo,Convert.ToDouble(Precio));
        }

        public void InsertarComponente(string IdHilo, string Hilo, string Titulo, string Porcentaje, string Componente, string Precio)
        {
            userDao.InsertarComponente( IdHilo, Hilo, Titulo,Convert.ToDouble(Porcentaje), Componente, Convert.ToDouble(Precio));
        }

        public void ActualizarHilo(string IdHiloG, string IdHilo, string Hilo, string Titulo, string Precio)
        {
            userDao.ActualizarHilo(IdHiloG, IdHilo , Hilo, Titulo, Convert.ToDouble(Precio));
        }


        public void ActualizarComponente(string Hilo, string ComponenteG, string Componente, string Porcentaje)
        {
            userDao.ActualizarComponente( Hilo, ComponenteG, Componente, Convert.ToDouble(Porcentaje));
        }

        public void EliminarHilo(string IdHilo)
        {
            userDao.EliminarHilo( IdHilo);
        }


        public void EliminarComponente(string IdHilo, string Componente)
        {
            userDao.EliminarComponente(IdHilo, Componente);
        }



        //----------------------------------------Configuración Hilos----------------------------------------------------------------

        //----------------------------------------Configuración Cajas----------------------------------------------------------------
        public void InsertarCaja(string DescCaja, string TaraCono, string TaraBolsa)
        {
            userDao.InsertarCaja(DescCaja, Convert.ToDouble(TaraCono), Convert.ToDouble(TaraBolsa));
        }

        public void ActualizarCaja(string IdCaja,string DescCaja, string TaraCono, string TaraBolsa)
        {
            userDao.ActualizarCaja(Convert.ToInt32(IdCaja),DescCaja, Convert.ToDouble(TaraCono), Convert.ToDouble(TaraBolsa));
        }


        public void EliminarCaja(string IdCaja)
        {
            userDao.EliminarCaja(Convert.ToInt32(IdCaja));
        }

        //----------------------------------------Configuración Hilos----------------------------------------------------------------

        //----------------------------------------Configuración Color----------------------------------------------------------------
        public void InsertarColor(string IdColor, string Color)
        {
            userDao.InsertarColor(IdColor,Color);
        }

        public void ActualizarColor(string IdColorG, string IdColor, string Color)
        {
            userDao.ActualizarColor(IdColorG,IdColor,Color);
        }


        public void EliminarColor(string IdColor)
        {
            userDao.EliminarColor(IdColor);
        }

        //----------------------------------------Configuración Color----------------------------------------------------------------

        //----------------------------------------Configuración Vendedor----------------------------------------------------------------

        public void InsertarVendedor(string Plaza, string Nombre, string Apellido)
        {
            userDao.InsertarVendedor(Convert.ToInt32(Plaza),Nombre,Apellido);
        }

        public void ActualizarVendedor(string Plaza, string Nombre, string Apellido, string IdVendedor)
        {
            userDao.ActualizarVendedor(Convert.ToInt32(Plaza),Nombre,Apellido, Convert.ToInt32(IdVendedor));
        }


        public void EliminarVendedor(string IdVendedor)
        {
            userDao.EliminarVendedor(Convert.ToInt32(IdVendedor));
        }

        //----------------------------------------Configuración Vendedor----------------------------------------------------------------

        //----------------------------------------Configuración Materia Prima----------------------------------------------------------------
        public void InsertarMateriaP(string Producto, string Costo)
        {
            userDao.InsertarMateriaP(Producto,Convert.ToDouble(Costo));
        }

        public void ActualizarMateriaP(string IdProducto, string Producto, string Costo)
        {
            userDao.ActualizarMateriaP(Convert.ToInt32(IdProducto),Producto,Convert.ToDouble(Costo));
        }


        public void EliminarMateriaP(string IdProducto)
        {
            userDao.EliminarMateriaP(Convert.ToInt32(IdProducto));
        }
        //----------------------------------------Configuración Materia Prima----------------------------------------------------------------

        //----------------------------------------Configuración Bolsas ----------------------------------------------------------------
        public DataTable MostrarBolsas(string StatusProceso)
        {
            return userDao.MostrarBolsas(Convert.ToInt32(StatusProceso));
        }

        public DataTable MostrarBolsas()
        {
            return userDao.MostrarBolsas();
        }

        public void ActualizarBolsa(string IdBolsa, string NumPedido, string StatusProceso, string StatusProcesoG,string PesoBruto, string IdCaja, string NumConos)
        {
            if (NumPedido != "")
            {
                userDao.ActualizarBolsa(Convert.ToInt32(IdBolsa), Convert.ToInt32(NumPedido), Convert.ToInt32(StatusProceso), Convert.ToInt32(StatusProcesoG), Convert.ToDouble(PesoBruto), Convert.ToInt32(IdCaja), Convert.ToInt32(NumConos));
            }
            else
            {
                userDao.ActualizarBolsa(Convert.ToInt32(IdBolsa), 0, Convert.ToInt32(StatusProceso), Convert.ToInt32(StatusProcesoG), Convert.ToDouble(PesoBruto), Convert.ToInt32(IdCaja), Convert.ToInt32(NumConos));
            }
            
        }


        public void EliminarBolsa(string IdBolsa)
        {
            userDao.EliminarBolsa(Convert.ToInt32(IdBolsa));
        }

        public bool SeleccionarBolsa(int IdBolsa)
        {
            return userDao.SeleccionarBolsa(IdBolsa);
        }

        public void CrearNuevaBolsa(string IdBolsa, string NumPedido, string IdHilo, string IdColor, string LoteHilatura, string LoteTenido, string IdCaja, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso, string Malla, string ColorCono)
        {
            userDao.CrearNuevaBolsa(Convert.ToInt32(IdBolsa), Convert.ToInt32(NumPedido),IdHilo,IdColor, Convert.ToInt32(LoteHilatura), Convert.ToInt32(LoteTenido), Convert.ToInt32(IdCaja), Convert.ToDouble(PesoBruto), Convert.ToDouble(PesoNeto), Convert.ToInt32(NumConos),Convert.ToInt32(StatusProceso),Malla,ColorCono);
        }
        public void ModificarBolsa(string IdBolsa, string PesoBruto, string PesoNeto, string NumConos, string StatusProceso)
        {
            userDao.ModificarBolsa(Convert.ToInt32(IdBolsa),Convert.ToDouble(PesoBruto),Convert.ToDouble(PesoNeto),Convert.ToInt32(NumConos),Convert.ToInt32(StatusProceso));
        }
        public DataTable MostrarStatus()
        {
            return userDao.MostrarStatus();
        }
        //----------------------------------------Configuración Bolsas ----------------------------------------------------------------

        //----------------------------------------Validaciones ----------------------------------------------------------------

        //---------------------Config Usuarios ----------------------------------------------------------------
        public bool ValidarNombresUsuarios(string nombre, string apellido)
        {
            return userDao.ValidarNombresUsuarios(nombre, apellido);
        }
        public bool ValidarUsuario(string user)
        {
            return userDao.ValidarUsuario(user);
        }
        //public bool ValidarCorreo(string correo)
        //{
        //    return userDao.ValidarCorreo(correo);
        //}
        //---------------------Config Usuarios ----------------------------------------------------------------

        //---------------------Config Productos ----------------------------------------------------------------
        public bool ValidarIdHilo(string idHilo)
        {
            return userDao.ValidarIdHilo(idHilo);
        }
        public bool ValidarDescHilo(string hilo,string titulo)
        {
            return userDao.ValidarDescHilo(hilo,titulo);
        }
        public bool ValidarComponenteH(string idHilo, string componente)
        {
            return userDao.ValidarComponenteH(idHilo, componente);
        }

        public DataTable ValidarComponentesT(string idHilo)
        {
            return userDao.ValidarComponentesT(idHilo);
        }
        //---------------------Config Productos ----------------------------------------------------------------

        //---------------------Config Cajas ----------------------------------------------------------------
        public bool ValidarDescCaja(string desc)
        {
            return userDao.ValidarDescCaja(desc);
        }
        public bool ValidarCarCaja(double taraCono, double taraBolsa)
        {
            return userDao.ValidarCarCaja(taraCono, taraBolsa);
        }
        //---------------------Config Cajas ----------------------------------------------------------------

        //---------------------Config Color ----------------------------------------------------------------
        public bool ValidarDescColor(string desc)
        {
            return userDao.ValidarDescColor(desc);
        }

        public bool ValidarIdColor(string idColor)
        {
            return userDao.ValidarIdColor(idColor);
        }
        //---------------------Config Color ----------------------------------------------------------------

        //---------------------Config Clientes ----------------------------------------------------------------
        public bool ValidarRazonSocial(string rSocial)
        {
            return userDao.ValidarRazonSocial(rSocial);
        }

        public bool ValidarRFC(string rfc)
        {
            return userDao.ValidarRFC(rfc);
        }
        //---------------------Config Clientes ----------------------------------------------------------------

        //---------------------Config Vendedores ----------------------------------------------------------------
        public bool ValidarVendedor(string nombre, string apellido)
        {
            return userDao.ValidarVendedor(nombre,apellido);
        }
        //---------------------Config Vendedores ----------------------------------------------------------------

        //---------------------Config Materia Prima ----------------------------------------------------------------
        public bool ValidarDescMP(string desc)
        {
            return userDao.ValidarDescMP(desc);
        }
        //---------------------Config Materia Prima ----------------------------------------------------------------
        //----------------------------------------Validaciones ----------------------------------------------------------------

        //---------------------------- Proveedores --------------------------------------
        public DataTable ver_Proveedores()
        {
            return userDao.ver_Proveedores();
        }
        public void insertar_Proveedores(string razonSocial, string contacto)
        {
            userDao.insertar_Proveedores(razonSocial,contacto);
        }
        public void actualizar_Proveedores(string razonSocial, string contacto, int idProveedor)
        {
            userDao.actualizar_Proveedores(razonSocial, contacto, idProveedor);
        }
        public void eliminar_Proveedor(int idProveedor)
        {
            userDao.eliminar_Proveedor(idProveedor);
        }

        //--------------------- Elimiar Registros Duplicados --------------------------------------------------------
        public void eliminar_RegistroDuplicado()
        {
            userDao.eliminar_RegistroDuplicado();
        }
        //Reportes Personalizados
        public DataTable generarReporte(string consulta)
        {
            return userDao.generarReporte(consulta);

        }

        public bool ValidarCrudoAlmacenFinal(int idPedido, string idHilo, string idColor)
        {
            return userDao.ValidarCrudoAlmacenFinal(idPedido,idHilo,idColor);
        }

        public void editarTablas(string consulta)
        {
            userDao.editarTablas(consulta);
        }
    }

}
