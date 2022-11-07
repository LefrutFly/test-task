using UnityEngine;

public static class Saver
{
    private const string KEY = "player_saves";

    public static void SaveCountTry(int count)
    {
        SaveData saveData;

        if (PlayerPrefs.HasKey(KEY))
        {
            saveData = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(KEY));
        }
        else
        {
            saveData = new SaveData();
        }

        saveData.countTry = count;

        string json = JsonUtility.ToJson(saveData);

        PlayerPrefs.SetString(KEY, json);

        PlayerPrefs.Save();
    }

    public static int LoadCountTry()
    {
        SaveData saveData;
        int count;

        if (PlayerPrefs.HasKey(KEY))
        {
            saveData = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString(KEY));

            count = saveData.countTry;
        }
        else
        {
            count = 0;
        }

        return count;
    }
}