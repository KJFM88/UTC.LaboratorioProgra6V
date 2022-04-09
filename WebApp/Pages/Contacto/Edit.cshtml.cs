using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;
using Entity;

namespace WebApp.Pages.Contacto
{
    public class EditModel : PageModel
    {
        private readonly IContactoService contacto;
        private readonly IProveedorService proveedor;

        public EditModel(IContactoService contacto, IProveedorService proveedor)
        {
            this.contacto = contacto;
            this.proveedor = proveedor;
        }

        [BindProperty(SupportsGet = true)] //para que no se filtre los ids en los url y evitar robo
        public int? id { get; set; }  //el signo es par que el campo permita nulos en el caso que se vaya a hacer un insert

        [BindProperty] //protege todo
        public ContactoEntity Entity { get; set; } = new ContactoEntity(); //prop para guardar los datos de la entidad
        public IEnumerable<ProveedorEntity> ProveedorLista { get; set; } = new List<ProveedorEntity>();
        //metodo edit
        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await contacto.GETBYID(new()
                    {
                        IdContacto = id
                    });

                }

                ProveedorLista = await proveedor.GETLISTA();

                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        //metodo update insert
        public async Task<IActionResult>OnPost()
        {
            try
            {
                var result = new DBEntity();
                //update
                if (Entity.IdContacto.HasValue) //si el idContacto tiene un valor (true) el metodo actuliza
                {
                     result = await contacto.UPDATE(Entity);

               

                }
                else //Si el idContacto no tiene valor (false) el metodo inserta
                {
                     result = await contacto.CREATE(Entity);

             
                }

                return new JsonResult(result); 
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError= ex.HResult, MsgError= ex.Message });
            }
        }



    }
}
