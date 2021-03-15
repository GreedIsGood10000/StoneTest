using System;
using System.Collections.Generic;

namespace StoneTest.Infrastructure.DbModels
{
    public partial class Currency
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EngName { get; set; }
        public int? Nominal { get; set; }
        public string ParentCode { get; set; }
        public string NumCode { get; set; }
        public string CharCode { get; set; }
    }
}
