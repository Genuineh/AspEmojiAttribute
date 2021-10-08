using System;
using Xunit;
using AspEmojiAttribute;

namespace UnitTest
{
    public class EmojiStrRangeAttributeTests
    {
        [Fact]
        public void EmojiStrRange_InputInRange_Pass()
        {
            var test = "Hello 😀😁😂🤣😃😄😅 there";
            var attr = new EmojiStrRangeAttribute(1, 19);
            Assert.True(attr.IsValid(test));
        }

        [Fact]
        public void EmojiStrRange_InputNotInRange_Fail()
        {
            var test = "Hello 😀😁😂🤣😃😄😅 there";
            var attr = new EmojiStrRangeAttribute(1, 18);
            Assert.False(attr.IsValid(test));
        }

        [Fact]
        public void EmojiStrRange_EmprtyOrNull_Pass()
        {
            var test = "";
            var attr = new EmojiStrRangeAttribute(1, 18);
            Assert.True(attr.IsValid(test));

            string? testNull = null;
            Assert.True(attr.IsValid(testNull));
        }
    }
}
