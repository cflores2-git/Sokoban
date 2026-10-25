using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public PlayerController player;
    public Goal[] goals;
    public GameObject completionPanel;
    public string nextScene;
    private bool completed;
    public Coins[] collectibles;
    public TMP_Text resultsText;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (completionPanel == null)
        {
            return;
        }
        completionPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(!completed && completionPanel !=null)
        {
            timer += Time.deltaTime;
        }
    }
    void LateUpdate()
    {
        if (completed || goals.Length == 0||completionPanel == null)
        {
            return;
        }
        Physics2D.SyncTransforms();
        foreach(Goal goal in goals)
        {
            if(Physics2D.OverlapPoint(goal.transform.position,goal.boxesLayer)==null)
            return;
        }
        completed = true;
        player.enabled = false;
        int stars = 0;
        foreach (Coins coin in collectibles)
        {
            if (coin.collected)
            {
                stars++;
            }
            resultsText.text = "Stars: " + stars + "/3" + "\nMoves: " + player.moves + "\nTime: " + timer.ToString("F1") + " seconds";
        }
        completionPanel.SetActive(true);
    }
    public void Continue()
    {
        if(!string.IsNullOrWhiteSpace(nextScene))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
