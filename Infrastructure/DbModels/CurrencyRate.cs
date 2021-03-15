using System;
using System.Collections.Generic;

namespace StoneTest.Infrastructure.DbModels
{
    public partial class CurrencyRate
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string NumCode { get; set; }
        public string CharCode { get; set; }
        public int? Nominal { get; set; }
        public string Name { get; set; }
        public decimal? Value { get; set; }
    }
}
