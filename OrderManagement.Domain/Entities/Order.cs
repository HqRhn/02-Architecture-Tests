using OrderManagement.Domain.Primitives;

namespace OrderManagement.Domain.Entities
{
    public sealed class Order : Entity
    {
        public Order(string name, DateTime scheduledOn)
        {
            OrderReference = name;
            CreatedOn = scheduledOn;
        }
        public Order()
        {
        }
        public string OrderReference { get;  set; }
        public DateTime CreatedOn { get;  set; }
    }
}
