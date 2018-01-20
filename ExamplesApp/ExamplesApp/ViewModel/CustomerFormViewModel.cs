using ExamplesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamplesApp.ViewModel
{
    public class CustomerFormViewModel
    {
     
        // when we doesnt need to use any functionally property we dont need to use type of List<>
        public List<MemberShipType> MemberShipType { get; set; }
        // With this property we defined Customer class and comes Customer properties
        public Customer Customer { get; set; }


    }
}