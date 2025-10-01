using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Shared.Absractions
{
    public class Result
    {
        public Result(bool isSuccess, Error error)
        {
            if ((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
                throw new InvalidOperationException("Invalid Result state.");
            IsSuccess = isSuccess;
            this.error = error;
        }
        public bool IsSuccess { get; }
        public bool isFailure => !IsSuccess;
        public Error error { get; }

        public static Result Success() => new Result(true, Error.None);
        public static Result Failure(Error error) => new Result(false, error);
        public static Result<TValue> Success<TValue>(TValue value) => new Result<TValue>(value, true, Error.None);
        public static Result<TValue> Failure<TValue>(Error error) => new Result<TValue>(default, false, error);
    }
    public class Result<TValue> : Result
    {
        private TValue? _value;
        public Result(TValue? value, bool IsSuccess, Error error) : base(IsSuccess, error)
        {
            _value = value;
        }
        public TValue Value =>
            IsSuccess ?
            _value!
           : throw new InvalidOperationException("Failure result: Value cannot be accessed.");

    }
}
