using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ChatApp.Application.Common.Exceptions
{
    public class DuplicateUserException : Exception
    {
        public string DuplicateValue { get; private set; }

        public DuplicateUserException(string value)
        {
            DuplicateValue = value;
        }

        public DuplicateUserException(string value, string message) : base(message)
        {
            DuplicateValue = value;
        }

        public DuplicateUserException(string value, string message, Exception innerException) : base(message, innerException)
        {
            DuplicateValue = value;
        }

        public override string Message
        {
            get
            {
                return $"{DuplicateValue} already exists. {base.Message}";
            }
        }
    }
}
