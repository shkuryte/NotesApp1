using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp2.Areas.Identity.Data;
using NotesApp2.Model;
using NotesApp2.Repositories;
using NotesApp2.Services;

namespace NotesApp2.Pages.Notes
{
    public class CreateModel : PageModel
    {
        
        private readonly NotesRepository _repository;


        [BindProperty]
        public Note Note { get; set; }

        public CreateModel(NotesRepository repository)
        {
            
            _repository = repository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _repository.CreateNote(Note);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
