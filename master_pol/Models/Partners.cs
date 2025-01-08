using System.ComponentModel.DataAnnotations;

namespace master_pol.Models
{
    public class Partners
    {
        /// <summary>
        /// Идентификатор партнера.
        /// </summary>
        [Required]
        [Key]
        public int id { get; set; }
        /// <summary>
        /// Тип компании.
        /// </summary>
        public int type { get; set; }
        /// <summary>
        /// Наименование компании.
        /// </summary>
        public string name_company { get; set; }
        /// <summary>
        /// Юридический адрес.
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// ИНН.
        /// </summary>
        public long inn { get; set; }
        /// <summary>
        /// ФИО директора.
        /// </summary>
        public string fio_director { get; set; }
        /// <summary>
        /// Почта директора/копании.
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// Номер телефона.
        /// </summary>
        public long phone { get; set; }
        /// <summary>
        /// Рейтинг.
        /// </summary>
        public int rating { get; set; }
        /// <summary>
        /// Места продаж
        /// </summary>
        public string places_sells { get; set; }
    }
}
