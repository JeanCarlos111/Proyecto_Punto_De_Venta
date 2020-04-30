using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.ENTITIES;

namespace BackEnd.DAL.Bitacora
{
    public interface IBitacoraDAL : IDisposable
    {

        void AddBitacora(BackEnd.ENTITIES.Bitacora bitacora);
        void UpdateBitacora(BackEnd.ENTITIES.Bitacora bitacora);
        void DeleteBitacora(int id_Bitacora);

        BackEnd.ENTITIES.Bitacora GetBitacora(int id_Bitacora);
        List<BackEnd.ENTITIES.Bitacora> GetBitacoras();
        List<BackEnd.ENTITIES.Bitacora> GetBitacoraPorFecha(String fecha);
    }
}
