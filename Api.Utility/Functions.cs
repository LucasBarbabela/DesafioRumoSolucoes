using Api.Enum;
using Api.Utility.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Utility
{
    public static class Functions
    {
        public static void IdIsValid(int id)
        {
            if (id < 0)
                throw new ApiException(StatusCodeEnum.BadRequest, MsgException.NegativeNumber);
        }

        public static bool IsAnyNullOrEmpty(object obj)
        {
            if (obj is null)
                return true;

            return obj.GetType().GetProperties()
                .Any(x => IsNullOrEmpty(x.GetValue(obj)));
        }

        private static bool IsNullOrEmpty(object value)
        {
            if (value is null)
                return true;

            var type = value.GetType();
            return type.IsValueType
                && Object.Equals(value, Activator.CreateInstance(type));
        }
    }
}
