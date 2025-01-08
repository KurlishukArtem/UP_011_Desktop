using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YP01MasterFloor.Models
{
    public class ProcGetHistPartner
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Артикл
        /// </summary>
        [Key]
        public int article { get; set; }
        /// <summary>
        /// Минимальная цена
        /// </summary>
        public double minPrice { get; set; }
        /// <summary>
        /// Количество продаж
        /// </summary>
        public int countProduct { get; set; }
        /// <summary>
        /// Дата продажи
        /// </summary>
        public DateTime dateSell { get; set; }
    }
}
