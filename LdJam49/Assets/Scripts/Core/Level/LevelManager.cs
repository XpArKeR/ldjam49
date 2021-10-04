using System.Collections.Generic;

using Assets.Scripts;

public class LevelManager
{
    private static List<Level> levels;

    public static List<Level> GetLevels()
    {
        if (levels == default)
        {
            levels = LoadLevels();
        }
        return levels;
    }

    private static List<Level> LoadLevels()
    {
        if (Core.IsFileAccessPossible)
        {
            var filePath = System.IO.Path.Combine("Resources", "Data", "Levels.json");

            return JasonHandler.DeserializeObjectFromFile<List<Level>>(filePath);
        }
        else
        {
            return JasonHandler.DeserializeObject<List<Level>>(LevelDump.GetLevelsString());
        }
    }

    public static Level GetLevel(string name)
    {
        if (name == default)
        {
            return GetLevels()[0];
        }

        for (int i = 0; i < GetLevels().Count; i++)
        {
            Level level = GetLevels()[i];
            if (level.Name.Equals(name))
            {
                return level;
            }
        }
        throw new LevelNotFoundException("Level with name not found: " + name);
    }

    public static Level GetNextLevel(string name)
    {
        if (name == default)
        {
            return GetLevels()[0];
        }

        for (int i = 0; i < GetLevels().Count; i++)
        {
            Level level = GetLevels()[i];
            if (level.Name.Equals(name))
            {
                if (i == GetLevels().Count - 1)
                {
                    return null;
                }
                return GetLevels()[i + 1];
            }
        }
        throw new LevelNotFoundException("Level with name not found: " + name);
    }
}
