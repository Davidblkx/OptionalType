using Xunit;
using System;
using System.Optional;

using static System.Optional.Option;

namespace Optional.Tests.Extensions
{
    public class ValueExtensionsTests
    {
        [Fact]
        public void Value_Or_Fail()
        {
            var subject1 = Some<string>(null);
            var subject2 = Some("TEXT");

            Assert.Throws<NullReferenceException>(() => subject1.ValueOrFail());
            Assert.Equal("TEXT", subject2.ValueOrFail());
        }

        [Fact]
        public void Value_Or()
        {
            var subject1 = Some<string>(null);
            var subject2 = Some("TEXT");

            Assert.Equal("", subject1.ValueOr(""));
            Assert.Equal("TEXT", subject2.ValueOrFail());
        }

        [Fact]
        public void Reduce()
        {
            var subject1 = Some(24.2345m);
            var subject2 = None<decimal>();

            var target1 = subject1.Map(v => (int)Math.Floor(v), () => 0);
            var target2 = subject2.Map(v => (int)Math.Floor(v), () => 0);

            Assert.Equal(24, target1.ValueOrFail());
            Assert.Equal(0, target2.ValueOrFail());
        }
    }
}
