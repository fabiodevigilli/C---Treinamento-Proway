using System;

namespace Demo_Asserts
{
    public class DatasEspeciaisStore
    {
        /* Retorna uma determinada data especial*/
        public DateTime Data(DatasEspeciais datasEspeciais)
        {
            switch (datasEspeciais)
            {
                case DatasEspeciais.AnoNovo:
                    // 01/01/2017 00:00:00:000
                    return new DateTime(2017, 1, 1, 0, 0, 0, 0);
                //case DatasEspeciais.Natal:
                //    return new DateTime(2017, 12, 25, 0, 0, 0, 0);
                default:
                    throw new ArgumentOutOfRangeException("datasEspeciais");
            }
        }
    }
}
