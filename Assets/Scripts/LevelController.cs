using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    private static int _level = 1;
    private static int _totalLevels = 3;

    private void OnEnable()
    {
        
    }

    private void Update()
    {
        Monster[] monsters = FindObjectsOfType<Monster>();
        foreach(Monster monster in monsters)
        {
            if (monster != null)
                return;
        }

        // all monsters have died
        // go to next level
        _level++;
        if (_level > 3)
            _level = 1;
        string nextLevelName = "Level" + _level;
        SceneManager.LoadScene(nextLevelName);
    }

}
