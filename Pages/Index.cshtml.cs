using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoApp.Models;
using System.Collections.Generic;

namespace ToDoApp.Pages
{
    public class IndexModel : PageModel
    {
        // Lista de tareas
        public List<Tarea> Tareas { get; set; } = new();

        // Propiedades para edición
        [BindProperty]
        public int EditarId { get; set; }
        [BindProperty]
        public string? EditarDescripcion { get; set; }

        [BindProperty]
        public string? NuevaDescripcion { get; set; }

        // Simulación de almacenamiento en memoria (puedes cambiarlo por persistencia real)
        private static List<Tarea> tareasDb = new();

        public void OnGet()
        {
            Tareas = tareasDb;
        }

        public IActionResult OnPostAgregar()
        {
            if (!string.IsNullOrWhiteSpace(NuevaDescripcion))
            {
                tareasDb.Add(new Tarea
                {
                    Id = tareasDb.Count + 1,
                    Descripcion = NuevaDescripcion,
                    Completada = false
                });
            }
            return RedirectToPage();
        }

        // Método para marcar como completada
        public IActionResult OnPostCompletar(int id)
        {
            var tarea = tareasDb.Find(t => t.Id == id);
            if (tarea != null)
            {
                tarea.Completada = true;
            }
            return RedirectToPage();
        }

        // Método para eliminar una tarea
        public IActionResult OnPostEliminar(int id)
        {
            var tarea = tareasDb.Find(t => t.Id == id);
            if (tarea != null)
            {
                tareasDb.Remove(tarea);
            }
            return RedirectToPage();
        }

        // Método para editar tarea
        public IActionResult OnPostEditar()
        {
            var tarea = tareasDb.Find(t => t.Id == EditarId);
            if (tarea != null && !string.IsNullOrWhiteSpace(EditarDescripcion))
            {
                tarea.Descripcion = EditarDescripcion;
            }
            return RedirectToPage();
        }
    }
}

