using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoMonoBehaviour : MonoBehaviour
{
    [SerializeField] public Button button1;
    [SerializeField] public Button button2;
    [SerializeField] public Button button3;
    
    private JavaProxy _javaProxy;

    void Start()
    {
        _javaProxy = new JavaProxy();
        
        button1.onClick.RemoveAllListeners();
        button1.onClick.AddListener(() =>
        {
            string message = _javaProxy.GetStringFromJava();
            Debug.LogError(message);
        });
        
        button2.onClick.RemoveAllListeners();
        button2.onClick.AddListener(() =>
        {
            _javaProxy.LogToLogCat("JniExample", "Message from C#!");
        });
        
        button3.onClick.RemoveAllListeners();
        button3.onClick.AddListener(() =>
        {
            _javaProxy.LogToCSharpThroughJava("Message C# -> Java -> C#");
        });
    }
}
