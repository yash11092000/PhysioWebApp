using System;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using Microsoft.Identity.Client;

namespace PhysioWeb.Models
{
    public class ServicesOffered : CommanProp
    {
        public List<DropDownSource> ServicesList { get; set; }

        public ServicesOffered() {

            ServicesList = new List<DropDownSource>();
        }
    }
}
