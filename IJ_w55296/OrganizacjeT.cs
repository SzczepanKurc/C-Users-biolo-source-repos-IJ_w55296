
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



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
    using System.ComponentModel.DataAnnotations;

    public partial class OrganizacjeT
    {

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrganizacjeT()
        {

            this.ZarzadT = new HashSet<ZarzadT>();

        }

        public int OrganizacjaID { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [StringLength(200, ErrorMessage = "Przekroczono zakres")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "To pole jest wymagane")]
        [StringLength(10, ErrorMessage = "Przekroczono zakres")]
        public string KRS { get; set; }

        [StringLength(20, ErrorMessage = "Przekroczono zakres")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Wojewodztwo { get; set; }

        [StringLength(60, ErrorMessage = "Przekroczono zakres")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Powiat { get; set; }

        [StringLength(60, ErrorMessage = "Przekroczono zakres")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Gmina { get; set; }

        [StringLength(60, ErrorMessage = "Przekroczono zakres")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Miasto { get; set; }

        [Display(Name = "Kod pocztowy")]
        [StringLength(6, ErrorMessage = "Przekroczono zakres")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string KodPocztowy { get; set; }

        [StringLength(60, ErrorMessage = "Przekroczono zakres")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string Ulica { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon")]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{2})[-. ]([0-9]{2})$", ErrorMessage = "Wpisz xx-xxx-xx-xx.")]
        public string Telefon { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefon Kom")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]([0-9]{3})$", ErrorMessage = "Wpisz xxx-xxx-xxx.")]
        public string TelefonKom { get; set; }

        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Wpisz adres E-mail w poprawnej formie xxx@xxx.xxx")]
        public string Email { get; set; }

        public string AdresWWW { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data za�o�enia")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DataZalozenia { get; set; }

        [Display(Name = "Forma prawna")]
        [StringLength(60, ErrorMessage = "Przekroczono zakres")]
        [Required(ErrorMessage = "To pole jest wymagane")]
        public string FormaPrawna { get; set; }

        [Required(ErrorMessage = "Wybierz jedn� z mo�liwosci")]
        public string Aktywnosc { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        public virtual ICollection<ZarzadT> ZarzadT { get; set; }

    }

}
