using Movietec.Models.Attributes;
using Movietec.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movietec.Models.ViewModels
{
    public class CustomerFormViewModel
    {
        public CustomerFormViewModel()
        {
            this.Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            this.Id = customer.Id;
            this.Name = customer.Name;
            this.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            this.BirthDate = customer.BirthDate;
            this.MembershipTypeId = customer.MembershipTypeId;
        }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        [Required]
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Birth Date")]
        [Required18YearsOld]
        public DateTime? BirthDate { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public int? MembershipTypeId { get; set; }
    }
}
