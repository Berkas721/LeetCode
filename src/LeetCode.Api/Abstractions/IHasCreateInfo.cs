using LeetCode.Data.OwnedTypes;

namespace LeetCode.Abstractions;

public interface IHasCreateInfo
{
    public ActionInfo CreateInfo { get; }
}