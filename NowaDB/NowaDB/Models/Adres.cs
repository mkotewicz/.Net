//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NowaDB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Adres
    {
        public Adres()
        {
            this.Pracownik = new HashSet<Pracownik>();
        }
    
        public int Id { get; set; }
        public string ulica { get; set; }
        public Nullable<int> numerDomu { get; set; }
        public Nullable<int> numerMieszkania { get; set; }
        public string miasto { get; set; }
        public string kod { get; set; }
    
        public virtual ICollection<Pracownik> Pracownik { get; set; }
    }
}
