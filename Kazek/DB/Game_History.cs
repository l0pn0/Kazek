//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kazek.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game_History
    {
        public int id_game_history { get; set; }
        public Nullable<int> id_user { get; set; }
        public Nullable<int> id_game { get; set; }
        public string result { get; set; }
        public Nullable<System.DateTime> played_time { get; set; }
    
        public virtual Game Game { get; set; }
        public virtual User User { get; set; }
    }
}
