# Introduction #

You need to compile the code the following programs:

  * Windows SDK Version 7.1
  * Visual Studio 2010
  * Inno Setup 5
  * HTML Help Workshop
  * Microsoft DirectX SDK (Nov. 2008, **must be this version!**)
  * Doxygen
  * Maven (2.2.1 or higher)

If you installed all this programs you must set the following environment variables (first: variable name; second: description; third: example):

  * MVN\_HOME: Maven Home Path (e. g. C:\maven\_2.2.1)
  * PATH-Variable: Add %MVN\_HOME%/bin
  * DOXY\_HOME: Doxygen Home Path (e. g. C:\doxygen)
  * DXSDK\_TOOLS: Utilities-Bin-Path (e. g. C:\Microsoft DirectX SDK (November 2008)\Utilities\bin\x86)
  * IS\_HOME: Inno Setup Home (e. g. C:\Inno Setup 5)
  * VS2008\_HOME: IDE Path to VS 2010 (e. g. C:\Microsoft Visual Studio 9.0\Common7\IDE)
  * WINSDK\_HOME: Windows SDK Home Path (e. g. C:\Microsoft SDKs\Windows\v7.1)

Now open the CMD window, navigate to the checked out folder and enter:
  * mvn clean install

Now the complete code will be build. If you have problems to build the code check the console output.