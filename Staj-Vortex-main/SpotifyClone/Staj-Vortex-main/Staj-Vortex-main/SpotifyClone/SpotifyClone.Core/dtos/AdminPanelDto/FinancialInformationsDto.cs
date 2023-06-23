using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Core.dtos.AdminPanelDto
{
    public  class FinancialInformationsDto
    {
        public FinancialInformationsDto()
        {
            expenseInDollar = 5;
        }
        public double expenseInDollar { get; set; } 
        public double income { get; set; }

    }
}
