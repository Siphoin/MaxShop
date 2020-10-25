namespace MaxShop.Delta.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int PhoneId { get; set; }

        public int Price { get; set; }

        public virtual Phone Phone { get; set; }

        public virtual Order Order { get; set; }

        public OrderDetail ()
        {

        }

        public OrderDetail ( int phoneId, int price, int orderId)
        {
            PhoneId = phoneId;
            Price = price;
            OrderId = orderId;
        }
    }
}
