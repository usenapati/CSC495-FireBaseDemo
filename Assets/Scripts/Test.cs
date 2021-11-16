using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    public Text text;

    /// <summary>
    /// Gets JSON from a specified path
    /// Will return a snapshot of the JSON in the callback output
    /// </summary>
    /// <param name="path"> Database path </param>
    /// <param name="objectName"> Name of the gameobject to call the callback/fallback of </param>
    /// <param name="callback"> Name of the method to call when the operation was successful. Method must have signature: void Method(string output) </param>
    /// <param name="fallback"> Name of the method to call when the operation was unsuccessful. Method must have signature: void Method(string output). Will return a serialized FirebaseError object </param>
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
