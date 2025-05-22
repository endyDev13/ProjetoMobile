using UnityEngine;
using Unity.Cinemachine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerBoyPrefab;
    public GameObject playerGirlPrefab;

    public CinemachineCamera virtualCamera; // arraste sua c�mera aqui no Inspector

    public static string PlayerSkin = "";
    private static bool hasSpawned = false;

    void Start()
    {
        if (hasSpawned) return;

        GameObject prefabToSpawn = null;

        if (PlayerSkin == "Boy")
            prefabToSpawn = playerBoyPrefab;
        else if (PlayerSkin == "Girl")
            prefabToSpawn = playerGirlPrefab;

        if (prefabToSpawn != null)
        {
            GameObject playerInstance = Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            hasSpawned = true;

            // Atribui PlayerManager ao PuzzleBooksButtons
            PlayerManager pm = playerInstance.GetComponent<PlayerManager>();
            PuzzleBooksButtons puzzleBooks = FindAnyObjectByType<PuzzleBooksButtons>();
            if (puzzleBooks != null && pm != null)
            {
                puzzleBooks.SetPlayerManager(pm);
            }
            else
            {
                Debug.LogError("N�o foi poss�vel conectar o PlayerManager ao PuzzleBooksButtons.");
            }
            // Faz a Cinemachine seguir o jogador instanciado
            if (virtualCamera != null)
            {
                virtualCamera.Follow = playerInstance.transform;
                virtualCamera.LookAt = playerInstance.transform; // opcional, se usar LookAt
            }
            else
            {
                Debug.LogWarning("Virtual Camera n�o atribu�da no PlayerSpawn.");
            }
        }
        else
        {
            Debug.LogWarning("Nenhum personagem selecionado para spawn.");
        }
    }
}
