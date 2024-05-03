namespace MyCheeseShop.Model
{
    public class ShoppingCart
    {
        public event Action? OnCartUpdated;
        private List<CartItem> _items;

        public ShoppingCart()
        {
            _items = [];
        }

        public void AddItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item is null)
                _items.Add(new CartItem { Cheese = cheese, Quantity = quantity });
            else
                item.Quantity += quantity;

            OnCartUpdated?.Invoke();
        }
        public IEnumerable<CartItem> GetItems()
        {
            return _items;
        }
        public List<CartItem> Items { get { return _items ; } }

        public void SetItems(IEnumerable<CartItem> items)
        {
            // set items in the cart
            _items = items.ToList();
            OnCartUpdated?.Invoke();
        }
        public decimal Total()
        {
            // sum the price of all items in the cart
            return _items.Sum(item => item.Cheese.Price * item.Quantity);
        }
    }
}
