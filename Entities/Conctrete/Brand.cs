﻿using Core.Entities;

namespace Entities.Conctrete
{
    public class Brand : IEntity
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}