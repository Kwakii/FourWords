using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorChat.Shared
{
    [Serializable]
    public class MutableKeyValue<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }


        public MutableKeyValue(TKey key, TValue value) 
        {
            Key = key;
            Value = value;
        }

        public MutableKeyValue()
        {

        }
    }
}
