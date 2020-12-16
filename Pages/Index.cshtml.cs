using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.EntityFrameworkCore; 
using SourceCode.Data; 
using SourceCode.Models; 

namespace SourceCode.Pages
{
    public class IndexModel : PageModel
    {
        private SourceCode.Data.SourceCodeContext _context; 
 
        public IndexModel(SourceCode.Data.SourceCodeContext context)         {  
            _context = context;         
            }
            
        public IList<Party> Partys { get;set; } 
 
        public async Task OnGetAsync() {             
            Partys = await _context.partyList.ToListAsync();     
        }         
    }
}
