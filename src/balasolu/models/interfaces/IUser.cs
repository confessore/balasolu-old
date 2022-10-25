using balasolu.models.abstractions;
using balasolu.models.enums;

namespace balasolu.models.interfaces
{
    public interface IUser
    {
        UserType UserType { get; set; }
        ICollection<Token>? Tokens { get; set; }
    }
}
