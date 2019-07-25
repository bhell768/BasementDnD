using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasementRPG.Repositories.Abstract
{
    public interface IHelloRepository
    {
        string GetHelloMessage(string name);

        void UpdateGreetingMessage(string greeting);
    }
}
