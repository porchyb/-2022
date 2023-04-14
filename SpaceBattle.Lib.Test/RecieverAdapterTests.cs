using System;
using SpaceBattle;
using Xunit;
using Moq;
using System.Collections.Concurrent;

namespace SpaceBattle.Lib.Test
{
    public class RecieverAdapterTests
    {
        [Fact]
        public void IsEmpty_Empty_True()
        {
            BlockingCollection<ICommand> queue = new();
            RecieverAdapter adapter = new(queue);
            Assert.True(adapter.IsEmpty());
        }

        [Fact]
        public void IsEmpty_NotEmpty_False()
        {
            BlockingCollection<ICommand> queue = new();
            Mock<ICommand> cmd = new();
            queue.Add(cmd.Object);
            RecieverAdapter adapter = new(queue);
            
            Assert.False(adapter.IsEmpty());
        }

        [Fact]
        public void Put_Command_Success()
        {
            BlockingCollection<ICommand> queue = new();
            RecieverAdapter adapter = new(queue);
            Mock<ICommand> cmd = new();
            adapter.Put(cmd.Object);
            Assert.False(adapter.IsEmpty());
        }

        [Fact]
        public void Receive_Void_Command()
        {
            BlockingCollection<ICommand> queue = new();
            Mock<ICommand> cmd = new();
            queue.Add(cmd.Object);
            RecieverAdapter adapter = new(queue);
            adapter.Receive();
            Assert.True(adapter.IsEmpty());
        }
    }
}
