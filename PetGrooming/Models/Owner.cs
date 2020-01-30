﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Install  entity framework 6 on Tools > Manage Nuget Packages > Microsoft Entity Framework (ver 6.4)
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PetGrooming.Models
{
    public class Owner
    {
        /*
            An owner is someone who owns one or more pets
            Some things that describe an owner:
                - First Name
                - Last Name
                - Address
                - Phone Number (work)
                - Phone Number (home)

            An owner must reference a list of pets
            
        */
        public int OwnerID { get; set; }
        public string OwnerFname { get; set; }
        public string OwnerLname { get; set; }
        public string OwnerAddress { get; set; }
        public string OwnerWorkPhone { get; set; }
        public string OwnerHomePhone { get; set; }


        //Representing the "Many" in (One Booking to many Owners)
        public ICollection<GroomBooking> GroomBookings { get; set; }

        //Representing the "Many" in (Many Owners to Many Pets)
        public ICollection<Pet> Pets { get; set; }

        [Key]
        public int ownerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public int workPhoneNumber { get; set; }
        public int homePhoneNumber { get; set; }

    }
}