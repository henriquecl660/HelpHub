using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Nest;

namespace HelpHub.Models
{
    public class SOLICITACAODAL : ISOLICITACAODAL
    {

        string connectionString = @"Data Source= DESKTOP-L92A5M8;Initial Catalog= DBHelpHub;Integrated Security=True;";

        public void AddSOLICITACAO(SOLICITACAO soli)
        {


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = @"PR_INS_SOLICITACAO";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PK_SOLICITACAO", soli.PK_SOLICITACAO);
                cmd.Parameters.AddWithValue("@TITULO", soli.TITULO);
                cmd.Parameters.AddWithValue("@DT_CRIACAO", soli.DT_CRIACAO);
                cmd.Parameters.AddWithValue("@PERGUNTA", soli.PERGUNTA);
                cmd.Parameters.AddWithValue("@DESCRICAO", soli.DESCRICAO);
                cmd.Parameters.AddWithValue("@QTE_CURTIDAS", soli.QTD_CURTIDAS);
                cmd.Parameters.AddWithValue("@FK_ID_SOLICITACAO_USUARIO", soli.FK_ID_SOLICITACAO_USUARIO);
                cmd.Parameters.AddWithValue("@FK_SOLICITACAO_USUARIO", soli.FK_SOLICITACAO_USUARIO);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }


    }
}
