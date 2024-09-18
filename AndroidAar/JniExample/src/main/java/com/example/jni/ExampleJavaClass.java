package com.example.jni;

public class ExampleJavaClass {

    static {
        System.loadLibrary("jni_example");
    }

    private ICSharpInterface _csharpInterface;

    public void setCSharpInterface(ICSharpInterface csCaller) {
        _csharpInterface = csCaller;
    }

    public void logToCSharp(String message) {
        if (_csharpInterface != null)
            _csharpInterface.LogToCSharp(message);
    }

    public String getStringFromJava() {
        return stringFromJNI();
    }

    public void logToLogcat(String tag, String message) {
        logcatFromJNI(tag, message);
    }

    private native String stringFromJNI();

    private native void logcatFromJNI(String tag, String message);
}
