using UnityEngine;
using Zork;
using Newtonsoft.Json;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private string ZorkGameFileAssetName = "Zork";
    [SerializeField]
    private UnityOuputService OuputService;
    [SerializeField]
    private UnityInputService InputService;
    [SerializeField]
    private TextMeshProUGUI CurrentLocationText;
    [SerializeField]
    private TextMeshProUGUI ScoreText;
    [SerializeField]
    private TextMeshProUGUI MovesText;

    public Game _game;
    private Room _previousLocation;

    void Awake()
    {
        TextAsset gameJsonAsset = Resources.Load<TextAsset>(ZorkGameFileAssetName);
        Game.Start(gameJsonAsset.text, InputService, OuputService);
        Game.Instance.CommandManager.PerformCommand(Game.Instance, "LOOK");
    }

    private void Update()
    {
        if (Game.Instance.IsRunning == false)
        {
            Game.Instance.Output.WriteLine("Thanks for playing!");
            Application.Quit();
        }
    }
    private void PlayerLocationChanged(object sender, Room newRoom)
    {
        CurrentLocationText.text = newRoom.ToString();
    }

}
