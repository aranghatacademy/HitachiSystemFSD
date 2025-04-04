using System;

namespace Ecom.Data.Exceptions;

public class DuplicateEmailException : Exception
{
    public DuplicateEmailException() : base()
    {
    }

    public DuplicateEmailException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public DuplicateEmailException(string message) : base(message)
    {
    }
}
