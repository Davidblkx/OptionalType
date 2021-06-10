using Xunit;
using System.Optional;

using static System.Optional.Option;

namespace Optional.Tests.Extensions
{
    public class FunctionalExtensionsTests
    {
        [Fact]
        public void Should_Map_To_Some()
        {
            var subject = Some("Hello");
            var target1 = subject.Map(_ => true, () => false).ValueOrFail();
            var target2 = subject.MapSome(_ => true).ValueOrFail();

            Assert.True(target1);
            Assert.True(target2);
        }

        [Fact]
        public void Should_Map_To_None()
        {
            var subject = None<string>();
            var target1 = subject.Map(_ => true, () => false).ValueOrFail();
            var target2 = subject.MapNone(() => false).ValueOrFail();

            Assert.False(target1);
            Assert.False(target2);
        }

        [Fact]
        public void Should_Merge_On_Some()
        {
            var target = Some("A")
                .Merge("B", (a, b) => a + b)
                .ValueOrFail();

            Assert.Equal("AB", target);
        }

        [Fact]
        public void Should_Not_Merge_On_Some()
        {
            var target = Some("A")
                .MergeOption(None<string>(), (a, b) => a + b)
                .MapNone(() => false)
                .ValueOrFail();

            Assert.False(target);
        }
    }
}
