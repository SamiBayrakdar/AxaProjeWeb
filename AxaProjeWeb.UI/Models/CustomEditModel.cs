using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AxaProjeWeb.UI.Models
{
    public class CustomEditModel
    {
        public int Id { get; set; }
        public int? CategoriesId { get; set; }
        public string CategoriesName { get; set; }
        public string Adress { get; set; }
        public string FullName { get; set; }
    }
}
