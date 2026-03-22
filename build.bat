@echo off
title Phantom External Builder
echo ========================================
echo   Phantom External - Simple Builder
echo ========================================

:: Find CSC compiler
set "csc=C:\Windows\Microsoft.NET\Framework64\v4.0.30319\csc.exe"
if not exist "%csc%" set "csc=C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"

if not exist "%csc%" (
    echo [ERROR] C# Compiler (csc.exe) not found! 
    echo Please install .NET Framework 4.5 or later.
    pause
    exit
)

echo [1/2] Compiling files...
:: /target:winexe - build as Windows application (no console)
:: /out: - output filename
:: /r: - references to system libraries
:: external\*.cs - include all source files in the external folder
%csc% /target:winexe /out:PhantomExternal.exe /r:System.Windows.Forms.dll,System.Drawing.dll,System.Numerics.dll,System.dll external\*.cs

if %errorlevel% neq 0 (
    echo [ERROR] Compilation failed!
    pause
    exit
)

echo [2/2] Success! Created PhantomExternal.exe
echo ========================================
echo You can now run the game and then the cheat.
pause
