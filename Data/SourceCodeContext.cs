using SourceCode.Models; 
using Microsoft.EntityFrameworkCore; 
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; 

namespace SourceCode.Data {     
    public class SourceCodeContext :  IdentityDbContext<PartyUser>     
    {         
        public DbSet<Party> partyList { get; set; }                    
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {             
            optionsBuilder.UseSqlite(@"Data source= SourceCode.db");                  
         }     
     } 
}