using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BD;

namespace WBL
{
    public interface IContactoService
    {
        Task<DBEntity> CREATE(ContactoEntity entity);
        Task<DBEntity> DELETE(ContactoEntity entity);
        Task<IEnumerable<ContactoEntity>> GET();
        Task<ContactoEntity> GETBYID(ContactoEntity entity);
        Task<DBEntity> UPDATE(ContactoEntity entity);
    }

    public class ContactoService : IContactoService
    {
        private readonly IDataAccess sql;

        public ContactoService(IDataAccess _sql)
        {
            sql = _sql;
        }
        #region MetodosCRUD

        //Metodo Get
        public async Task<IEnumerable<ContactoEntity>> GET()
        {
            try
            {
                var result = sql.QueryAsync<ContactoEntity, ProveedorEntity>("dbo.ContactoObtener", "IdContacto,IdProveedor");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //MetodoGetById
        public async Task<ContactoEntity> GETBYID(ContactoEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ContactoEntity>("dbo.ProveedorObtener", new { entity.IdProveedor });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }

        //Metodo Create
        public async Task<DBEntity> CREATE(ContactoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ProveedorInsertar", new
                {
                    entity.Identificacion,
                    entity.Nombre,
                    entity.PrimerApellido,
                    entity.SegundoApellido
                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Metodo Update
        public async Task<DBEntity> UPDATE(ContactoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ContactoActualizar", new
                {
                    entity.IdProveedor,
                    entity.Identificacion,
                    entity.Nombre,
                    entity.PrimerApellido,
                    entity.SegundoApellido

                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Metodo Delete
        public async Task<DBEntity> DELETE(ContactoEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("dbo.ProveedorEliminar", new
                {
                    entity.IdProveedor

                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}
