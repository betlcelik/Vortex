using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Entities.abstracts
{
    public interface IMembershipType
    {
        [Key] 
        int id { get; set; }
        string type { get; set; }
        double price { get; set; }
    }
}
