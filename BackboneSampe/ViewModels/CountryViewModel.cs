using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackboneSampe.ViewModels
{
    public class CountryViewModel
    {
        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public List<StateViewModel> State { get; set; }
    }
}