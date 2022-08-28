using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance { get; private set; }


    private Button retryBtn;
    private Button mainMenuBtn;

    private void Awake()
    {
        Instance = this;

        retryBtn = transform.Find("retryBtn").GetComponent<Button>();
        mainMenuBtn = transform.Find("mainMenuBtn").GetComponent<Button>();

        retryBtn.onClick.AddListener(() =>
        {
            GameSceneManager.Load(GameSceneManager.Scene.GameScene);
        });

        mainMenuBtn.onClick.AddListener(() =>
        {
            GameSceneManager.Load(GameSceneManager.Scene.MainMenuScene);
        });

        Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);

        transform.Find("wavesSurvivedText").GetComponent<TextMeshProUGUI>().SetText("Toy Survived " + EnemyWaveManager.instance.GetWaveNumber() + " Waves!");
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}