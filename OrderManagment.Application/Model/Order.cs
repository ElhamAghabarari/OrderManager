﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Application.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId {  get; set; }
        public string Name { get; set; }
    }
}
