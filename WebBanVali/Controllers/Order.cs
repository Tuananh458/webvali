using System.Data.Entity;
using System;
using WebBanVali.Models;
using System.Collections.Generic;
using System.Net;
using System.Security.Policy;
using System.Web.Helpers;

namespace WebBanVali.Controllers
{
    public class Order
    {
        private QLBanVaLiEntities qLBanVaLiEntities { get; set; }
        public Cart cart {  get; set; }
        public tKhachHang khachHang { get; set; }
        private string Name { get; set; }
        private string Address { get; set; }
        private string Phone { get; set; }
        private string Email { get; set; }
        private string Note { get; set; }

        public Order(Cart cart, tKhachHang khachHang)
        {
            this.qLBanVaLiEntities = new QLBanVaLiEntities();
            this.cart = cart;
            this.khachHang = khachHang;
        }

        public Order(Cart cart, tKhachHang khachHang, string name, string address, string phone, string email, string note) : this(cart, khachHang)
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
            Note = note;
        }

        public List<CartItem> GetLISTCARTS => cart.GetLISTCARTS;
        public double Total => cart.Total;
        public double SubTotal => cart.SubTotal;

        public Order() { }
        public void PlaceOrder(out string result, out string error)
        {
            result = string.Empty;
            error = string.Empty;

            try
            {
                // Create a new order
                tHoaDonBan newOrder = new tHoaDonBan
                {
                    NgayBan = DateTime.Now,
                    MaKhachHang = khachHang.MaKhachHang // Assuming tKhachHang has a MaKhachHang property
                };

                // Add order details from the cart
                foreach (var cartItem in cart.GetLISTCARTS)
                {
                    tChiTietHDB orderDetail = new tChiTietHDB
                    {
                        MaChiTietSP = cartItem.MaChiTietSP,
                        SoLuong = cartItem.SoLuong,
                        DonGia = cartItem.DonGiaBan
                    };

                    newOrder.tChiTietHDBs.Add(orderDetail);
                }

                // Save the order to the database
                qLBanVaLiEntities.tHoaDonBans.Add(newOrder);
                qLBanVaLiEntities.SaveChanges();

                result = "Order placed successfully!";
            }
            catch (Exception ex)
            {
                error = $"Error placing order: {ex.Message}";
            }
        }
        public void PlaceOrder()
        {
            try
            {
                // Create a new order
                tHoaDonBan newOrder = new tHoaDonBan
                {
                    NgayBan = DateTime.Now,
                    MaKhachHang = khachHang.MaKhachHang, // Assuming tKhachHang has a MaKhachHang property
                    Name = this.Name,
                    Address = this.Address,
                    Phone = this.Phone,
                    Email = this.Email,
                    Note = this.Note

            };

                // Add order details from the cart
                foreach (var cartItem in cart.GetLISTCARTS)
                {
                    tChiTietHDB orderDetail = new tChiTietHDB
                    {
                        MaChiTietSP = cartItem.MaChiTietSP,
                        SoLuong = cartItem.SoLuong,
                        DonGia = cartItem.DonGiaBan
                    };

                    newOrder.tChiTietHDBs.Add(orderDetail); 
                    var product = qLBanVaLiEntities.tChiTietSanPhams.Find(cartItem.MaChiTietSP);
                    if (product != null)
                    {
                        product.SLTon -= cartItem.SoLuong;
                        if(product.SLTon < 0) product.SLTon = 0;
                    }
                }

                // Save the order to the database
                qLBanVaLiEntities.tHoaDonBans.Add(newOrder);
                qLBanVaLiEntities.SaveChanges();

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}