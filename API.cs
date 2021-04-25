using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunkyMonkey {
    public class Vector2 {
        public float x, y;
        public Vector2(float x, float y) {
            this.x = x;
            this.y = y;
        }
    }

    public class Vector3 {
        public float x, y, z;
        public Vector3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        static public float Distance(Vector3 a, Vector3 b) {
            return (float)Math.Sqrt(
                Math.Pow((double)a.x - b.x, 2.0) + 
                Math.Pow((double)a.y - b.y, 2.0) + 
                Math.Pow((double)a.z - b.z, 2.0)
            );
        }
    }
}
