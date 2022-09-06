using TradeCategory.Interfaces;

namespace TradeCategory.Categories
{
    internal class PrivateSectorCategory : ICategory
    {
        private const string category = "HIGHRISK";
        public string GetCategory(ITrade trade)
        {
            // code ready to add some business logic here if necessary
            if (trade.Value > 1000000)
            {
                return category;
            }
            // there is no other definition besides that one above
            return "Not Defined";
        }
    }
}
