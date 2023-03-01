﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AtoTax.Domain.Entities
{
    public class APIResponse
    {

        public APIResponse()
        {
            ErrorMessages= new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string SuccessMessage { get; set; } 
        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }
    }
}