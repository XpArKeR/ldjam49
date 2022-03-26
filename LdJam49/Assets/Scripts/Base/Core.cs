using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Base
{
    public static class Core
    {
        private static Lazy<Scripts.Game> lazyGame = new Lazy<Scripts.Game>(true);
        public static Scripts.Game Game
        {
            get
            {
                return lazyGame.Value;
            }
        }
    }
}
