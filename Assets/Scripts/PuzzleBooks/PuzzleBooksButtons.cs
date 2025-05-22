using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleBooksButtons : MonoBehaviour
{
    public string answer = "";
    public string correct = "";
    public Sprite btOn;
    public GameObject[] bts;
    public GameObject[] books;
    public int i = -1;
    public GameObject backgroundCabinets;
    public Animator animDoor;
    public GameObject colDoor;
    public bool[] booksCorrects;


    public GameObject [] obj_Letras;
    public GameObject[] obj_LibrasLetra;
    public GameObject[] certos;

    private PlayerManager playerManager;

    public void SetPlayerManager(PlayerManager pm)
    {
        playerManager = pm;
    }

    private void Start()
    {
        if (playerManager == null)
        {
            playerManager = FindAnyObjectByType<PlayerManager>();
            if (playerManager == null)
                Debug.LogError("PlayerManager não foi encontrado!");
        }
        i = -1;
    }
    public void BtC()
    {
        answer = "C";
        backgroundCabinets.SetActive(false); 
        playerManager.HideCabinets();

        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }

        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            PlayerManager.cabinetsActive = false;

            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }
    public void BtC_libras()
    {
        Debug.Log("CCCCCCCCCC");
        answer = "C_Libras";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();

        if (answer == correct)
        {
            obj_Letras[0].SetActive(false);
            obj_LibrasLetra[2].SetActive(false);
            certos[1].SetActive(true);
            certos[4].SetActive(true);

            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            booksCorrects[0] = true;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            PlayerManager.cabinetsActive = false;

            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }
    public void BtF_libras()
    {
        answer = "F_Libras";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();

        if (answer == correct)
        {
            obj_LibrasLetra[0].SetActive(false);
            obj_LibrasLetra[1].SetActive(false);
            certos[0].SetActive(true);
            certos[2].SetActive(true);
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            booksCorrects[3] = true;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            PlayerManager.cabinetsActive = false;
            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }
    public void BtG()
    {
        answer = "G";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();

        if (answer == correct)
        {
            obj_Letras[1].SetActive(false);
            obj_LibrasLetra[3].SetActive(false);
            certos[3].SetActive(true);
            certos[5].SetActive(true);
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            booksCorrects[2] = true;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            PlayerManager.cabinetsActive = false;
            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }
    public void BtG_libras()
    {
        answer = "G_Libras";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();
        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            PlayerManager.cabinetsActive = false;
            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }
    public void BtT_libras()
    {
        answer = "T_Libras";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();
        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            
            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            backgroundCabinets.SetActive(false);
            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }
    public void BtV()
    {
        answer = "V";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();
        if (answer == correct)
        {
            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            PlayerManager.cabinetsActive = false;
            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }
    public void BtY()
    {
        answer = "Y";
        backgroundCabinets.SetActive(false);
        playerManager.HideCabinets();
        if (answer == correct)
        {
            obj_Letras[2].SetActive(false);
            obj_Letras[3].SetActive(false);
            certos[6].SetActive(true);
            certos[7].SetActive(true);

            i++;
            bts[i].GetComponent<SpriteRenderer>().sprite = btOn;
            PlayerManager.cabinetsActive = false;
            ItemPickUp.CanAnswerPuzzle = false;

            booksCorrects[1] = true;

            if (i == 3)
            {
                animDoor.Play("DoorOpen");
                colDoor.gameObject.SetActive(false);
            }
        }
        else
        {
            ItemPickUp.CanAnswerPuzzle = false;
            PlayerManager.cabinetsActive = false;
            switch (correct)
            {
                case "C_Libras":
                    books[0].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "Y":
                    books[1].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "G":
                    books[2].gameObject.SetActive(true);
                    correct = "";
                    break;
                case "F_Libras":
                    books[3].gameObject.SetActive(true);
                    correct = "";
                    break;
            }
        }
    }


}
