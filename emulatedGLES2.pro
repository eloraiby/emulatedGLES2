#-------------------------------------------------
#
# Project created by QtCreator 2015-08-25T19:51:34
#
#-------------------------------------------------

QT       -= core gui

TARGET = emulatedGLES2
TEMPLATE = lib
#CONFIG += staticlib


unix {
    target.path = /usr/lib
    INSTALLS += target
}

HEADERS += \
    gl_core_3_0.h \
    emulated-gles2.h

SOURCES += \
    gl_core_3_0.c \
    emulated-gles2.c
