using System;
using SpaceBattle;
using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test
{
    public class DegreeTests
    {
        [Fact]
        public void deg_plus_float_MoreThan360()
        {
            degree d1 = new(10);
            float f2 = 360;
            Assert.Equal(d1+f2, new degree(10));
        }
        [Fact]
        public void deg_plus_float_NoMoreThan360()
        {
            degree d1 = new(10);
            float f2 = 60;
            Assert.Equal(d1+f2, new degree(70));
        }
        [Fact]
        public void float_plus_deg_MoreThan360()
        {
            float f1 = 360;
            degree d2 = new(10);
            Assert.Equal(new degree(10), f1+d2);
        }
        [Fact]
        public void float_plus_deg_NpMoreThan360()
        {
            float f1 = 60;
            degree d2 = new(10);
            Assert.Equal(new degree(70), f1+d2);
        }
        [Fact]
        public void deg_minus_float_MoreThan360()
        {
            degree d1 = new(0);
            float f2 = 370;
            Assert.Equal(d1-f2, new degree(-10));
        }
        [Fact]
        public void deg_minus_float_NoMoreThan360()
        {
            degree d1 = new(0);
            float f2 = 70;
            Assert.Equal(d1-f2, new degree(-70));
        }
        [Fact]
        public void float_minus_deg_MoreThan360()
        {
            degree d2 = new(0);
            float f1 = 370;
            Assert.Equal(f1-d2, new degree(-10));
        }
        [Fact]
        public void float_minus_deg_NoMoreThan360()
        {
            degree d2 = new(0);
            float f1 = 60;
            Assert.Equal(f1-d2, new degree(-60));
        }  
        [Fact]
        public void Equality_DEGandDEG_true()
        {
            degree d1 = new(45);
            degree d2 = new(45);
            Assert.True(d1 == d2);
        }
        [Fact]
        public void Inequality_DEGandDEG_true()
        {
            degree d1 = new(45);
            degree d2 = new(60);
            Assert.True(d1 != d2);
        }
        [Fact]
        public void Inequality_DEGandDEG_false()
        {
            degree d1 = new(45);
            degree d2 = new(45);
            Assert.False(d1 != d2);
        }
        [Fact]
        public void Equals_DEGandDEG_true()
        {
            degree d1 = new(45);
            degree d2 = new(45);
            Assert.True(d1.Equals(d2));
        }
        [Fact]
        public void Equals_DEGandINT_false()
        {
            degree d1 = new(45);
            int a = 0; ;
            Assert.False(d1.Equals(a));
        }
        [Fact]
        public void GetHashCode_DEGandDEG_true()
        {
            degree d1 = new(45);
            degree d2 = new(45);
            Assert.Equal(d1.GetHashCode(), d2.GetHashCode());
        }
        [Fact]
        public void GetHashCode_DEGandDEG_false()
        {
            degree d1 = new(45);
            degree d2 = new(10);
            Assert.NotEqual(d1.GetHashCode(), d2.GetHashCode());
        }
    }
}
