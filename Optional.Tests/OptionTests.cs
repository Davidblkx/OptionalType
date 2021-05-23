using Xunit;

using static System.Optional.Option;

namespace Optional.Tests
{
    public class OptionTests
    {
        [Fact]
        public void Option_Init_Null()
        {
            var subject1 = Some(null);
            var subject2 = Some<string>(null);
            var subject3 = None();
            var subject4 = None<string>();

            Assert.False(subject1.HasValue());
            Assert.False(subject1.TryGetValue(out _));
            Assert.False(subject2.HasValue());
            Assert.False(subject2.TryGetValue(out _));
            Assert.False(subject3.HasValue());
            Assert.False(subject3.TryGetValue(out _));
            Assert.False(subject4.HasValue());
            Assert.False(subject4.TryGetValue(out _));
        }

        [Fact]
        public void Option_Init_object_Value()
        {
            var subject = Some("text" as object);
            Assert.True(subject.HasValue());
            Assert.True(subject.TryGetValue(out var text));
            Assert.Equal("text", text);
        }

        [Fact]
        public void Option_Init_type_Value()
        {
            var subject = Some("text");
            Assert.True(subject.HasValue());
            Assert.True(subject.TryGetValue(out var text));
            Assert.Equal("text", text);
        }

        [Fact]
        public void Option_Cast()
        {
            object value = "";
            var subject1 = Some(value);

            Assert.True(subject1.ToType<string>().HasValue());
            Assert.False(subject1.ToType<int>().HasValue());
        }
    }
}
