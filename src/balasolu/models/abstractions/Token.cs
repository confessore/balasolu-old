using balasolu.converters;
using balasolu.models.enums;
using balasolu.models.interfaces;
using System.Text.Json.Serialization;

namespace balasolu.models.abstractions
{
    [JsonConverter(typeof(TokenConverter))]
    public abstract class Token : Entity<string>, IToken
    {
        [JsonConstructor]
        public Token() { }

        public TokenType TokenType { get; set; }
        public string? Hash { get; set; }
        public long Expiration { get; set; }


        public virtual string? UserId { get; set; }
    }
}
