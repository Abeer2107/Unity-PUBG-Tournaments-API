using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using JSONData;

public class TournamentController : MonoBehaviour
{  
    private const string API_URL = "https://api.pubg.com/tournaments";
    private const float API_MAXTIME = 10 * 60.0f; //10 minutes
    private const string API_KEY = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJqdGkiOiI4ODQ2NjViMC0zMWM4LTAxMzktZTMwZS01YjI4Nzc4ZWU4MTgiLCJpc3MiOiJnYW1lbG9ja2VyIiwiaWF0IjoxNjA5ODgxMTAyLCJwdWIiOiJibHVlaG9sZSIsInRpdGxlIjoicHViZyIsImFwcCI6InRvdXJuYW1lbnRzLXRlIn0.87MsaXUUXzZ_E-ELr4SilCF0F8qL8aXcP7p_OJ9C17Q";
    private float apiCountdown = API_MAXTIME;

    [SerializeField] TournamentView view;
    Root responseItems;

    private void Start()
    {
        StartCoroutine(getTournaments());
    }

    //void Update()
    //{
    //    apiCountdown -= Time.deltaTime;
    //    if (apiCountdown <= 0)
    //    {
    //        StartCoroutine(getTournaments());
    //        apiCountdown = API_MAXTIME;
    //    }
    //}

    public Dictionary<string, string> getTournamentList()
    { //Return a dictionary of <id, createdAt>
        Dictionary<string, string> res = new Dictionary<string, string>();
        foreach(Data item in responseItems.data) //Send event when response is ready!!
        {
            res.Add(item.id, item.attributes.createdAt);
        }
        return res;
    }

    public IEnumerator getTournaments()
    {
        UnityWebRequest www = UnityWebRequest.Get(API_URL);

        //Request Headers
        www.SetRequestHeader("Accept", "application/vnd.api+json"); 
        www.SetRequestHeader("Authorization", string.Format("Bearer {0}", API_KEY));

        yield return www.SendWebRequest();

        if (www.isNetworkError)
        {
            Debug.Log("ERROR: " + www.error);
        }
        else
        {
            //Debug.Log(www.downloadHandler.text);
            responseItems = JsonUtility.FromJson<Root>(www.downloadHandler.text);

            view.populateView(getTournamentList()); //Err~
        }
    }
}
