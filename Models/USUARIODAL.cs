using System.Collections.Generic;
using System.Data;
using System;
using System.Data.SqlClient;

namespace HelpHub.Models
{
    public class USUARIODAL : IUSUARIODAL
    {
        string connectionString = @"Data Source= DESKTOP-L92A5M8;Initial Catalog= DBHelpHub;Integrated Security=True;";

        public void AddUSUARIO(USUARIO user)
        {


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = @"PR_INS_USUARIO";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PK_USUARIO",               user.PK_USUARIO                    ); 
                cmd.Parameters.AddWithValue("@NOME",                     user.NOME                          );
                cmd.Parameters.AddWithValue("@EMAIL",                    user.EMAIL                         );
                cmd.Parameters.AddWithValue("@SENHA",                    user.SENHA                         );
                cmd.Parameters.AddWithValue("@TIPO_USUARIO",             user.TIPO_USUARIO                  );
                cmd.Parameters.AddWithValue("@DT_ULTIMO_LOGIN",          user.DT_ULTIMO_LOGIN               );
                cmd.Parameters.AddWithValue("@QTDE_PERGUNTAS_ENV",       user.QTDE_PERGUNTAS_ENV            );
                cmd.Parameters.AddWithValue("@QTDE_RESPOSTAS",           user.QTDE_RESPOSTAS                );
                cmd.Parameters.AddWithValue("@CONTA_ENCERRADA",          user.CONTA_ENCERRADA               );
                cmd.Parameters.AddWithValue("@FK_ID_USUARIO_DEPARMENTO", user.FK_ID_USUARIO_DEPARTAMENTO    );
                cmd.Parameters.AddWithValue("@FK_USUARIO_DEPARTAMENTO",  user.FK_USUARIO_DEPARTAMENTO       );

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public IEnumerable<USUARIO> GetUSUARIOs()
        {
            List<USUARIO> lstUSUARIO = new List<USUARIO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_SEL_USUARIO", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    USUARIO usuario = new USUARIO();

                    usuario.ID = Convert.ToInt32(sdr["ID"]);
                    usuario.PK_USUARIO = Convert.ToInt32(sdr["PK_USUARIO"]);
                    usuario.NOME  = sdr["NOME"].ToString();
                    usuario.EMAIL = sdr["EMAIL"].ToString();
                    usuario.SENHA = sdr["SENHA"].ToString();
                    usuario.TIPO_USUARIO = Convert.ToInt16(sdr["TIPO_USUARIO"]);
                    usuario.DT_ULTIMO_LOGIN   = Convert.ToDateTime(sdr["DT_ULTIMO_LOGIN"]);
                    usuario.QTDE_PERGUNTAS_ENV = Convert.ToInt32(sdr["QTDE_PERGUNTAS_ENV"]);
                    usuario.CONTA_ENCERRADA = Convert.ToInt16(sdr["CONTA_ENCERRADA"]);
                    usuario.QTDE_RESPOSTAS = Convert.ToInt32(sdr["QTDE_RESPOSTAS"]);                
                    usuario.FK_ID_USUARIO_DEPARTAMENTO = Convert.ToInt32(sdr["FK_ID_USUARIO_DEPARMENTO"]);
                    usuario.FK_USUARIO_DEPARTAMENTO = Convert.ToInt32(sdr["FK_USUARIO_DEPARTAMENTO"]);


                    lstUSUARIO.Add(usuario);
                }
                con.Close();
            }
            return lstUSUARIO;
        }


    }
}
