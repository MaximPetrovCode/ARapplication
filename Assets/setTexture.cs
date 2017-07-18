using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setTexture : MonoBehaviour {
    private string imageUrl = "http://augmentedreality-augmentedreality.1d35.starter-us-east-1.openshiftapps.com/uploads/imgs/target.jpg";
    private string url = "http://augmentedreality-augmentedreality.1d35.starter-us-east-1.openshiftapps.com/uploads/description/text.html";
    private string textString;

    public int fontSize;
    // Use this for initialization
    IEnumerator Start()
    {
        
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW wwwText = new WWW(imageUrl);
        yield return wwwText;
        wwwText.LoadImageIntoTexture(tex);
        GetComponent<Renderer>().material.mainTexture = tex;


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



        GameObject text = new GameObject();
        text.transform.parent = transform;

        TextMesh t = text.AddComponent<TextMesh>();

        t.text = textString;
        //t.text = "Hellow AR!";
        t.fontSize = 15;
        t.color = Color.black;

        text.transform.rotation = this.transform.rotation;
        text.transform.position = this.transform.position;
        text.transform.Rotate(90, 180, text.transform.rotation.z);
        text.transform.position = new Vector3(text.transform.position.x - 0.5f , text.transform.position.y +1 , text.transform.position.z );
        text.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

}