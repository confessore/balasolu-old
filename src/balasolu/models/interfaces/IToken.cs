using balasolu.models.enums;

namespace balasolu.models.interfaces
{
    public interface IToken
    {
        TokenType TokenType { get; set; }
        string? Hash { get; set; }
        long Expiration { get; set; }
    }
}
