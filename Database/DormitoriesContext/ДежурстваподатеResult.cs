﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    public partial class ДежурстваподатеResult
    {
        public string Имя { get; set; }
        public string Фамилия { get; set; }
        public string Отчетство { get; set; }
        public int? Комната { get; set; }
        public int Этаж { get; set; }
        public bool? Выполнено { get; set; }
    }
}
