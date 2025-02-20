// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.Core
{
    /// <summary> The type of the pattern for an alias path. </summary>
    public partial class AliasPattern
    {
        /// <summary> Initializes a new instance of AliasPattern. </summary>
        internal AliasPattern()
        {
        }

        /// <summary> Initializes a new instance of AliasPattern. </summary>
        /// <param name="phrase"> The alias pattern phrase. </param>
        /// <param name="variable"> The alias pattern variable. </param>
        /// <param name="type"> The type of alias pattern. </param>
        internal AliasPattern(string phrase, string variable, AliasPatternType? type)
        {
            Phrase = phrase;
            Variable = variable;
            Type = type;
        }

        /// <summary> The alias pattern phrase. </summary>
        public string Phrase { get; }
        /// <summary> The alias pattern variable. </summary>
        public string Variable { get; }
        /// <summary> The type of alias pattern. </summary>
        public AliasPatternType? Type { get; }
    }
}
