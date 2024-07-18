using System.Collections.Generic;

namespace HelpHub.Models
{
    public interface IREQUESTRESPONSEDAL
    {

        void AddREQUESTRESPONSE(REQUESTRESPONSE requestResponse);
        IEnumerable<SOLICITACAO> GetRequests();

        IEnumerable<REQUESTRESPONSE> GetRequestsByID(int? ID);
    }


}
