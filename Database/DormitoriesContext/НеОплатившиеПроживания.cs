// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Database
{
    public partial class НеОплатившиеПроживания
    {
        public int СтудентId { get; set; }
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public string Отчетство { get; set; }
        public int НомерКомнаты { get; set; }
        public DateTime? Заселение { get; set; }
        public DateTime? Выселение { get; set; }
        public decimal? ПлатаЗаМесяц { get; set; }
    }
}