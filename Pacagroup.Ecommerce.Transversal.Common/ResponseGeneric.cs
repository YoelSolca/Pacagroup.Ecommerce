﻿using FluentValidation.Results;
using System.Collections.Generic;

namespace Pacagroup.Ecommerce.Transversal.Common
{
    public class ResponseGeneric<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public IEnumerable<ValidationFailure> Error { get; set; }
    }
}
