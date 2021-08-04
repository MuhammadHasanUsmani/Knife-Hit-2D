using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject restartButton;
    private int knifeIconIndexToChange = 0;
    [Header("Knife Count Display")] //header for organization purposes
    //[SerializeField]
    public GameObject panelKnives;
    [SerializeField]
    //this will be set to the icon prefab
    private GameObject iconKnife;
    [SerializeField]
    private Color usedKnifeIconColor;

    //enable the restartButton game object
    public void ShowRestartButton()
    {

        Score.instance.SetHighScore(Score.instance.GetScore());
        restartButton.SetActive(true);
    }

    //add a number of iconKnife children to panelKnives
    public void SetInitialDisplayedKnifeCount(int count)
    {
        foreach (Transform child in panelKnives.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        knifeIconIndexToChange = 0;
        for (int i = 0; i < count; i++)
            Instantiate(iconKnife, panelKnives.transform);
    }

    //keeping track of the last icon representing an unthrown knife
    
    //changing the color of the image to represent a thrown (used) knife
    public void DecrementDisplayedKnifeCount()
    {
        
        if (knifeIconIndexToChange < panelKnives.transform.childCount)
        panelKnives.transform.GetChild(knifeIconIndexToChange++)
            .GetComponent<Image>().color = usedKnifeIconColor;
    }
}
