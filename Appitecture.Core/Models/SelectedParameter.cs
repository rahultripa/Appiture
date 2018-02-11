using System;
using System.Collections.Generic;

namespace Appitecture.Core.Models
{
    public class SelectedParameter
    {
        public SelectedParameter()
        {
        }

        public List<String> listProfession { get; set; }
        public string selectedProfession{get; set;}
        public string selectedRatting { get; set; }
        public string selectedLocalKnowlage { get; set; }
        public string selectedVachile { get; set; }

        public int minPrice { get; set; }
        public int maxPrice { get; set; }
    }
}
