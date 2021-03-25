using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;

public class APIcall : MonoBehaviour
{
    public Text Advice_text;

    [System.Serializable]
    public class Slip
    {
        public int id;
        public string advice;
    }

    [System.Serializable]
    public class Advice
    {
        public Slip slip;
    }


    public Advice RecievedAdvice = new Advice();

    private void Awake()
    {
        StartCoroutine(GetRequest("https://api.adviceslip.com/advice"));
    }

    private void Start()
    {
        Invoke("updateText", 2);
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();
          RecievedAdvice =  JsonUtility.FromJson<Advice>(webRequest.downloadHandler.text);
        }
    }

    public void updateText()
    {
        Advice_text.text = RecievedAdvice.slip.advice;
    }



}
