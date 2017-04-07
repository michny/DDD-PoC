using System.ComponentModel.DataAnnotations;

namespace DDD.CommercePoC.Shop.Core.Model.ValueObjects
{
    public enum Currency
    {
        [Display(Name = "kr.", Description = "{0} kr.")]
        Dkk,
        [Display(Name = "$", Description = "${0}")]
        Usd,
        [Display(Name = "£", Description = "£{0}")]
        Gbp,
        [Display(Name = "€", Description = "€{0}")]
        Euro
    }
}