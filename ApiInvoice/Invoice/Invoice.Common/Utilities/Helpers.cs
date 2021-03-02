using System;
using System.Collections.Generic;

namespace Invoice.Common.Utilities
{
    public static class Helpers
    {
        public static bool IsIENumerableEmpty<T>(IEnumerable<T> iEnumerable)
        {
            bool isEmpty = true;
            foreach (T item in iEnumerable)
            {
                isEmpty = false;
                break;
            }
            return isEmpty;
        }
    }
}
