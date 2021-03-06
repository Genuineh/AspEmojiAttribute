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
            var res = "Hello ๐๐๐๐คฃ๐๐๐ there".GetEmojis();
            Assert.Equal(7, res.Count);
            res = "Hello โค๏ธ there".GetEmojis();
            Assert.Equal(1, res.Count);
            //in unicode 14.0 is 3
            res = "Hello ๐จโ๐จโ๐งโ๐ง๐จโ๐จโ๐งโ๐ง๐จโ๐จโ๐งโ๐ง there".GetEmojis();
            Assert.Equal(3, res.Count);
            //in unicode 14.0 is 1
            res = "Hello ๐ฉ๐ฝโ๐ there".GetEmojis();
            Assert.Equal(1, res.Count);
            res = "Hello ๐ฉ๐ปโ๐คโ๐จ๐ฟ there".GetEmojis();
            Assert.Equal(1, res.Count);
            res = "๐ฏ".GetEmojis();
            Assert.Equal(1, res.Count);
            res = "๐๐ผโโ".GetEmojis();
            Assert.Equal(1, res.Count);
            res = "๐ฅฒ ok".GetEmojis();
            Assert.Equal(1, res.Count);
        }

        [Fact]
        public void ReplaceEmojis_ReplaceByEmptyStr_Pass()
        {
            var test = "Hello ๐๐๐๐คฃ๐๐๐ there";
            var res = test.GetEmojis();
            Assert.Equal(7, res.Count);
            var replace = test.ReplaceEmojis();
            Assert.Equal(12, replace.Length);
        }
    }
}
