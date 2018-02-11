using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Appitecture.Core
{
    public static class UtilitiesClass
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }
    }
}
