using System.Collections.Generic;

namespace SistFinanceiroTest.SeedWork
{
    public class Result<T>
    {
        public T Object;
        public List<string> Errors;
        public bool Valid;
        
    }
}