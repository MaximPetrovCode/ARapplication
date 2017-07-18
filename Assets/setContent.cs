using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class setContent : MonoBehaviour
{

    public string url = "http://testapp-testapp.1d35.starter-us-east-1.openshiftapps.com";
    public string imageUrl = "http://testapp-testapp.1d35.starter-us-east-1.openshiftapps.com/uploads/imgs/target.jpg";
    public string textString;



    public IEnumerator DownloadText()
    {
        //Text Downloading
        WWW www = new WWW(url);
        yield return www;

        if (!string.IsNullOrEmpty(www.error))
        {
            Debug.Log(www.error);
        }
        else
        {
            //Debug.Log(www.text);
            textString = www.text;
        }



        GameObject plane = Instantiate(Resources.Load("EasyAR", typeof(GameObject))) as GameObject;
        GameObject text = new GameObject();
        TextMesh t = text.AddComponent<TextMesh>();


        //Texture downloading
        plane.GetComponent<Renderer>().material.mainTexture = null;
        WWW wwwImage = new WWW(imageUrl);
        yield return wwwImage;
        plane.GetComponent<Renderer>().material.mainTexture = wwwImage.texture;
        plane.transform.Rotate(plane.transform.rotation.x, 180, plane.transform.rotation.z);
        plane.transform.localScale -= new Vector3(0.5F, 0.5F, 0.5F);

        t.text = textString;
        //t.text = "Hellow AR!";
        t.fontSize = 30;
        t.color = Color.black;

        //text.transform.GetComponent<Renderer>().material.SetTexture();
        text.transform.rotation = plane.transform.rotation;
        text.transform.position = plane.transform.position;
        text.transform.Rotate(90, text.transform.rotation.y, text.transform.rotation.z);
        text.transform.position = new Vector3(text.transform.position.x - 7, text.transform.position.y, text.transform.position.z);
        text.transform.localScale = plane.transform.localScale;


    }

    // Use this for initialization
    void Start()
    {
        StartCoroutine(DownloadText());
    }
    // Update is called once per frame
    void Update()
    {
        //Caching.CleanCache();
        //StartCoroutine(DownloadText());
    }
}