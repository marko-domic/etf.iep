//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Veb_portal_za_aukcijsku_prodaju.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Aukcija
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aukcija()
        {
            this.Bids = new HashSet<Bid>();
            this.Korisniks = new HashSet<Korisnik>();
        }
    
        public int AukcijaID { get; set; }
        public string Proizvod { get; set; }
        public Nullable<int> Trajanje { get; set; }
        public Nullable<double> PocetnaCena { get; set; }
        public Nullable<System.DateTime> VremeKreiranja { get; set; }
        public Nullable<System.DateTime> VremeOtvaranja { get; set; }
        public Nullable<System.DateTime> VremeZatvaranja { get; set; }
        public string Status { get; set; }
        public Nullable<double> TrenutnaCena { get; set; }
        public byte[] Slika { get; set; }
        public Nullable<int> BidID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual Bid Bid { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Korisnik> Korisniks { get; set; }
    }
}
