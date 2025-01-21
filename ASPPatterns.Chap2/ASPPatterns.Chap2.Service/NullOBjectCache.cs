using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPPatterns.Chap2.Service
{
    public class NullOBjectCache: ICacheStorage
    {
        public void Remove(string key)
        {
            
        }

        public void Store(string key, object data)
        {
            
        }

        public T Retrieve<T>(string key)
        {
            return default(T);
        }
    }
}
