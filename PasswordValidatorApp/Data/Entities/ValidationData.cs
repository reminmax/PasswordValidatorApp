using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordValidatorApp.Data.Entities
{
    public struct ValidationData
    {
        public char SearchCharacter { get; private set; }
        public byte MinimumNumberOfOccurrences { get; private set; }
        public byte MaximumNumberOfOccurrences { get; private set; }
        public string PasswordString { get; private set; }

        public ValidationData(
            char searchCharacter,
            byte minimumNumberOfOccurrences,
            byte maximumNumberOfOccurrences,
            string passwordString)
        {
            SearchCharacter = searchCharacter;
            MinimumNumberOfOccurrences = minimumNumberOfOccurrences;
            MaximumNumberOfOccurrences = maximumNumberOfOccurrences;
            PasswordString = passwordString;
        }
    }
}
