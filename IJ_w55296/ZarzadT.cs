
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace IJ_w55296
{

using System;
    using System.Collections.Generic;
    
public partial class ZarzadT
{

    public int ZarzadID { get; set; }

    public string Nazwisko { get; set; }

    public string Imie { get; set; }

    public string Funkcja { get; set; }

    public int OrganizacjaID { get; set; }



    public virtual OrganizacjeT OrganizacjeT { get; set; }

}

}
