using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ExemploCRUDE
{
    public class BancoDados
    {
        SqlConnection cn;
        SqlCommand comandos;
        SqlDataReader rd;
        //
            /// <summary>
            /// Adiciona linha a Categorias.  
            /// </summary>
            /// <param name="cat">Categoria a ser adicionada.  </param>
            /// <returns>true se executado com êxito.</returns>
        public bool AddCategoria(Categoria cat)
        {
            bool rs = false;
            try
            {
                cn = new SqlConnection(); //criar conexão
                cn.ConnectionString = @"Data Source = .\sqlexpress; Initial Catalog = Papelaria; 
                                        User ID = sa; Password = senai@123;"; //estabelecer conexão com o banco de dados Papelaria
                cn.Open();
                comandos = new SqlCommand(); //criar comandos
                comandos.Connection = cn; //onde os comandos devem ser executados: conexão cn
                comandos.CommandType = CommandType.Text; //indicar o tipo de comando como texto
                comandos.CommandText = "INSERT INTO Categorias(titulo) VALUES(@t)"; //comando a ser executado com valor do parâmetro @t indicado a seguir
                comandos.Parameters.AddWithValue("@t", cat.titulo);

                int r = comandos.ExecuteNonQuery(); /*execução dos comandos acima e retorna um valor referente ao total de linhas afetadas
                                                        caso o valor retorne como 0, significa que houve erro*/
                if(r > 0)
                
                    rs = true;
                    Console.WriteLine("Categoria adicionada com sucesso!");
                
                comandos.Parameters.Clear(); //limpar os parâmetros utilizados para a próxima execução
            }
            catch(SqlException sqlex)
            {
                throw new Exception("Erro ao tentar cadastrar categoria: " + sqlex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                cn.Close(); //fechar o banco antes de terminar a execução
            }
            return rs;
        }
        //
            /// <summary>
            /// Atualização de parâmetros em Categorias.  
            /// </summary>
            /// <param name="cat">Categoria a ser atualizada.  </param>
            /// <returns>true se executado com êxito</returns>
        public bool UpdCategoria(Categoria cat)
        {
            bool rs = false;
            try
            {
                cn = new SqlConnection(); //criar conexão
                cn.ConnectionString = @"Data Source = .\sqlexpress; Initial Catalog = Papelaria; 
                                        User ID = sa; Password = senai@123;"; //estabelecer conexão com o banco de dados Papelaria
                cn.Open();
                comandos = new SqlCommand(); //criar comandos
                comandos.Connection = cn; //onde os comandos devem ser executados: conexão cn
                comandos.CommandType = CommandType.Text; //indicar o tipo de comando como texto
                comandos.CommandText = "UPDATE Categorias SET titulo = @t WHERE idCategoria = @i"; //comando a ser executado com valor do parâmetro @t e @id indicados a seguir
                comandos.Parameters.AddWithValue("@t", cat.titulo);
                comandos.Parameters.AddWithValue("@i", cat.idcategoria);

                int r = comandos.ExecuteNonQuery(); /*execução dos comandos acima e retorna um valor referente ao total de linhas afetadas
                                                        caso o valor retorne como 0, significa que houve erro*/
                if(r > 0)
                    {rs = true;}
                
                comandos.Parameters.Clear(); //limpar os parâmetros utilizados para a próxima execução
            }
            catch(SqlException sqlex)
            {
                throw new Exception("Erro ao tentar atualizar categoria: " + sqlex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                cn.Close(); //fechar o banco antes de terminar a execução
            }
            return rs;
        }
        //
            /// <summary>
            /// Exclui linha de Categorias.  
            /// </summary>
            /// <param name="cat">Categoria a ser excluída.  </param>
            /// <returns>true se executado com êxito.</returns>
        public bool DelCategoria(Categoria cat)
        {
            bool rs = false;
            try
            {
                cn = new SqlConnection(); //criar conexão
                cn.ConnectionString = @"Data Source = .\sqlexpress; Initial Catalog = Papelaria; 
                                        User ID = sa; Password = senai@123;"; //estabelecer conexão com o banco de dados Papelaria
                cn.Open();
                comandos = new SqlCommand(); //criar comandos
                comandos.Connection = cn; //onde os comandos devem ser executados: conexão cn
                comandos.CommandType = CommandType.Text; //indicar o tipo de comando como texto
                comandos.CommandText = "DELETE FROM Categorias WHERE idCategoria = @i"; //comando a ser executado com valor do parâmetro @t indicado a seguir
                comandos.Parameters.AddWithValue("@i", cat.idcategoria);

                int r = comandos.ExecuteNonQuery(); /*execução dos comandos acima e retorna um valor referente ao total de linhas afetadas
                                                        caso o valor retorne como 0, significa que houve erro*/
                if(r > 0)
                    {rs = true;}
                
                comandos.Parameters.Clear(); //limpar os parâmetros utilizados para a próxima execução
            }
            catch(SqlException sqlex)
            {
                throw new Exception("Erro ao tentar excluir categoria: " + sqlex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                cn.Close(); //fechar o banco antes de terminar a execução
            }
            return rs;
        }
        public List<Categoria> SelCategoria(int id)
        {
            var lista = new List<Categoria>();
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress; Initial Catalog = Papelaria; 
                                        User ID = sa; Password = senai@123;";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "SELECT * FROM Categorias where idCategoria= @i";
                comandos.Parameters.AddWithValue("@i", id);
                rd = comandos.ExecuteReader();

                while(rd.Read())
                {
                    lista.Add(new Categoria{
                                            idcategoria=rd.GetInt32(0),
                                            titulo=rd.GetString(1)
                                            });
                }
            comandos.Parameters.Clear();    
            }
            catch(SqlException sqlex)
            {
                throw new Exception("Erro ao tentar ler: " + sqlex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                rd.Close();
            }
            return lista;
        }

         public List<Categoria> SelCategoria(string titulo)
        {
            var lista = new List<Categoria>();
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = @"Data Source = .\sqlexpress; Initial Catalog = Papelaria; 
                                        User ID = sa; Password = senai@123;";
                cn.Open();
                comandos = new SqlCommand();
                comandos.Connection = cn;
                comandos.CommandType = CommandType.Text;
                comandos.CommandText = "SELECT * FROM Categorias where titulo like @i";
                comandos.Parameters.AddWithValue("@i", titulo);
                rd = comandos.ExecuteReader();

                while(rd.Read())
                {
                    lista.Add(new Categoria{
                                            idcategoria=rd.GetInt32(0),
                                            titulo=rd.GetString(1)
                                            });
                }
            comandos.Parameters.Clear();    
            }
            catch(SqlException sqlex)
            {
                throw new Exception("Erro ao tentar ler: " + sqlex.Message);
            }
            catch(Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
            finally
            {
                rd.Close();
            }
            return lista;
        }
    }
}