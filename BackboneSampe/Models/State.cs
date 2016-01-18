using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackboneSampe.Models
{
    public class State
    {
        public int StateID { get; set; }
        public string StateName { get; set; }
        public string Descriptions { get; set; }
        public int CountryID { get; set; }
        public string ImageName { get; set; }
        public Country Country { get; set; }
    }
}