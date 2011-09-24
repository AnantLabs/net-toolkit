@echo off

del "%~1.ps"
"%DXSDK_TOOLS%\fxc.exe" /T ps_2_0 /E main "/Fo%~1.ps" "%~1.fx"