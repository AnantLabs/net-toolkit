@echo off
echo Build XSD Classes
echo =================
echo.
"%WINSDK_HOME%\bin\xsd.exe" %1 /c "/namespace:%~2" "/o:%~3"
echo.
echo ======================================
if "%ERRORLEVEL%" == "0" (
	echo Successfully!
) else (
	echo Failed!
)
echo ======================================

exit /B %ERRORLEVEL%