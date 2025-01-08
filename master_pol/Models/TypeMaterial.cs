using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YP01MasterFloor.Models
{
    public class TypeMaterial
    {
        /// <summary>
        /// Код
        /// </summary>
        [Key]        
        public int idTypeMaterial { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Процент брака
        /// </summary>
        public double defectRate { get; set; }
    }
}
