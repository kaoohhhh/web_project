using System; 
using System.ComponentModel.DataAnnotations; 
using Microsoft.AspNetCore.Identity;

namespace SourceCode.Models { 
    public class PartyUser : IdentityUser{
        public bool Vote {get; set;}
    }

	public class Party{         
		public int PartyID { get; set;}  
        public int ID { get; set;}  
        public string PartyName {get; set;}
		public string PartyAlbum {get; set;}         
		public string LeaderName { get; set;}  
        public string SecondName { get; set;}  
        public string MemberName { get; set;}
        public int Count {get; set;}
    } 
}