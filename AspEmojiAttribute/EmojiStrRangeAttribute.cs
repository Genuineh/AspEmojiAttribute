using System.ComponentModel.DataAnnotations;

namespace AspEmojiAttribute
{
    /// <summary>
    ///     Check text range of length that with emoji
    /// </summary>
    /// <remarks>
    ///     1.One emoji will be considered one char
    /// </remarks>
    public class EmojiStrRangeAttribute : ValidationAttribute
    {
        private readonly int _minLength = 0;
        private readonly int _maxLength = 0;

        public EmojiStrRangeAttribute(int minLength, int maxLength, string errorMessage = "")
        {
            _minLength = minLength;
            _maxLength = maxLength;

            ErrorMessage = string.IsNullOrEmpty(errorMessage) 
                ? $"Input text should be in range [{_minLength}, {_maxLength}]" 
                : errorMessage;
        }

        /// <summary>
        ///     IsNullOrEmpty for Object? value that will be string type
        /// </summary>
        /// <param name="value">Input value</param>
        /// <param name="s">Converted string</param>
        /// <returns></returns>
        protected internal bool IsNullOrEmpty(object? value, out string s)
        {
            s = (string) (value ?? "");
          
            if (value == null)
                return true;
            
            return string.IsNullOrEmpty(s);
        }

        /// <inheritdoc />
        public override bool IsValid(object? value)
        {
            //if null or empty, should be deal with [Required] Attribute
            if (IsNullOrEmpty(value, out var s))
                return true;

            //get matched emojis array
            var emojis = s.GetEmojis();
            //get string except emoji
            var noEmojiStr = s.ReplaceEmojis();
            //get final count
            var allCount = emojis.Count + noEmojiStr.Length;

            return allCount >= _minLength && allCount <= _maxLength;
        }

    }
}
