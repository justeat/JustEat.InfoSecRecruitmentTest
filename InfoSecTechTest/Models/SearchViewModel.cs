using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InfoSecTechTest.Models;

namespace InfoSecTechTest.Models
{
    public class SearchViewModel
    {
        public IEnumerable<Article> Results { get; set; }
        public string SearchTerm { get; set; }
    }
}