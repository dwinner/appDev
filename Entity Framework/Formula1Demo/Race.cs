//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Formula1Demo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Race
    {
        public Race()
        {
            this.RaceResults = new HashSet<RaceResult>();
        }
    
        public int Id { get; set; }
        public int CircuitId { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Circuit Circuit { get; set; }
        public virtual ICollection<RaceResult> RaceResults { get; set; }
    }
}