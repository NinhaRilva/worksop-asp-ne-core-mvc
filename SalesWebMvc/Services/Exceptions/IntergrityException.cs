﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services.Exceptions
{
    public class IntergrityException : ApplicationException
    {
        public IntergrityException (string Message): base(Message)
        {

        }
    }
}
