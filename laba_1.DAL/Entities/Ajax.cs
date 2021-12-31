using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace laba_1.DAL.Entities
{
   public class Ajax
    {
        [Key]
        public int DivicesID { get; set; } // id прибора
        public string DivicesName { get; set; } // наименование прибора
        public string Description { get; set; } // описание прибора
        public int detection { get; set; }// длина действия
        public string Image { get; set; }// имя файла изображения

        // Yfdbufwbjyyst cdjqcndf
        /// <summary>
        /// группа приборов (например: пож.датчики, охр.датчики)
        /// </summary>
        public int AjaxGroupId { get; set; }
        public AjaxGroup Group { get; set; }

    }
}
