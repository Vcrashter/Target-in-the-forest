using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject winText; 
    [SerializeField] GameObject loseText;
    [SerializeField] GameObject quitButton;
    [SerializeField] GameObject restartButton;

    private int score = 0;
    private float timer = 0;

    private bool cancelInvoke = false;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, 1f);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 30f)
        {
            CancelInvoke(nameof(Spawn));
            cancelInvoke = true;
        }

        if (cancelInvoke == true)
        {
            if (score >= 28)
            {
                winText.SetActive(true);
            }
            else if (score < 28)
            {
                loseText.SetActive(true);
            }
            quitButton.SetActive(true);
            restartButton.SetActive(true);
        }

        Debug.Log(timer);
    }

    private void Spawn()
    {
        float xLoc = Random.Range(-9.46f, 9.89f);
        float yLoc = Random.Range(-4.32f, 4.28f);
        float zLoc = 91f;

        Vector3 randomLoc = new Vector3 (xLoc, yLoc, zLoc);

        Instantiate(target, randomLoc, Quaternion.identity);
    }

    public void IncrementScore()
    {
        score++;
        Debug.Log(score);
        scoreText.text = score.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}