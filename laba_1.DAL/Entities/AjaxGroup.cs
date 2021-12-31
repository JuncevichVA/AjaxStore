using System;
using System.Collections.Generic;
using System.Text;

namespace laba_1.DAL.Entities
{
   public class AjaxGroup
    {
        public int AjaxGroupId { get; set; }
        public string GroupName { get; set; }

        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        
        public List<Ajax> Ajaxes { get; set; }
    }
}
