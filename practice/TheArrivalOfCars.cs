//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace practice
{
    using System;
    using System.Collections.Generic;
    
    public partial class TheArrivalOfCars
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TheArrivalOfCars()
        {
            this.CarSale = new HashSet<CarSale>();
        }
    
        public string receiptDocument { get; set; }
        public Nullable<System.DateTime> dateOfReceipt { get; set; }
        public string nameCar { get; set; }
        public string fillNameEmployee { get; set; }
        public Nullable<double> initialPrice { get; set; }
    
        public virtual Car Car { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarSale> CarSale { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
