﻿using Core.Entities;

namespace Entities.Conctrete
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}