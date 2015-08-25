#-------------------------------------------------
#
# Project created by QtCreator 2015-08-25T19:51:34
#
#-------------------------------------------------

QT       -= core gui

TARGET = emulatedGLES2
TEMPLATE = lib
CONFIG += staticlib

SOURCES += emulatedgles2.cpp

HEADERS += emulatedgles2.h
unix {
    target.path = /usr/lib
    INSTALLS += target
}
