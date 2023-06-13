using SpotifyClone.Entities.abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities.concretes
{
    public class MembershipType : IMembershipType
    {
        public MembershipType()
        {
            
        }
        [Key]
        public int id { get; set; }
        public string type { get ; set ; }
        public double price { get; set; }
    }
}
