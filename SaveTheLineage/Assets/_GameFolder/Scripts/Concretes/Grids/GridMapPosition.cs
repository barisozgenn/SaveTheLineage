using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SaveTheLineage.Grids
{
    public struct GridMapPosition: System.IEquatable<GridMapPosition>
    {
        public int _x;
        public int _z;
        public GridMapPosition(int x, int z)
        {
            _x = x;
            _z = z;
        }

        public override bool Equals(object obj)//generated automatically for c# handling
        {
            return obj is GridMapPosition position &&
                   _x == position._x &&
                   _z == position._z;
        }

        public bool Equals(GridMapPosition other)//implement interface System.IEquatable
        {
            return this == other;
        }

        public override int GetHashCode()//generated automatically for c# handling
        {
            return System.HashCode.Combine(_x, _z);
        }

        public override string ToString()
        {
            return "x: " + _x + " z: " + _z;
        }

        public static bool operator == (GridMapPosition a, GridMapPosition b)//operator added for struct comparision
        {
            return a._x == b._x && a._z == b._z;
        }

        public static bool operator !=(GridMapPosition a, GridMapPosition b)//operator added for struct comparision
        {
            return !(a==b);
        }
    }
}

