using System;
using TradeCategory.Interfaces;

namespace TradeCategory
{
    public class Trade : ITrade
    {
        public double Value { get; }
        public string ClientSector { get; }
        public DateTime NextPaymentDate { get; }

        public Trade(double value, string clientSector, DateTime nextPaymentDate)
        {
            this.ClientSector = clientSector;
            this.Value = value; 
            this.NextPaymentDate = nextPaymentDate;
        }
    }
}
