using System;
using Xunit;
using AspEmojiAttribute;

namespace UnitTest
{
    public class EmojiHelperTests
    {
        [Fact]
        public void GetEmojis_InputMultipleEmoji_Pass()
        {
            var res = "Hello 😀😁😂🤣😃😄😅 there".GetEmojis();
            Assert.Equal(7, res.Count);
            res = "Hello ❤️ there".GetEmojis();
            Assert.Equal(1, res.Count);
            //in unicode 14.0 is 3
            res = "Hello 👨‍👨‍👧‍👧👨‍👨‍👧‍👧👨‍👨‍👧‍👧 there".GetEmojis();
            Assert.Equal(3, res.Count);
            //in unicode 14.0 is 1
            res = "Hello 👩🏽‍🚒 there".GetEmojis();
            Assert.Equal(1, res.Count);
            res = "Hello 👩🏻‍🤝‍👨🏿 there".GetEmojis();
            Assert.Equal(1, res.Count);
            res = "🔯".GetEmojis();
            Assert.Equal(1, res.Count);
            res = "🙋🏼‍♀".GetEmojis();
            Assert.Equal(1, res.Count);
            res = "🥲 ok".GetEmojis();
            Assert.Equal(1, res.Count);
        }

        [Fact]
        public void ReplaceEmojis_ReplaceByEmptyStr_Pass()
        {
            var test = "Hello 😀😁😂🤣😃😄😅 there";
            var res = test.GetEmojis();
            Assert.Equal(7, res.Count);
            var replace = test.ReplaceEmojis();
            Assert.Equal(12, replace.Length);
        }
    }
}
