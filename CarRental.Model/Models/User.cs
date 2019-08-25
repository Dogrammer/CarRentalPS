using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarRental.Model.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CarRental.Model.Models
{
    public class User : IdentityUser, ISoftDeletable
    {
        [Required(ErrorMessage="Polje 'ime' je obvezno polje."), StringLength(100, ErrorMessage = "Duljina naziva imena smije biti maksimalno 100 znakova")]
        public string FirstName { get; set; }
        [Required(ErrorMessage="Polje 'prezime' je obvezno polje"), StringLength(100, ErrorMessage = "Duljina naziva prezimena smije biti maksimalno 100 znakova")]
        public string LastName { get; set; }
        [Required(ErrorMessage="Polje 'Datum rođenja' je obvezno polje.")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage="Polje 'broj vozacke dozvole je obvezno polje.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage ="Duljina broja vozačke dozvole mora iznositi 8 znakova")]
        public string  DrivingLicenceNumber{ get; set; }
        public bool IsDeleted { get; set;} = false;
    }
}
