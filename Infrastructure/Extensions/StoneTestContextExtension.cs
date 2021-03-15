using System;
using Microsoft.EntityFrameworkCore;
using StoneTest.Infrastructure.DbModels;

namespace StoneTest.Infrastructure.Extensions
{
    public static class StoneTestContextExtension
    {
        [DbFunction("Get_CurrencyRate")]
        public static decimal? GetCurrencyRate(this StoneTestContext dbContext, string charName, DateTime date) => throw new NotImplementedException();
    }
}
