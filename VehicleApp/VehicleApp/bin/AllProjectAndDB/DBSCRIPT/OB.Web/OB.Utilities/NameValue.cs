﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OB.Utilities
{
    public class NameValue
    {
        public String Name { get; set; }
        public Object Value { get; set; }

        public NameValue(String Name, Object Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
    }
}
