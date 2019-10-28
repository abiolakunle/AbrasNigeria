using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbrasNigeria.Models
{
    public class Order
    {
        public long OrderId { get; set; }

        public Order()
        {
            CartItems = new HashSet<CartItem>();
        }

        public string OrderNo { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string CityState { get; set; }

        public string Note { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Date { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
