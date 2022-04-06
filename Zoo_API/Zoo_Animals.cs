using System;
using Microsoft.AspNetCore.Mvc;

namespace Zoo_API
{
    public class Zoo_Animals
    {
        public Zoo_Animals()
        {
        }

        // Properties
        [BindProperty]
        public int animal_id { get; set; }
        [BindProperty]
        public string animal_name { get; set; }
        [BindProperty]
        public double hair { get; set; }
        [BindProperty]
        public double feathers { get; set; }
        [BindProperty]
        public double eggs { get; set; }
        [BindProperty]
        public double milk { get; set; }
        [BindProperty]
        public double airborne { get; set; }
        [BindProperty]
        public double aquatic { get; set; }
        [BindProperty]
        public double predator { get; set; }
        [BindProperty]
        public double toothed { get; set; }
        [BindProperty]
        public double backbone { get; set; }
        [BindProperty]
        public double breathes { get; set; }
        [BindProperty]
        public double venomous { get; set; }
        [BindProperty]
        public double fins { get; set; }
        [BindProperty]
        public double legs { get; set; }
        [BindProperty]
        public double tail { get; set; }
        [BindProperty]
        public double domestic { get; set; }
        [BindProperty]
        public double catsize { get; set; }
        [BindProperty]
        public double class_type { get; set; }

    }
}
