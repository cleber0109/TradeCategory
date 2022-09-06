using TradeCategory.Interfaces;

namespace TradeCategory
{
    public class CategoryContext
    {
        private ICategory _category;
        public CategoryContext(ICategory category)
        {
            _category = category;
        }

        public CategoryContext()
        {

        }
        public void DefineCategory(ICategory category) => _category = category; 
        public string GetCategory(ITrade trade)
        {
            return _category.GetCategory(trade);
        }
    }
}
