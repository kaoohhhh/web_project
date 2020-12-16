using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;

using SourceCode.Data;
using SourceCode.Models;
using Microsoft.EntityFrameworkCore;


namespace SourceCode.Pages
{
    public class VoteModel : PageModel
    {
        private readonly SourceCode.Data.SourceCodeContext _context;

        private readonly UserManager<PartyUser> _userManager;
        private readonly SignInManager<PartyUser> _signInManager;

        [BindProperty]
        public Party Party { get; set; }
        public int voteChoice;
        public string voteChoiceName;
        
        public VoteModel(SourceCode.Data.SourceCodeContext context, UserManager<PartyUser> userManager,  SignInManager<PartyUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IList <Party>  Partys {get; set;}

       public async Task OnGetAsync()
        {
            Partys = await _context.partyList.ToListAsync(); 
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
       
            voteChoice = int.Parse(Request.Form["choice"]);
           
            Party =  _context.partyList.FirstOrDefault(m => m.ID == voteChoice);  
            Party.Count++;

            voteChoiceName = Party.PartyName;

            var user = await _userManager.GetUserAsync(User);
            user.Vote = false;
            await _userManager.UpdateAsync(user);

             _context.Attach(Party).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartyExists(Party.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./About");
        }

        private bool PartyExists(int id)
        {
            return _context.partyList.Any(e => e.ID == id);
        }



    }
}