using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xpeppers.Chirper.Abstraction
{
    public interface IUserRepository
    {
        IUser Find(string UserName);
        IUser Add(string UserName);
        void Save();
    }
}
