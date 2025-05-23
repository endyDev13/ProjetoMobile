using UnityEngine;

public class IAGameManager : MonoBehaviour
{
    public static int IA_Lvl = 0;

    private void Update()
    {
        // Detecta tecla F e aumenta o nível em 1
        if (Input.GetKeyUp(KeyCode.F))
        {
            AumentarNivel();
        }
    }

    public static void AumentarNivel()
    {
        IA_Lvl++;
        Debug.Log("IA_Lvl aumentado para: " + IA_Lvl);
    }

    public static void SetNivel(int novoNivel)
    {
        IA_Lvl = novoNivel;
        Debug.Log("IA_Lvl definido para: " + IA_Lvl);
    }
}
