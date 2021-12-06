using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxaProjeWeb.UI.Models
{
    public class CustomerEditPostModel
    {
        public int Id { get; set; }
        public int? CostumerCategoriesId { get; set; }
        public string Adress { get; set; }
        public string FullName { get; set; }

    }
}
