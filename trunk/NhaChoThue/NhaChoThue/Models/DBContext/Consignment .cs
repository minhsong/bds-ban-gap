using NhaChoThue.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhaChoThue.Models.DBContext
{
    public class Consignment : BaseModel
    {
        /*
         * Customer information
         */
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        /* Produc information*/
        public string Description { get; set; }
        public double Price { get; set; }

    }
}