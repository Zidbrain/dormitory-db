﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace Database
{
    public partial class Гости
    {
        public int Id { get; set; }
        public string Фамилия { get; set; }
        public string Имя { get; set; }
        public string Отчество { get; set; }
        public string Телефон { get; set; }
        public int? ККому { get; set; }
        public DateTime? ДатаПосещения { get; set; }

        public virtual Студенты Студенты { get; set; }
    }
}