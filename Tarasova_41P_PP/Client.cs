
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Tarasova_41P_PP
{

using System;
    using System.Collections.Generic;
    
public partial class Client
{

    public int ClientCode { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string Patronymic { get; set; }

    public string Passport { get; set; }

    public string Policy { get; set; }

    public string Snils { get; set; }

    public string Email { get; set; }

    public Nullable<System.DateTime> Date { get; set; }

    public Nullable<System.TimeSpan> Time { get; set; }

    public Nullable<int> ServicesCode { get; set; }



    public virtual services services { get; set; }

}

}
