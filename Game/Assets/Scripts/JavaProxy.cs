using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavaProxy
{
    private AndroidJavaObject _javaObject;
    private JavaCSCaller _javaCSCaller;

    public JavaProxy()
    {
        _javaCSCaller = new JavaCSCaller();
        _javaObject = new AndroidJavaObject("com.example.jni.ExampleJavaClass");
        if (_javaObject != null)
        {
            _javaObject.Call("setCSharpInterface", _javaCSCaller);
        }
    }

    public string GetStringFromJava()
    {
        return _javaObject.Call<string>("getStringFromJava");
    }

    public void LogToLogCat(string tag, string message)
    {
        _javaObject.Call("logToLogCat", tag, message);
    }

    public void LogToCSharpThroughJava(string message)
    {
        _javaObject.Call("logToCSharp", message);
    }
}
