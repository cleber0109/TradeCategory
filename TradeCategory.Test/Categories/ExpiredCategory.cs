using TradeCategory.Interfaces;

namespace TradeCategory.Categories
{
    public class ExpiredCategory : ICategory
    {
        private const string category = "EXPIRED";
        public string GetCategory(ITrade trade)
        {
            // code ready to add some business logic here if necessary
            return category;
        }
    }
}
