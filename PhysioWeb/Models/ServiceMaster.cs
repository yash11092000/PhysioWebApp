using System;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using Microsoft.Identity.Client;

namespace PhysioWeb.Models
{
    public class ServiceMaster : CommanProp
    {
        
        public string Title { get; set; }  
        public bool IsActive { get; set; } 
        public ServiceMaster() {

        }
    }
}
