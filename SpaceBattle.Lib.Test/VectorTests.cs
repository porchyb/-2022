﻿using System;
using SpaceBattle;
using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test
{
    public class VectorTests
    {
        [Fact]
        public void Constructor_Null_Error()
        {
            Assert.Throws<ArgumentException>(() => new Vector());
        }
        [Fact]
        public void Index_Index_Value()
        {
            Vector v = new(1, 2);
            Assert.Equal(v[1],2);
        }
        [Fact]
        public void Index_Value_Value()
        {
            Vector v = new(1, 2);
            v[1] = 3;
            Assert.Equal(v[1], 3);
        }
        [Fact]
        public void Add_V1andV2_V3()
        {
            Vector v1 = new(1, 2);
            Vector v2 = new(3, 4);

            Vector v3 = v1 + v2;

            Assert.Equal(v3, new Vector(4,6));
        }
        [Fact]
        public void Add_V1andV2_Error()
        {
            Vector v1 = new(1, 2, 3);
            Vector v2 = new(3, 4);

            Assert.Throws<ArgumentException>(() => v1 + v2);
        }
        [Fact]
        public void Sub_V1andV2_V3()
        {
            Vector v1 = new(1, 2);
            Vector v2 = new(3, 4);

            Vector v3 = v1 - v2;

            Assert.Equal(v3, new Vector(-2, -2));
        }
        [Fact]
        public void Sub_V1andV2_Error()
        {
            Vector v1 = new(1, 2, 3);
            Vector v2 = new(3, 4);

            Assert.Throws<ArgumentException>(() => v1 - v2);
        }
        [Fact]
        public void Mult_FLOATandV_W()
        {
            float a = 1.5f;
            Vector v = new(2, 4);

            Vector w = a * v;

            Assert.Equal(w, new Vector(3,6));
        }
        [Fact]
        public void Equal_V1andV2_true()
        {
            Vector v1 = new(1, 2);
            Vector v2 = new(1, 2);

            Assert.True(v1==v2);
        }
        [Fact]
        public void Equal_V1andV2_false()
        {
            Vector v1 = new(1, 2);
            Vector v2 = new(1, 3);

            Assert.False(v1 == v2);
        }
        [Fact]
        public void Equal_V1andV2_false_size()
        {
            Vector v1 = new(1, 2);
            Vector v2 = new(1, 2, 2);

            Assert.False(v1 == v2);
        }
        [Fact]
        public void Inequal_V1andV2_true()
        {
            Vector v1 = new(1, 2);
            Vector v2 = new(1, 3);

            Assert.True(v1 != v2);
        }
        [Fact]
        public void Inequal_V1andV2_false()
        {
            Vector v1 = new(1, 2);
            Vector v2 = new(1, 2);

            Assert.False(v1 != v2);
        }
        [Fact]
        public void GetHashCode_V1andV2_Success()
        {
            Vector v1 = new(1, 2);
            Vector v2 = new(1, 2);

            Assert.True(v1.GetHashCode() == v2.GetHashCode());
        }
        [Fact]
        public void GetHashCode_V1andV2_Fail()
        {
            Vector v1 = new(1, 2);
            Vector v2 = new(1, 3);

            Assert.False(v1.GetHashCode() == v2.GetHashCode());
        }
    }
}
