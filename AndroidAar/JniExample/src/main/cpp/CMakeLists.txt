cmake_minimum_required(VERSION 3.22.1)

project("jni_example")

add_library(${CMAKE_PROJECT_NAME} SHARED
    main.cpp)

target_link_libraries(${CMAKE_PROJECT_NAME}
    android
    log)
