using System;
using SpaceBattle;
using Xunit;
using Moq;

namespace SpaceBattle.Lib.Test
{
    public class DegreeTests
    {
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
