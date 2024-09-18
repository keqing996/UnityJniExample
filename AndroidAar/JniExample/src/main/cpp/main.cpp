#include <jni.h>
#include <android/log.h>

static const char* jniString = "Hello from JNI";

extern "C"
JNIEXPORT jstring JNICALL StringFromJNI(JNIEnv* pEnv, jobject clazz)
{
    return pEnv->NewStringUTF(jniString);
}

extern "C"
JNIEXPORT void JNICALL
LogcatFromJNI(JNIEnv* pEnv, jobject thiz, jstring tag, jstring message)
{
    const char* tagNativeString = pEnv->GetStringUTFChars(tag, 0);
    const char* messageNativeString = pEnv->GetStringUTFChars(message, 0);

    ::__android_log_print(ANDROID_LOG_INFO, tagNativeString, "%s", messageNativeString);

    pEnv->ReleaseStringUTFChars(tag, tagNativeString);
    pEnv->ReleaseStringUTFChars(message, messageNativeString);
}

jint JNI_OnLoad(JavaVM* pVm, void* reserved)
{
    JNIEnv * env;
    pVm->GetEnv((void**)&env,JNI_VERSION_1_6);

    JNINativeMethod methods[] ={
            { "stringFromJNI", "()Ljava/lang/String;",(void*)StringFromJNI },
            { "logcatFromJNI", "(Ljava/lang/String;Ljava/lang/String;)V",(void*)LogcatFromJNI },
    };

    env->RegisterNatives(env->FindClass("com/example/jni/ExampleJavaClass"), methods, 2);
    return JNI_VERSION_1_6;
}
