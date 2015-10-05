using System.Collections.Generic;

namespace TheKids.WebApi.Models.Kids
{
    public class SearchKidsReponseModel 
    {
        public IEnumerable<object> Kids { get; set; }
    }

    public class KidModel
    {
        public int KidId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }

    }
}