﻿using System;
using System.Net;

namespace MGonzaga.WebMotors.Anuncios.Infrastructure.Exceptions

{
    public class ValidationException : Exception
    {
        public HttpStatusCode StatusCodeToReturn { get; set; }
        public ValidationException(string message) : base(message)
        {
            StatusCodeToReturn = HttpStatusCode.BadRequest;
        }
        public ValidationException(HttpStatusCode statusCodeToReturn, string message) : base(message)
        {
            this.StatusCodeToReturn = statusCodeToReturn;
        }
    }
}
