using System.Collections.Generic;
using Xpeppers.Chirper.Abstraction;

namespace Xpeppers.Chirper
{
    public class EmptyChirperContext : IChirperContext
    {
        public ICollection<IUser> Users { get; set; }

        public EmptyChirperContext()
        {
        }
    }
}
