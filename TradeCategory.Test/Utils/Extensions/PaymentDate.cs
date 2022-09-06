using System;

namespace TradeCategory.Utils
{
    public static class PaymentDate
    {
        public static int NextPaymentDays(this DateTime startDate, DateTime endDate)
        {
            TimeSpan dateDiff = startDate - endDate;
            return dateDiff.Days;
        }
    }
}
