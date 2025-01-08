using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YP01MasterFloor.Models
{
    public class TypeProduct
    {
        /// <summary>
        /// Код
        /// </summary>
        [Key]
        public int idTypeProduct { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Коэффициент
        /// </summary>
        public double coefficient { get; set; }
    }
}
