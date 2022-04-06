
namespace Main.Level
{
    public interface ILevelGroup
    {
        int totalLevels { get; }
        Level GetLevelPrefab(int idLevel);
    }
}