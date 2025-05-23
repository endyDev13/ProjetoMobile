using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;
    public Image iconPlayer;
    public Sprite boySprite;
    public Sprite girlSprite;
    private bool switchSettings = false;
    public TextMeshProUGUI namePlayer;
    [SerializeField] private GameObject player;

    private void Start()
    {
        if (PlayerSpawn.PlayerSkin == "Boy") iconPlayer.sprite = boySprite;
        else iconPlayer.sprite = girlSprite;
        namePlayer.text = ScreenCharacter.inputField.text.ToUpper(); // Atualiza o nome do jogador TUDO EM MAIÚSCULO

        if (player == null) 
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    public void SwitchSetting()
    {
        switchSettings = !switchSettings;

        if(!switchSettings) settingsPanel.SetActive(true);
        else settingsPanel.SetActive(false);
    }

    public void MenuScreen()
    {
        switchSettings = false; // Reseta o estado do switch
        PlayerSpawn.PlayerSkin = ""; // Limpa a skin do jogador
        ScreenCharacter.inputField.text = ""; // Limpa o campo de texto

        PlayerSpawn.hasSpawned = false; // Reseta o estado de spawn do jogador
        Destroy(player); // Destroi o jogador atual
        SceneManager.LoadScene("MenuScene"); // Carrega a cena do menu
    }
}
