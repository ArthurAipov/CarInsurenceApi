//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarInsurenceApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Car
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string HorsePower { get; set; }
        public int UserId { get; set; }
        public int ModelId { get; set; }
    
        public virtual Model Model { get; set; }
        public virtual User User { get; set; }
    }
}
