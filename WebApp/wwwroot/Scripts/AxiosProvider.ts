
namespace App.AxiosProvider   {

    export const GuardarContacto = (entity) => axios.post<DBEntity>("Contacto/Edit", entity).then(({data})=>data );


}




