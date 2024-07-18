using System.Collections.Generic;

namespace HelpHub.Models
{
    public interface IUSUARIODAL
    {
        IEnumerable<USUARIO> GetUSUARIOs();

        void AddUSUARIO(USUARIO usuario);
    }

             

}
