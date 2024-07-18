using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;
using Nest;
using System.Collections;

namespace HelpHub.Models
{
    public class REQUESTRESPONSEDAL : IREQUESTRESPONSEDAL
    {

        string connectionString = @"Data Source= DESKTOP-L92A5M8;Initial Catalog= DBHelpHub;Integrated Security=True;";

        public REQUESTRESPONSEDAL()
        {
        }

        public void AddREQUESTRESPONSE(REQUESTRESPONSE resp)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = @"PR_INS_RESPOSTA";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@ID", resp.ID);

                cmd.Parameters.AddWithValue("@PK_RESPOSTA", resp.PK_RESPOSTA);

                cmd.Parameters.AddWithValue("@DESCRICAO", resp.DESCRICAO);

                cmd.Parameters.AddWithValue("@FK_ID_RESPOSTA_SOLICITACAO", resp.FK_RESPOSTA_SOLICITACAO);

                cmd.Parameters.AddWithValue("@FK_RESPOSTA_SOLICITACAO", resp.FK_RESPOSTA_SOLICITACAO);

                cmd.Parameters.AddWithValue("@ID_USUARIO_RESPOSTA", resp.ID_USUARIO_RESPOSTA);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        public IEnumerable<SOLICITACAO> GetRequests()
        {
            List<SOLICITACAO> lstSOLICITACAO = new List<SOLICITACAO>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_SEL_SOLICITACAO", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    SOLICITACAO soli = new SOLICITACAO();

                    soli.ID = Convert.ToInt32(sdr["ID"]);
                    soli.PK_SOLICITACAO = Convert.ToInt32(sdr["PK_SOLICITACAO"]);
                    soli.TITULO= sdr["TITULO"].ToString();
                    soli.DT_CRIACAO = Convert.ToDateTime(sdr["DT_CRIACAO"]);
                    soli.PERGUNTA = sdr["PERGUNTA"].ToString();
                    soli.DESCRICAO = sdr["DESCRICAO"].ToString();
                    soli.QTD_CURTIDAS = Convert.ToInt32(sdr["QTE_CURTIDAS"]);
                    soli.FK_ID_SOLICITACAO_USUARIO = Convert.ToInt32(sdr["FK_ID_SOLICITACAO_USUARIO"]);
                    soli.FK_SOLICITACAO_USUARIO = Convert.ToInt32(sdr["FK_SOLICITACAO_USUARIO"]);

                    lstSOLICITACAO.Add(soli);
                }
                con.Close();
            }
            return lstSOLICITACAO;
        }


        public IEnumerable<REQUESTRESPONSE> GetRequestsByID(int? ID_SOLICITACAO)
        {
             List<REQUESTRESPONSE> lstREQUESTRESPONSE = new List<REQUESTRESPONSE>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_SEL_RESPOSTA", con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_SOLICITACAO", ID_SOLICITACAO);


                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {

                    REQUESTRESPONSE resp = new REQUESTRESPONSE();

                    resp.ID = Convert.ToInt32(sdr["ID"]);
                    resp.PK_RESPOSTA = Convert.ToInt32(sdr["PK_RESPOSTA"]);
                    resp.DESCRICAO = sdr["DESCRICAO"].ToString();
                    resp.FK_ID_RESPOSTA_SOLICITACAO = Convert.ToInt32(sdr["FK_ID_RESPOSTA_SOLICITACAO"]);
                    resp.FK_RESPOSTA_SOLICITACAO = Convert.ToInt32(sdr["FK_RESPOSTA_SOLICITACAO"]);
                    resp.ID_USUARIO_RESPOSTA = Convert.ToInt32(sdr["ID_USUARIO_RESPOSTA"]);

                    lstREQUESTRESPONSE.Add(resp);

                }
                con.Close();
            }
            return lstREQUESTRESPONSE;
        }



    }
}
