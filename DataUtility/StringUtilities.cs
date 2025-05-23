using System.Collections.Generic;

namespace pure_unity_methods
{
    /// <summary>
    /// A collection of utility methods to manipulate strings in generic ways.
    /// </summary>
    public static class StringUtilities
    {
        public static string AddSpacesBeforeCapitals(string stringToConvert)
        {
            var sentence = new List<char>();
            const char space = ' ';

            for (var i = 0; i < stringToConvert.Length; i++)
            {
                var character = stringToConvert[i];
                
                if (char.IsUpper(character))
                {
                    if (i != 0)
                    {
                        sentence.Add(space);
                    }
                }

                sentence.Add(character);
            }

            return new string(sentence.ToArray());
        }
        
        /// <summary>
        /// Same as string.isNullOrEmpty only "{}" count as empty value
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static bool IsJsonNullOrEmpty(string json)
        {
            return string.IsNullOrEmpty(json) || json == "{}" || json == "{ }";
        }
    }
}
