using Microsoft.AspNetCore.Mvc.ModelBinding;
using Project_1.BLL.Library.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ben_Project_1.Models
{
    public class CustomerModel
    {
        [Display(Name = "ID")]
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int DefaultStoreId { get; set; }

        public List<StoreImp> Stores { get; set; }

        public StoreImp DefaultStore { get; set; }
    }
}
