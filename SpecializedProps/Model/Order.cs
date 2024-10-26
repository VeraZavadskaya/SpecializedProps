//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpecializedProps.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public string Id { get; set; }
        public int IdCustomer { get; set; }
        public int IdFM { get; set; }
        public string PhotoSketch { get; set; }
        public System.DateTime DateStart { get; set; }
        public System.DateTime DateFinish { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }
        public bool Delivery { get; set; }
        public string AdressDelivery { get; set; }
        public int IdPayment { get; set; }
        public decimal Summ { get; set; }
        public int IdBranch { get; set; }
        public int IdStatusOrder { get; set; }
        public int IdUser { get; set; }
    
        public virtual Branch Branch { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual FurnitureMaterial FurnitureMaterial { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual StatusOrder StatusOrder { get; set; }
        public virtual User User { get; set; }
    }
}
