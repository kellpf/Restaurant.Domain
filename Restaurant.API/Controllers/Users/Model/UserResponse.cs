﻿namespace WebAPI.Controllers.Users.Model
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Status { get; set; }
    }
}
