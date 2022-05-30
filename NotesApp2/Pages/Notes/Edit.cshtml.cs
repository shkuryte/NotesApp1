using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NotesApp2.Model;
using NotesApp2.Repositories;

namespace NotesApp2.Pages.Notes
{
    public class EditModel : PageModel
    {
        public readonly NotesRepository _notesRepository;

        public EditModel(NotesRepository notesRepository)
        {
            _notesRepository = notesRepository;

        }
        [BindProperty]
        public Note Note { get; set; }

        public void OnGet(int id)
        {
            Note = _notesRepository.GetNote(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var noteFromDb = _notesRepository.GetNote(Note.Id);

                noteFromDb.Title = Note.Title;
                noteFromDb.Content = Note.Content;

                _notesRepository.UpdateNote(noteFromDb);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }







            /*            var tryUpdate = await TryUpdateModelAsync<Book>(bookFromDb, "book"
                            ,s => s.Id, s => s.AuthorId, s => s.Title, s => s.Content);

                        if (tryUpdate)
                        {
                            _booksRepository.UpdateBook(bookFromDb);
                            return RedirectToPage("Index");
                        }
                        GenerateAuthorsDropDownList(_context, bookFromDb.AuthorId);*/
        }

    }
}
