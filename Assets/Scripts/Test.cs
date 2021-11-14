using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text text;
    [DllImport(dllName: "__Internal")]
    public static extern void GetJSON(string path, string objectName, string callback, string fallback);
    private void Start()
    {
        GetJSON(path: "example", gameObject.name, callback: "OnRequestSuccess", fallback: "OnRequestFailed");
    }

    private void OnRequestSuccess(string data)
    {
        text.color = Color.green;
        text.text = data;
    }
    private void OnRequestFailed(string error)
    {
        text.color = Color.red;
        text.text = error;
    }
}
