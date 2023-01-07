using System;
using System.Linq;

namespace SpaceBattle.Lib
{
    public class Vector
    {
        public float[] vector;

        public Vector(params float[] nums)
        {
            int size = nums.Length;
            if (size == 0) throw new ArgumentException();
            vector = new float[size];
            for (int i = 0; i < size; i++)
            {
                vector[i] = nums[i];
            }
        }

        public int Size => vector.Length;

        public float this[int index]
        {
            get
            {
                return vector[index];
            }

            set
            {
                vector[index] = value;
            }
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            if(v1 is null || v2 is null) throw new ArgumentException();
            if (v1.Size != v2.Size) throw new ArgumentException();
            else
            {
                float[] arr = new float[v1.Size];
                for (int i = 0; i < v1.Size; i++)
                {
                    arr[i] = v1[i] + v2[i];
                }
                return new Vector(arr);
            }
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            if(v1 is null || v2 is null) throw new ArgumentException();
            if (v1.Size != v2.Size) throw new ArgumentException();
            else
            {
                float[] arr = new float[v1.Size];
                for (int i = 0; i < v1.Size; i++)
                {
                    arr[i] = v1[i] - v2[i];
                }
                return new Vector(arr);
            }
        }

        public static Vector operator *(float alfa, Vector v1)
        {
            if(v1 is null) throw new ArgumentException();
            float[] arr = new float[v1.Size];
            for (int i = 0; i < v1.Size; i++)
            {
                arr[i] = alfa * v1[i];
            }
            return new Vector(arr);
        }

        public static bool operator ==(Vector v1, Vector v2)
        {
            if (v1.Size != v2.Size) return false;
            for (int i = 0; i < v1.Size; i++)
            {
                if (v1[i] != v2[i]) return false;
            }
            return true;
        }

        public static bool operator !=(Vector v1, Vector v2) => !(v1 == v2);

        public override bool Equals(object? obj) => obj is Vector v && vector.SequenceEqual(v.vector);

        public override int GetHashCode()
        {
            return String.Join("", vector.Select(x => x.ToString())).GetHashCode();
        }
    }
}
