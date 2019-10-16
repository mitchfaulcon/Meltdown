using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class HighScoreManager : MonoBehaviour
{
    public GameObject level1Scores;
    public GameObject level2Scores;
    public GameObject level3Scores;
    private List<GameObject> levelScores = new List<GameObject>();

    private static List<int> level1HighScoreList = new List<int>();
    private static List<int> level2HighScoreList = new List<int>();
    private static List<int> level3HighScoreList = new List<int>();
    private static List<List<int>> highScoreLists = new List<List<int>>();
    
    // On start, get current high scores and set the high score screen to display as text
    void Start()
    {
        levelScores.Add(level1Scores);
        levelScores.Add(level2Scores);
        levelScores.Add(level3Scores);

        highScoreLists.Add(level1HighScoreList);
        highScoreLists.Add(level2HighScoreList);
        highScoreLists.Add(level3HighScoreList);

        //Initialise scores for all level scoreboards
        foreach (List<int> highScoreList in highScoreLists)
        {
            int index = highScoreLists.IndexOf(highScoreList);
            highScoreList.Clear();

            //Init top 5 high scores (Default values to 0 in case none are available)
            string levelKey = "level" + (index + 1).ToString() + "Highscore";
            int highscore1 = PlayerPrefs.GetInt(levelKey + "1", 0);
            int highscore2 = PlayerPrefs.GetInt(levelKey + "2", 0);
            int highscore3 = PlayerPrefs.GetInt(levelKey + "3", 0);
            int highscore4 = PlayerPrefs.GetInt(levelKey + "4", 0);
            int highscore5 = PlayerPrefs.GetInt(levelKey + "5", 0);

            //Write highscores to the highscore list
            highScoreList.Add(highscore1);
            highScoreList.Add(highscore2);
            highScoreList.Add(highscore3);
            highScoreList.Add(highscore4);
            highScoreList.Add(highscore5);

            //Order from highest to lowest
            highScoreList.Sort();
            highScoreList.Reverse();

            //Display top 5 high scores on the highscore board
            GameObject levelScoreList = levelScores.ElementAt(index);
            levelScoreList.GetComponent<TMP_Text>().text = (highScoreList[0].ToString() + "\n" +
                                                            highScoreList[1].ToString() + "\n" +
                                                            highScoreList[2].ToString() + "\n" +
                                                            highScoreList[3].ToString() + "\n" +
                                                            highScoreList[4].ToString());
        }
    }

    // When a new score is awarded, check to see if it is a highscore
    public static bool recieveNewScore(int level, int newScore)
    {
        //Set highscoreList & string key to look for in PlayerPrefs depending on level
        List<int> highScoreList = highScoreLists.ElementAt(level - 1);
        string preferencesKey = "level" + level.ToString() + "Highscore";
        
        // Add new score to the list and sort from high to low
        highScoreList.Add(newScore);
        highScoreList.Sort();
        highScoreList.Reverse();

        // Save top 5 high scores to player prefs
        PlayerPrefs.SetInt(preferencesKey + "1", highScoreList[0]);
        PlayerPrefs.SetInt(preferencesKey + "2", highScoreList[1]);
        PlayerPrefs.SetInt(preferencesKey + "3", highScoreList[2]);
        PlayerPrefs.SetInt(preferencesKey + "4", highScoreList[3]);
        PlayerPrefs.SetInt(preferencesKey + "5", highScoreList[4]);
        PlayerPrefs.Save();

        // If the new score is the best ever, return true
        if (newScore >= highScoreList.Max())
        {
            return true;
        }
        return false;
    }

    public void DeleteHighScores()
    {
        PlayerPrefs.DeleteAll();

        //Refresh score display
        Start();
    }
}
