//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Doctor
    {
        public string Username { get; set; }
        public string Dname { get; set; }
        public int Age { get; set; }
        public string Mobile { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
    
        public virtual Login Login { get; set; }
    }
}
