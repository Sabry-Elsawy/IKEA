using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.IKEA.DAL.Constract
{
    public interface IDbIntializer
    {
        void Initialize();
        void seed();
    }
}
