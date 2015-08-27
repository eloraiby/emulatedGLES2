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
    emulated-gles2.h \
    gl_core.h

SOURCES += \
    emulated-gles2.c \
    gl_core.c
