//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ForeignLanguageSchoolApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reviews
    {
        public int IdReview { get; set; }
        public string ReviewMessage { get; set; }
        public int ClientId { get; set; }
        public int ReviewRating { get; set; }
    
        public virtual Clients Clients { get; set; }
    }
}
