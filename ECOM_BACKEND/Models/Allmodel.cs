using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECOM_BACKEND.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public Category Category { get; set; }
        [InverseProperty("Product")]
        public ICollection<Review> Reviews { get; set; }
    }

    public class Review
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Content { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
    }

    public class Order
    {
        [Key]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [InverseProperty("Order")]
        public ICollection<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        [Key]
        public int ID { get; set; }
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Cart
    {
        [Key]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        [InverseProperty("Cart")]
        public ICollection<CartItem> CartItems { get; set; }
    }

    public class CartItem
    {
        [Key]
        public int ID { get; set; }
        public int CartID { get; set; }
        [ForeignKey("CartID")]
        public Cart Cart { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }

    public class Customer
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int ShippingAddressID { get; set; }
        [ForeignKey("ShippingAddressID")]
        public Address ShippingAddress { get; set; }
        public int BillingAddressID { get; set; }
        [ForeignKey("BillingAddressID")]
        public Address BillingAddress { get; set; }
    }

    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }

    public class Address
    {
        [Key]
        public int ID { get; set; }


        [StringLength(100)]
        public string Street { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [StringLength(50)]
        public string State { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        public int ZipCode { get; set; }
    }
}
