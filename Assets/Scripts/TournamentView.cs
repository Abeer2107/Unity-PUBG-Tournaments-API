using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TournamentView : MonoBehaviour
{
    [SerializeField] GameObject idTextPrefab;
    [SerializeField] GameObject dateTextPrefab;

    public void populateView(Dictionary<string, string> data)
    {
        for(int i = 0; i < data.Count; i++)
        {
            GameObject currentID = Instantiate(idTextPrefab, transform);
            currentID.SetActive(false);
            currentID.GetComponent<Text>().text = data.Keys.ElementAt(i);
            currentID.SetActive(true);

            GameObject currentDate = Instantiate(dateTextPrefab, transform);
            currentDate.SetActive(false);
            currentDate.GetComponent<Text>().text = data.Values.ElementAt(i);
            currentDate.SetActive(true);
        }
    }
}
