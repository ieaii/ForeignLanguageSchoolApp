//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ForeignLanguageSchoolLibraryTests.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Messages
    {
        public int IdMessage { get; set; }
        public string MessageMessage { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Users Users { get; set; }
    }
}