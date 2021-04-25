using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkyMonkey {
    static class Options {
        public static bool RADAR = false;
        public static bool AIMBOT = true;
        public static bool GLOW = true;

        public static class GLOW_VAL {
            public static class ENEMY {
                public static float R = 1f;
                public static float G = 2f;
                public static float B = 0f;
                public static float A = 1f;
            }

            public static class FRIENDLY {
                public static float R = 0f;
                public static float G = 1f;
                public static float B = 0f;
                public static float A = 0f;
            }
        }

        public static float PLAYER_HEAD_OFFSET = 65f;
    }
}
