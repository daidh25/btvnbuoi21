﻿using DataAccess.BookStore.DTO;

namespace BookStoreWeb.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Role? Role { get; set; }
        public string? Report { get; set; }
    }
}