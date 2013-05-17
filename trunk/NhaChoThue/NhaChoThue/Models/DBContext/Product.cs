using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NhaChoThue.Models.DBContext
{
    public class Product:BaseModel
    {
        public int ProductID { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsHired { get; set; }
        public int Views { get; set; }
        public DateTime? HiredDate { get; set; }
        public double? HiredPrice { get; set; }
        //Dientich
        [MaxLength(50)]
        public string DuongTruocNha { get; set; }

        public double? Ngan { get; set; }
        public double? Dai { get; set; }
        public bool Santhuong { get; set; }
        public int? SoLau { get; set; }
        public int? SoPhongNgu { get; set; }
        public int? SoPhongTam { get; set; }
        
        public int ContactId { get; set; }
        public int WardID { get; set; }

        //realtionship object

        public virtual Ward Ward { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
        public virtual ICollection<PriorityProduct> Priorities { get; set; }
        public virtual ICollection<Consignment> Consignments { get; set; }

        //methods
        #region Methods

        public bool IsCurrentPriority()
        {
            var lp = from s in Priorities
                    where (s.StarDate <= DateTime.Now||s.StarDate==null)
                    && (s.EndDate >= DateTime.Now||s.EndDate == null)
                    && s.IsDelete==false
                    && s.IsActive ==true
                    select s;
            if (lp.Count() > 0)
            {
                return true;
            }
            return false;
        }

        public PriorityProduct CurrentPriority()
        {
            var result = (from s in Priorities
                          where s.StarDate <= DateTime.Now
                          && s.EndDate >= DateTime.Now
                          select s).FirstOrDefault();
            return result;
        }

        public decimal GetID()
        {
            decimal result = (this.CreatedDate.Value.Year - 2000)*10000;
            return result + ProductID;
        }
        #endregion

    }
}