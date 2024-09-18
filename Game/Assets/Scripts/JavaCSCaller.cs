
using UnityEngine;

public class JavaCSCaller : AndroidJavaProxy
{
    public JavaCSCaller() : base("com.example.jni.ICSharpInterface")
    {
    }
    
    void LogToCSharp(string message)
    {
        Debug.LogError(message);
    }
}
