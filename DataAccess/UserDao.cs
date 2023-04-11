using System;
using System.Collections.Generic;
using System.Text;
using Commun.Cache;
using System.Data;
using System.Data.SqlClient;
using Commun;
namespace DataAccess
{
    public class UserDao:ConnectionToSql
    {
       ConnectionToSql conexion = new ConnectionToSql();
        public bool Login(string user, string pass)
        {
            using (var connection = GetConnection())
            {
                 connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select *from Usuarios2 where Usuario=@user and Contraseña COLLATE Latin1_General_CS_AS =@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            UserLoginCache.FirstName = reader.GetString(1);
                            UserLoginCache.LastName = reader.GetString(2);
                            UserLoginCache.Position = reader.GetString(5);
                            UserLoginCache.Area = reader.GetString(6);
                            UserLoginCache.Id = reader.GetInt32(0);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public DataTable MostrarUsuarios()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select IdUsuario,Nombre,Apellido,Usuario,Cargo,Area,CorreoE from Usuarios2";
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        public DataTable MostrarPedidos()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select *from Pedidos order by IdPrimario desc";
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public DataTable MostrarCatalgoHilos()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "select IDHilo,Hilo,Titulo from Hilos group by IDHilo,Hilo,Titulo";
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public DataTable MostrarCatalgoColores()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select *from Colores";
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public DataTable MostrarCatalgoCajas()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select *from Cajas";
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public DataTable MostrarCatalgoVendedores()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select *from Vendedores";
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public DataTable MostrarCatalgoClientes()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select *from Clientes";
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }


        public DataTable InsertarMasivoPedido(DataTable table)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
                        try
                        {
                            bulkCopy.DestinationTableName ="Pedidos";
                            bulkCopy.WriteToServer(table);
                            transaction.Commit();

                        }
                        catch
                        {
                            transaction.Rollback();
                            connection.Close();
                        }
                }
                return table;
            }
        }

        public void ModificarPedidos( DateTime FechaE, int IDPedido)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Update Pedidos set FechaEntrega=@FechaE where IDPedido='" + IDPedido + "'";
                    command.Parameters.Add("@FechaE", SqlDbType.DateTime).Value = FechaE;
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void ModificarPedidos(string idHilo,string idColor,int idCaja,double pesoPedido,int idPrimario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Update Pedidos set IdHilo=@idHilo,IdColor=@idColor,IdCaja=@idCaja,PesoPedido=@pesoPedido where IdPrimario=@idPrimario";
                    command.Parameters.AddWithValue("@idHilo", idHilo);
                    command.Parameters.AddWithValue("@idColor", idColor);
                    command.Parameters.AddWithValue("@idCaja", idCaja);
                    command.Parameters.AddWithValue("@pesoPedido", pesoPedido);
                    command.Parameters.AddWithValue("@idPrimario", idPrimario);
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void BorrarPedido(int IDPedido)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from Pedidos where IDPedido='"+IDPedido+"'";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void CorregirErrorBulk()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from Pedidos where IdCaja='0'";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void InsertarUsuarios(string Nombre, string Apellido, string Usuario, string Contraseña, string Cargo, string Area,string CorreoE)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into Usuarios2 values ('" + Nombre + "','" + Apellido + "','" + Usuario + "','" + Contraseña + "','" + Cargo + "','" + Area + "','" + CorreoE + "')";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void ModificarUsuarios(string Nombre, string Apellido, string Usuario, string Contraseña, string Cargo, string Area, string CorreoE,int IDUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Update Usuarios2 set Nombre='"+Nombre+"', Apellido='"+ Apellido + "', Usuario='" + Usuario + "', Contraseña='" + Contraseña + "',Cargo='" + Cargo + "', Area='" + Area + "',CorreoE='" + CorreoE + "' where IdUsuario="+IDUsuario+"";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void BorrarUsuario(int IdUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from Usuarios2 where IdUsuario='"+IdUsuario+"'";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void InsertarClientes( string RazaonSocial, string Calle, string Ciudad, string Edo, string RFC, string Etiqueta,int Caja, string Plaza, string Contacto)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Insert into Clientes values ('" + RazaonSocial + "','" + Calle + "','" + Ciudad + "','" + Edo + "','" + RFC + "','" + Etiqueta + "','" + Caja + "','" + Plaza + "','" + Contacto + "')";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void ModificarClientes(string RazaonSocial, string Calle, string Ciudad, string Edo, string RFC, string Etiqueta,int Caja, string Plaza, string Contacto,int IdCliente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Update Clientes set RazonSocial='" + RazaonSocial + "', Calle='" + Calle + "', Ciudad='" + Ciudad + "', Edo='" + Edo + "',RFC='" + RFC + "', Numero='" + Etiqueta + "',Caja='" + Caja + "',Plaza='" + Plaza + "',Contacto='" + Contacto + "' where IdCliente=" + IdCliente + "";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void BorrarCliente(int IdCliente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Delete from Clientes where IDCliente='" + IdCliente + "'";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        public DataTable graba_cuenta_usuario(AppCache ent)
        {
            SqlCommand cmd = new SqlCommand("graba_cuenta_usuario", ConnectionToSql.conectate());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdLogeo", ent.IdLogeo);
            cmd.Parameters.AddWithValue("@Idadmin_usuario", ent.Idadmin_usuario1);
            cmd.Parameters.AddWithValue("@nombre", ent.Nombre);
            cmd.Parameters.AddWithValue("@contraseña", ent.Password);
            cmd.Parameters.AddWithValue("@usuario_administrador", ent.Booleano);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            return tbl;
        }
        //----------actualizar_cuenta_usuario
        public DataTable actualizar_cuenta_usuario(AppCache ent)
        {
            SqlCommand cmd = new SqlCommand("actualizar_cuenta_usuario", ConnectionToSql.conectate());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdLogeo", ent.IdLogeo);
            cmd.Parameters.AddWithValue("@Idadmin_usuario", ent.Idadmin_usuario1);
            cmd.Parameters.AddWithValue("@nombre", ent.Nombre);
            cmd.Parameters.AddWithValue("@contraseña", ent.Password);
            cmd.Parameters.AddWithValue("@usuario_administrador", ent.Booleano);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            return tbl;
        }
        public DataTable graba_admin_usuario(AppCache ent)
        {
            SqlCommand cmd = new SqlCommand("graba_admin_usuario", ConnectionToSql.conectate());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Idadmin_usuario", ent.Idadmin_usuario1);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            return tbl;
        }

            //Ver Ver_admin_usuario----------------------------------------------------------------
            public DataTable Ver_admin_usuario()
        {
            SqlDataAdapter data = new SqlDataAdapter("Ver_admin_usuario", ConnectionToSql.conectate());
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            return tbl;
        }
        //Ver ver_datos_logueo----------------------------------------------------------------
        public DataTable ver_datos_logueo()
        {
            SqlDataAdapter data = new SqlDataAdapter("ver_datos_logueo", ConnectionToSql.conectate());
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            return tbl;
        }
        //Ver Ver_admin_usuario----------------------------------------------------------------
        public DataTable Mostrar_admin_usuario()
        {
            SqlDataAdapter data = new SqlDataAdapter("Mostrar_admin_usuario", ConnectionToSql.conectate());
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            return tbl;
        }
        //Ver Ver_Cod_login----------------------------------------------------------------
        public DataTable Ver_Cod_login()
        {
            SqlDataAdapter data = new SqlDataAdapter("Ver_Cod_login", ConnectionToSql.conectate());
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            return tbl;
        }
        //Ver Ver_Cod_Admin----------------------------------------------------------------
        public DataTable Ver_Cod_Admin()
        {
            SqlDataAdapter data = new SqlDataAdapter("Ver_Cod_Admin", ConnectionToSql.conectate());
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            return tbl;
        }

        //Consultar Contraseña--------------------------------------------------------------

        public DataTable Consultar_Contraseña(string usuario)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Recuperar_Contra";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        //Mostrar Administradores-----------------------------------------------------------
        public DataTable Mostrar_Administradores()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Mostrar_Admin";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        //Mostrar Administradores-----------------------------------------------------------
        public DataTable Mostrar_Usuarios()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Mostrar_Usuario";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        //GuardarAdmin--------------------------------------------------------------------------
            public DataTable graba_administrador(AppCache ent)
        {
            SqlCommand cmd = new SqlCommand("graba_administrador", ConnectionToSql.conectate());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdAministrador", ent.IdAdmin);
            cmd.Parameters.AddWithValue("@Idadmin_usuario", ent.Idadmin_usuario1);
            cmd.Parameters.AddWithValue("@estado", ent.Booleano);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            return tbl;
        }
        //GuardarUsuario--------------------------------------------------------------------------
        public DataTable graba_usuarios(AppCache ent)
        {
            SqlCommand cmd = new SqlCommand("graba_usuarios", ConnectionToSql.conectate());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdUsuario", ent.IdUsuario);
            cmd.Parameters.AddWithValue("@Idadmin_usuario", ent.Idadmin_usuario1);
            cmd.Parameters.AddWithValue("@estado", ent.Booleano);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            data.Fill(tbl);
            return tbl;
        }
        //Eliminar Admin---------------------------------------------------------------------------
        public void Eliminar_Admin(string idAdmin)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "eliminar_administrador";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdAdministrador", idAdmin);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        //Eliminar Usuario---------------------------------------------------------------------------
        public void Eliminar_Usuario(string idUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "eliminar_usuarios";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        //Mostrar Cod_Admin
        public DataTable Mostrar_Cod_Admin()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Ver_Cod_Admin";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        //Mostrar Cod_Admin
        public DataTable Mostrar_Cod_Usuario()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Ver_Cod_Usuario";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //----------------------------------------Módulo Materia Prima ----------------------------------------------------------------

        //Mostrar Cátalogo MP
        public DataTable MostrarCatalogoMP()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarCatalogoMP";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        public DataTable MostrarCatalogoMP2()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarCatalogoMP2";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Entradas MP
        public DataTable MostrarEntradasMP()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ver_EntradasMP";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Insertar Entradas MP
        public void InsertarEntradas(string IdProducto,string Producto,double Peso, double Costo,int proveedor)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarAlmacenMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdProducto",IdProducto);
                    command.Parameters.AddWithValue("@Producto", Producto);
                    command.Parameters.AddWithValue("@Peso", Peso);
                    command.Parameters.AddWithValue("@Costo", Costo);
                    command.Parameters.AddWithValue("@Proveedor", proveedor);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Mostrar Material ExistenteMP
        public DataTable MostrarMaterialExistenteMP(string Producto)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarMaterialExistenteMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Producto", Producto);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Insertar Salidas MP
        public void InsertarSalidasMP(string IdProducto, string Producto, double Peso, double Costo,int proveedor)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarSalidaAlmacenMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdProducto", IdProducto);
                    command.Parameters.AddWithValue("@Producto", Producto);
                    command.Parameters.AddWithValue("@Peso", Peso);
                    command.Parameters.AddWithValue("@Costo", Costo);
                    command.Parameters.AddWithValue("@Proveedor", proveedor);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Mostrar Salidas MP
        public DataTable MostrarSalidasMP()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ver_SalidasMP";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Eliminar Moviemto MP
        public void EliminarMovimientoMP(int ID)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarMovimientoMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", ID);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //----------------------------------------Módulo Hilatura----------------------------------------------------------------

        //Mostrar Detalles Entradas Hilatura
        public DataTable MostrarEntradasH()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarMaterialExistenteConfigH";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Detalles Salidas Hilatura
        public DataTable MostrarSalidasH()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarEHilatura";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        // Mostrar Material Existente Hilatura
        public DataTable MostrarMaterialHilatura(string producto)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarMaterialHilatura";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DescProducto", producto);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Insertar Entradas Hilatura MP
        public void InsertarEntradasHilaturaMP(string IdProducto, string Producto, double Peso, double Costo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarEntradasHilaturaMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdProducto", IdProducto);
                    command.Parameters.AddWithValue("@Producto", Producto);
                    command.Parameters.AddWithValue("@Peso", Peso);
                    command.Parameters.AddWithValue("@Costo", Costo);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Insertar Componentes Hilatura MP
        public void InsertarComponentesHilatura(string IdProducto, string Producto, double Peso, double Costo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarComponentesHilatura";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdProducto", IdProducto);
                    command.Parameters.AddWithValue("@Producto", Producto);
                    command.Parameters.AddWithValue("@Peso", Peso);
                    command.Parameters.AddWithValue("@Costo", Costo);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }


        //Insertar Salidas Hilatura Bolsa
        public void InsertarSalidasH(int IdBolsa, string IdHilo, int LoteHilatura,int IdCaja,double PesoBruto, double PesoNeto,int NumConos, int StatusProceso,string Malla,string ColorCono,string Notas)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarEntradasH";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@LoteHilatura", LoteHilatura);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.Parameters.AddWithValue("@Malla", Malla);
                    command.Parameters.AddWithValue("@ColorCono", ColorCono);
                    command.Parameters.AddWithValue("@Notas", Notas);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Insertar Salidas Hilatura Reporte Bolsa
        public void InsertarSalidasHReporte(int IdBolsa, string IdHilo, int LoteHilatura, int IdCaja, double PesoBruto, double PesoNeto, int NumConos, int StatusProceso, string Malla, string ColorCono, string Notas)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarEntradasHReporte";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@LoteHilatura", LoteHilatura);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.Parameters.AddWithValue("@Malla", Malla);
                    command.Parameters.AddWithValue("@ColorCono", ColorCono);
                    command.Parameters.AddWithValue("@Notas", Notas);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void InsertarSalidasH(int IdBolsa,int idPedido, string IdHilo, string idColor,int LoteHilatura,int LoteT, int IdCaja, double PesoBruto, double PesoNeto, int NumConos, int StatusProceso, string Malla, string ColorCono,string Notas)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarEntradasH2";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@idPedido", idPedido);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@idColor", idColor);
                    command.Parameters.AddWithValue("@LoteHilatura", LoteHilatura);
                    command.Parameters.AddWithValue("@LoteT", LoteT);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.Parameters.AddWithValue("@Malla", Malla);
                    command.Parameters.AddWithValue("@ColorCono", ColorCono);
                    command.Parameters.AddWithValue("@Notas", Notas);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Insertar Salidas Hilatura Reporte Bolsa
        public void InsertarSalidasHReporte(int IdBolsa, int idPedido,string IdHilo,string idColor, int LoteHilatura, int LoteT, int IdCaja, double PesoBruto, double PesoNeto, int NumConos, int StatusProceso, string Malla, string ColorCono,string Notas)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarEntradasHReporte2";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@idPedido", idPedido);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@idColor", idColor);
                    command.Parameters.AddWithValue("@LoteHilatura", LoteHilatura);
                    command.Parameters.AddWithValue("@LoteT", LoteT);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.Parameters.AddWithValue("@Malla", Malla);
                    command.Parameters.AddWithValue("@ColorCono", ColorCono);
                    command.Parameters.AddWithValue("@Notas", Notas);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        //Mostrar Id Siguiente Bolsa
        public DataTable MostrarIdBolsa()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarIdBolsa";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Calcular Peso Componente
        public DataTable CalcularPesoComponente(string IdHilo,double PesoNeto)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CalcularPesoComponente";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDHilo",IdHilo);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Salida Config Hilatura Bolsa
        public DataTable MostrarEHilatura(int IdBolsa)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarEHilatura";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Eliminar Salida Config Hilatura  Bolsa
        public void EliminarEHilatura(int IdBolsa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarEHilatura";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Eliminar Salida Config Hilatura Reporte Bolsa
        public void EliminarEHilaturaReporte(int IdBolsa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarEHilaturaReporte";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Eliminar EntradaMP
        public void EliminarEntradaMP(int IdProducto,string Producto,double Peso, double Costo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarEntradaMP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdProducto", IdProducto);
                    command.Parameters.AddWithValue("@Producto", Producto);
                    command.Parameters.AddWithValue("@Peso", Peso);
                    command.Parameters.AddWithValue("@Costo", Costo);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public bool GuardarInfoBolsaConfigH(int IdBolsa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ObtenerInformacionBolsa";
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AppCache.IdBolsa = reader.GetInt32(0);
                            AppCache.FechaRegistro = reader.GetDateTime(1);
                            AppCache.IdHilo = reader.GetString(3);
                            AppCache.Hilo = reader.GetString(4);
                            AppCache.LoteHilatura = reader.GetInt32(6);
                            AppCache.IdCaja = reader.GetInt32(7);
                            AppCache.PesoBruto = reader.GetFloat(8);
                            AppCache.PesoNeto = reader.GetFloat(9);
                            AppCache.NumConos = reader.GetInt32(10);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        //----------------------------------------Módulo Almacén Crudo----------------------------------------------------------------

        //Mostrar Datos Bolsa
        public DataTable MostrarDBolsaAC(int IdBolsa,int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarDBolsaAC";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@StatusProceso",StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Datos Entradas
        public DataTable MostrarDEntradasAC()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarDEntradasAC";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Insertar Entradas Almacén Crudo Reporte Bolsa
        public void InsertarEntradaAC(int IdBolsa, string IdHilo, int LoteHilatura, int IdCaja, double PesoBruto, double PesoNeto, int NumConos, int StatusProceso,string Malla, string ColorCono,string Notas)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarEntradasHReporte";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@LoteHilatura", LoteHilatura);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.Parameters.AddWithValue("@Malla", Malla);
                    command.Parameters.AddWithValue("@ColorCono", ColorCono);
                    command.Parameters.AddWithValue("@Notas", Notas);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Actualizar Entradas Almacén Crudo Bolsa
        public void ActualizarStatusBolsa(int IdBolsa,int StatusProceso)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ActualizarStatusBolsa";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Insertar Salidas Allmacen Crudo Reporte Bolsa
        public void InsertarSalidasAC(int IdBolsa,int NumPedido, string IdHilo, int LoteHilatura, int IdCaja, double PesoBruto, double PesoNeto, int NumConos, int StatusProceso, string Malla, string ColorCono)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarSalidasAC";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@NumPedido", NumPedido);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@LoteHilatura", LoteHilatura);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.Parameters.AddWithValue("@Malla", Malla);
                    command.Parameters.AddWithValue("@ColorCono", ColorCono);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Mostrar Datos Salidas
        public DataTable MostrarDSalidasAC()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarDSalidasAC";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Eliminar Movimiento Reporte Bolsa
        public void EliminarMovimientoReporteBolsa(int IdBolsa, int StatusProceso)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarMovimientoReporteBolsa";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //----------------------------------------Módulo Almacén Crudo----------------------------------------------------------------

        //----------------------------------------Módulo Tintoreriía----------------------------------------------------------------


        //Mostrar Datos Entradas
        public DataTable MostrarEntradasT()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarEntradasT";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Agregar Color y Lote Teñido
        public void AgregarDatosT(int IdBolsa,int LoteT, string Color)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "AgregarDatosT";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Color", Color);
                    command.Parameters.AddWithValue("@LoteT", LoteT);
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Insertar Entradas Tintoreria Reporte Bolsa
        public void InsertarEntradasTRB(int IdBolsa,int NumPedido ,string IdHilo,string IdColor, int LoteHilatura,int LoteTenido, int IdCaja, double PesoBruto, double PesoNeto, int NumConos, int StatusProceso, string Malla, string ColorCono)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarEntradasTRB";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@NumPedido", NumPedido);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@IdColor", IdColor);
                    command.Parameters.AddWithValue("@LoteHilatura", LoteHilatura);
                    command.Parameters.AddWithValue("@LoteTenido", LoteTenido);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.Parameters.AddWithValue("@Malla", Malla);
                    command.Parameters.AddWithValue("@ColorCono", ColorCono);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public DataTable MostrarLoteActualT()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarLoteTactual";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }


        //Mostrar Datos Salidas
        public DataTable MostrarSalidasT()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarSalidasT";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Datos Lote
        public DataTable MostrarLoteT(int LoteT)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarLoteT";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LoteT", LoteT);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Datos Bolsa
        public DataTable MostrarBolsaT1(int IdBolsa)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarBolsaT1";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BolsaID", IdBolsa);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Datos Bolsa
        public DataTable MostrarBolsaT(int IdBolsa)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarBolsaT";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BolsaID", IdBolsa);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Cambiar Datos Lote

        public void ActualizarLote(int LoteT)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ActualizarLote";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LoteT", LoteT);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //VALIDAR ENTRADA TINTORERIA
        public bool ValidarEntradaT(int idBolsa,string idColor)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarEntradaTintoreria";
                    command.Parameters.AddWithValue("@idBolsa", idBolsa);
                    command.Parameters.AddWithValue("@idColor", idColor);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        public bool ValidarColorLoteT(int loteT)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarColorLoteT";
                    command.Parameters.AddWithValue("@loteT", loteT);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            AppCache.ActualColorLoteT= reader.GetString(0);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        //----------------------------------------Módulo Tintoreriía----------------------------------------------------------------

        //----------------------------------------Módulo Hilatura Reenconado----------------------------------------------------------------
        //Mostrar Datos Entradas
        public DataTable MostrarEntradasHR()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarEntradasHR";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Insertar Entradas Tintoreria Reporte Bolsa
        public void InsertarEntradasHR(int IdBolsa, string IdHilo, string IdColor, int LoteHilatura, int LoteTenido, int IdCaja, double PesoBruto, double PesoNeto, int NumConos, int StatusProceso, string Malla, string ColorCono)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarEntradasHR";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@IdColor", IdColor);
                    command.Parameters.AddWithValue("@LoteHilatura", LoteHilatura);
                    command.Parameters.AddWithValue("@LoteTenido", LoteTenido);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.Parameters.AddWithValue("@Malla", Malla);
                    command.Parameters.AddWithValue("@ColorCono", ColorCono);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Mostrar Datos Salidas
        public DataTable MostrarSalidasHR()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarSalidasHR";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Datos Entradas Bolsa
        public DataTable MostrarBolsaHR(int IdBolsa)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarBolsaHR";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BolsaID", IdBolsa);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Datos Salidas Bolsa
        public DataTable MostrarBolsaSHR(int IdBolsa)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarBolsaSHR";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BolsaID", IdBolsa);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //----------------------------------------Módulo Hilatura Reenconado----------------------------------------------------------------


        //----------------------------------------Módulo Almacén Final----------------------------------------------------------------
        //Mostrar Datos Entradas
        public DataTable MostrarEntradasAF()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarEntradasAF";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Insertar Entradas AF
        public void InsertarEntradasAF(int IdBolsa,int NumPedido ,string IdHilo, string IdColor, int LoteHilatura, int LoteTenido, int IdCaja, double PesoBruto, double PesoNeto, int NumConos, int StatusProceso, string Malla, string ColorCono)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarEntradasAF";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@NumPedido", NumPedido);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@IdColor", IdColor);
                    command.Parameters.AddWithValue("@LoteHilatura", LoteHilatura);
                    command.Parameters.AddWithValue("@LoteTenido", LoteTenido);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.Parameters.AddWithValue("@Malla", Malla);
                    command.Parameters.AddWithValue("@ColorCono", ColorCono);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Mostrar Datos Salidas
        public DataTable MostrarSalidasAF()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarSalidasAF";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Datos Entradas Bolsa
        public DataTable MostrarBolsaAF(int IdBolsa)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarBolsaAF";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BolsaID", IdBolsa);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Datos Salidas Bolsa
        public DataTable MostrarBolsaSAF(int IdBolsa)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarBolsaSAF";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BolsaID", IdBolsa);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Insertar Salidas AF
        public void InsertarSalidasAF(int IdBolsa, int NumPedido, string IdHilo, string IdColor, int LoteHilatura, int LoteTenido, int IdCaja, double PesoBruto, double PesoNeto, int NumConos, int StatusProceso,int NumRemision, string Malla, string ColorCono)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarSalidasAF";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@NumPedido", NumPedido);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@IdColor", IdColor);
                    command.Parameters.AddWithValue("@LoteHilatura", LoteHilatura);
                    command.Parameters.AddWithValue("@LoteTenido", LoteTenido);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.Parameters.AddWithValue("@NumRemision", NumRemision);
                    command.Parameters.AddWithValue("@Malla", Malla);
                    command.Parameters.AddWithValue("@ColorCono", ColorCono);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        //Mostrar Nuevo Pedido
        public DataTable MostrarNuevoPedido()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarNuevoPedido";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }


        //Mostrar Nuevo Número de Remisión
        public DataTable MostrarNuevoNRemision()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarNuevoNRemision";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }


        //Mostrar Número de Remisión
        public DataTable MostrarNumeroRemision()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarNumeroRemision";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //Mostrar Datos Salidas Bolsa
        public DataTable MostrarBolsaSAF2(int IdBolsa, int NumPedido)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarBolsaSAF2";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BolsaID", IdBolsa);
                    command.Parameters.AddWithValue("@NumPedido", NumPedido);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        public bool ValidarSalidasAF(int idBolsa, int idPedido)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarSalidaAF";
                    command.Parameters.AddWithValue("@idBolsa", idBolsa);
                    command.Parameters.AddWithValue("@idPedido", idPedido);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }



        //----------------------------------------Módulo Almacén Final----------------------------------------------------------------

        //----------------------------------------Módulo Sucursales----------------------------------------------------------------
        public DataTable MostrarBolsaSucursales(int IdBolsa, int statusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarBolsaSucursales";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@BolsaID", IdBolsa);
                    command.Parameters.AddWithValue("@StatusPRoceso", statusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        public DataTable MostrarSucursal( int statusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarSucursal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StatusPRoceso", statusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        public void InsertarEntradaSucursal(int IdBolsa, int NumPedido, string IdHilo, string IdColor, int IdCaja, double PesoBruto, double PesoNeto, int NumConos, int StatusProceso)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarEntradaSucursal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@NumPedido", NumPedido);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@IdColor", IdColor);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public void InsertarSalidaSucursal(int IdBolsa, int NumPedido, string IdHilo, string IdColor, int IdCaja, double PesoBruto, double PesoNeto, int NumConos, int StatusProceso,int NumRemision,double Precio,int idCliente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarSalidaSucursal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@NumPedido", NumPedido);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@IdColor", IdColor);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.Parameters.AddWithValue("@NumRemision", NumRemision);
                    command.Parameters.AddWithValue("@Precio", Precio);
                    command.Parameters.AddWithValue("@idClienteSucursal", idCliente);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void InsertarClienteSucursal(string nombre,Int64 contacto,int plaza,string calle,string edo,string ciudad)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarClienteSucursal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@contacto", contacto);
                    command.Parameters.AddWithValue("@plaza", plaza);
                    command.Parameters.AddWithValue("@calle", calle);
                    command.Parameters.AddWithValue("@edo", edo);
                    command.Parameters.AddWithValue("@ciudad", ciudad);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void EliminarClienteSucursal(int idCliente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarClienteSucursal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void EditarClienteSucursal(string nombre, Int64 contacto, int plaza, string calle, string edo, string ciudad, int idCliente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EditarClienteSucursal";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@contacto", contacto);
                    command.Parameters.AddWithValue("@plaza", plaza);
                    command.Parameters.AddWithValue("@calle", calle);
                    command.Parameters.AddWithValue("@edo", edo);
                    command.Parameters.AddWithValue("@ciudad", ciudad);
                    command.Parameters.AddWithValue("@idCliente", idCliente);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public DataTable MostrarClienteSucursal()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarClienteSucursal";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public void EliminarVenta(int idBolsa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarVenta";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idBolsa", idBolsa);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public DataTable MostrarLoteDeVentaSig()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarLoteDeVentaSig";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }
        //----------------------------------------Módulo Sucursales----------------------------------------------------------------


        //----------------------------------------Configuración Hilos----------------------------------------------------------------
        public DataTable SeleccionarComponentesH(string IDHilo)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SeleccionarComponentesH";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IDHilo", IDHilo);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public DataTable MostrarHilos()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarHilos";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public void InsertarHilo(string IdHilo, string Hilo, string Titulo, double Precio)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarHilo";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@Hilo", Hilo);
                    command.Parameters.AddWithValue("@Titulo", Titulo);
                    command.Parameters.AddWithValue("@Precio", Precio);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void InsertarComponente(string IdHilo, string Hilo, string Titulo, double Porcentaje, string Componente, double Precio)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarComponente";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@Hilo", Hilo);
                    command.Parameters.AddWithValue("@Titulo", Titulo);
                    command.Parameters.AddWithValue("@Porcentaje", Porcentaje);
                    command.Parameters.AddWithValue("@Componente", Componente);
                    command.Parameters.AddWithValue("@Precio", Precio);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        public void ActualizarHilo(string IdHiloG, string IdHilo, string Hilo, string Titulo, double Precio)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ActualizarHilo";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdHiloG", IdHiloG);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@Hilo", Hilo);
                    command.Parameters.AddWithValue("@Titulo", Titulo);
                    command.Parameters.AddWithValue("@Precio", Precio);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        public void ActualizarComponente(string Hilo, string ComponenteG, string Componente, double Porcentaje)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ActualizarComponente";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Hilo", Hilo);
                    command.Parameters.AddWithValue("@ComponenteG", ComponenteG);
                    command.Parameters.AddWithValue("@Componente", Componente);
                    command.Parameters.AddWithValue("@Porcentaje", Porcentaje);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        public void EliminarHilo(string IdHilo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarHilo";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        public void EliminarComponente(string IdHilo, string Componente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarComponente";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@Componente", Componente);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }
        //----------------------------------------Configuración Hilos----------------------------------------------------------------

        //----------------------------------------Configuración Cajas----------------------------------------------------------------

        public void InsertarCaja(string DescCaja, double TaraCono, double TaraBolsa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarCaja";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DescCaja", DescCaja);
                    command.Parameters.AddWithValue("@TaraCono", TaraCono);
                    command.Parameters.AddWithValue("@TaraBolsa", TaraBolsa);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }            
        }

        public void ActualizarCaja(int IdCaja, string DescCaja, double TaraCono, double TaraBolsa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ActualizarCaja";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@DescCaja", DescCaja);
                    command.Parameters.AddWithValue("@TaraCono", TaraCono);
                    command.Parameters.AddWithValue("@TaraBolsa", TaraBolsa);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        public void EliminarCaja(int IdCaja)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarCaja";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }
        //----------------------------------------Configuración Cajas----------------------------------------------------------------

        //----------------------------------------Configuración Colores ----------------------------------------------------------------

        public void InsertarColor(string IdColor, string Color)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarColor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdColor", IdColor);
                    command.Parameters.AddWithValue("@Color", Color);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void ActualizarColor(string IdColorG,string IdColor, string Color)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ActualizarColor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdColorG", IdColorG);
                    command.Parameters.AddWithValue("@IdColor", IdColor);
                    command.Parameters.AddWithValue("@Color", Color);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        public void EliminarColor(string IdColor)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarColor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdColor", IdColor);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        //----------------------------------------Configuración Colores ----------------------------------------------------------------

        //----------------------------------------Configuración Vendedores ----------------------------------------------------------------
        public void InsertarVendedor(int Plaza, string Nombre,string Apellido)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarVendedor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Plaza", Plaza);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Apellido", Apellido);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void ActualizarVendedor(int Plaza, string Nombre, string Apellido,int IdVendedor)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ActualizarVendedor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdVendedor", IdVendedor);
                    command.Parameters.AddWithValue("@Plaza", Plaza);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Apellido", Apellido);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        public void EliminarVendedor(int IdVendedor)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarVendedor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdVendedor", IdVendedor);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }
        //----------------------------------------Configuración Vendedores ----------------------------------------------------------------

        //----------------------------------------Configuración Materia Prima ----------------------------------------------------------------
        public void InsertarMateriaP(string Producto, double Costo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "InsertarMateriaP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Producto", Producto);
                    command.Parameters.AddWithValue("@Costo", Costo);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public void ActualizarMateriaP(int IdProducto, string Producto, double Costo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ActualizarMateriaP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdProducto", IdProducto);
                    command.Parameters.AddWithValue("@Producto", Producto);
                    command.Parameters.AddWithValue("@Costo", Costo);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        public void EliminarMateriaP(int IdProducto)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarMateriaP";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdProducto", IdProducto);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }
        //----------------------------------------Configuración Materia Prima ----------------------------------------------------------------

        //----------------------------------------Configuración Bolsas ----------------------------------------------------------------
        public DataTable MostrarBolsas(int StatusProceso)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarBolsas";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public DataTable MostrarBolsas()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "MostrarBolsas1";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public void ActualizarBolsa(int IdBolsa, int? NumPedido, int StatusProceso, int StatusProcesoG,double PesoBruto, int IdCaja, int NumConos)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ActualizarBolsa";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@NumPedido", NumPedido);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.Parameters.AddWithValue("@StatusProcesoG", StatusProcesoG);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        public void EliminarBolsa(int IdBolsa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarBolsa";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        public bool SeleccionarBolsa(int IdBolsa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SeleccionarBolsa";
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                AppCache.IdHilo = reader.GetString(3);
                                AppCache.LoteHilatura = reader.GetInt32(5);                            
                                AppCache.IdCaja = reader.GetInt32(7);
                                AppCache.PesoBruto = reader.GetFloat(8);
                                AppCache.PesoNeto = reader.GetFloat(9);
                                AppCache.NumConos = reader.GetInt32(10);
                                AppCache.StatusProceso = reader.GetInt32(11);
                                
                            }
                            catch { }
                           
                            try
                            {
                                AppCache.Malla = reader.GetString(14);
                            }
                            catch {
                                AppCache.Malla = "";
                            }
                            try
                            {
                                AppCache.ColorCono = reader.GetString(15);
                            }
                            catch 
                            {
                                AppCache.ColorCono = "";
                            }
                            try
                            {
                                AppCache.IdColor = reader.GetString(4);
                                AppCache.LoteTenido = reader.GetInt32(6);
                            }
                            catch 
                            {
                                AppCache.IdColor = "";
                                AppCache.LoteTenido = 0;
                            }
                            try
                            {
                                AppCache.NumPedidoBolsa = reader.GetInt32(2);
                            }
                            catch 
                            {
                                AppCache.NumPedidoBolsa = 0;
                            }

                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public void CrearNuevaBolsa(int IdBolsa, int NumPedido,string IdHilo,string IdColor,int LoteHilatura, int LoteTenido, int IdCaja, double PesoBruto, double PesoNeto, int NumConos,int StatusProceso,string Malla,string ColorCono)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "CrearNuevaBolsa";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@NumPedido", NumPedido);
                    command.Parameters.AddWithValue("@IdHilo", IdHilo);
                    command.Parameters.AddWithValue("@IdColor", IdColor);
                    command.Parameters.AddWithValue("@LoteHilatura", LoteHilatura);
                    command.Parameters.AddWithValue("@LoteTenido", LoteTenido);
                    command.Parameters.AddWithValue("@IdCaja", IdCaja);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.Parameters.AddWithValue("@Malla", Malla);
                    command.Parameters.AddWithValue("@ColorCono", ColorCono);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        public void ModificarBolsa(int IdBolsa, double PesoBruto, double PesoNeto, int NumConos, int StatusProceso)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ModificarBolsa";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdBolsa", IdBolsa);
                    command.Parameters.AddWithValue("@PesoBruto", PesoBruto);
                    command.Parameters.AddWithValue("@PesoNeto", PesoNeto);
                    command.Parameters.AddWithValue("@NumConos", NumConos);
                    command.Parameters.AddWithValue("@StatusProceso", StatusProceso);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        public DataTable MostrarStatus()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select *from StatusProceso";
                    command.CommandType = CommandType.Text;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        //----------------------------------------Configuración Bolsas ----------------------------------------------------------------

        //----------------------------------------Validaciones ----------------------------------------------------------------

        //---------------------Config Usuarios ----------------------------------------------------------------
        public bool ValidarNombresUsuarios(string nombre, string apellido)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarNombresUsuarios";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public bool ValidarUsuario(string user)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarUsuario";
                    command.Parameters.AddWithValue("@user", user);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public bool ValidarCorreo(string correo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarCorreo";
                    command.Parameters.AddWithValue("@correo", correo);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        //---------------------Config Usuarios ----------------------------------------------------------------

        //---------------------Config Productos ----------------------------------------------------------------
        public bool ValidarIdHilo(string idHilo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarIdHilo";
                    command.Parameters.AddWithValue("@idHilo", idHilo);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public bool ValidarDescHilo(string hilo,string titulo)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarDescHilo";
                    command.Parameters.AddWithValue("@hilo", hilo);
                    command.Parameters.AddWithValue("@titulo", titulo);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public bool ValidarComponenteH(string idHilo,string componente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarComponenteH";
                    command.Parameters.AddWithValue("@idHilo", idHilo);
                    command.Parameters.AddWithValue("@componente", componente);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        public DataTable ValidarComponentesT(string idHilo)
        {
                SqlDataReader leer;
                DataTable table = new DataTable();

                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand())
                    {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "ValidarComponentesT";
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idHilo", idHilo);
                        leer = command.ExecuteReader();
                        table.Load(leer);
                        connection.Close();
                        return table;
                    }
                    catch
                    {
                        connection.Close();
                        return table;
                    }
                    }
                }
        }

        //---------------------Config Productos ----------------------------------------------------------------

        //---------------------Config Cajas ----------------------------------------------------------------
        public bool ValidarDescCaja(string desc)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarDescCaja";
                    command.Parameters.AddWithValue("@desc", desc);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public bool ValidarCarCaja(double taraCono,double taraBolsa)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarCarCaja";
                    command.Parameters.AddWithValue("@taraCono", taraCono);
                    command.Parameters.AddWithValue("@taraBolsa", taraBolsa);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        //---------------------Config Cajas ----------------------------------------------------------------

        //---------------------Config Colores ----------------------------------------------------------------
        public bool ValidarDescColor(string desc)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarDescColor";
                    command.Parameters.AddWithValue("@desc", desc);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public bool ValidarIdColor(string idColor)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarIdColor";
                    command.Parameters.AddWithValue("@idColor", idColor);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        //---------------------Config Colores ----------------------------------------------------------------

        //---------------------Config Clientes ----------------------------------------------------------------
        public bool ValidarRazonSocial(string rSocial)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarRazonSocial";
                    command.Parameters.AddWithValue("@rSocial", rSocial);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }

        public bool ValidarRFC(string rSocial)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarRFC";
                    command.Parameters.AddWithValue("@rfc", rSocial);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        //---------------------Config Clientes ----------------------------------------------------------------

        //---------------------Config Vendedores ----------------------------------------------------------------
        public bool ValidarVendedor(string nombre,string apellido)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarVendedor";
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@apellido", apellido);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        //---------------------Config Vendedores ----------------------------------------------------------------

        //---------------------Config Materia Prima ----------------------------------------------------------------
        public bool ValidarDescMP(string desc)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarDescMP";
                    command.Parameters.AddWithValue("@desc", desc);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        //---------------------Config Materia Prima ----------------------------------------------------------------

        //----------------------------------------Validaciones ----------------------------------------------------------------

        //--------------------- Proveedores --------------------------------------------------------
        public DataTable ver_Proveedores()
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection= GetConnection())
            {              
                connection.Open();
                using(var command= new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ver_Proveedores";
                    command.CommandType = CommandType.StoredProcedure;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public void insertar_Proveedores(string razonSocial,string contacto)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insertar_Proveedores";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@razonSocial", razonSocial);
                    command.Parameters.AddWithValue("@contacto", contacto);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }
        public void actualizar_Proveedores(string razonSocial, string contacto,int idProveedor)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "actualizar_Proveedores";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@razonSocial", razonSocial);
                    command.Parameters.AddWithValue("@contacto", contacto);
                    command.Parameters.AddWithValue("@idProveedor", idProveedor);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }
        public void eliminar_Proveedor( int idProveedor)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "eliminar_Proveedor";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@idProveedor", idProveedor);
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }
        //--------------------- Proveedores --------------------------------------------------------

        //--------------------- Elimiar Registros Duplicados --------------------------------------------------------
        public void eliminar_RegistroDuplicado()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EliminarRegistrosDuplicados";
                    command.CommandType = CommandType.StoredProcedure;
                    command.ExecuteNonQuery();

                }
                connection.Close();
            }
        }

        //--------------------- Elimiar Registros Duplicados --------------------------------------------------------

        //--------------------- Validar Crudo a Almacén Final --------------------------------------------------------

        public bool ValidarCrudoAlmacenFinal(int idPedido,string idHilo,string idColor)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "ValidarCrudoAlmacenFinal";
                    command.Parameters.AddWithValue("@idPedido", idPedido);
                    command.Parameters.AddWithValue("@idHilo", idHilo);
                    command.Parameters.AddWithValue("@idColor", idColor);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
        //--------------------- Validar Crudo a Almacén Final --------------------------------------------------------

        // REPORTES PERSONALIZADOS


        public DataTable generarReporte(string consulta)
        {
            SqlDataReader leer;
            DataTable table = new DataTable();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = consulta;
                    command.CommandType = CommandType.Text;
                    leer = command.ExecuteReader();
                    table.Load(leer);
                    connection.Close();
                    return table;
                }
            }
        }

        public void editarTablas(string consulta)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = consulta;
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                }
            }
        }
    }
}
