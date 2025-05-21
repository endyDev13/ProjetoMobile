using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class UIReferences : MonoBehaviour
{
    public static UIReferences Instance;

    public GameObject checkListMin;
    public GameObject checkListMax;
    public bool minMax; // Controle de qual checklist est� ativa

    public GameObject bookRed;
    public GameObject bookGreen;
    public GameObject bookBlue;
    public GameObject bookYellow;

    public GameObject cabinets;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void Show()
    {
        minMax = !minMax; // Alterna entre os modos

        checkListMin.SetActive(minMax); // Ativa checklist m�nima se minMax = true
        checkListMax.SetActive(!minMax); // Ativa checklist m�xima se minMax = false

        PlayerManager.isMove = minMax; // Ativa movimento apenas se for checklist m�nima
    }
}
