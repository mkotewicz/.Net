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
    
    public partial class Pracownik
    {
        public int Id { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string pesel { get; set; }
        public string email { get; set; }
        public string telefon { get; set; }
        public int adresId { get; set; }
    
        public virtual Adres Adres { get; set; }
    }
}
