@echo off
echo Run Tests
echo =========
echo.

"%VS2008_HOME%\MSTest.exe" "/testcontainer:%~1" /noresults

echo.
echo ============================
if "%ERRORLEVEL%" == "0" (
	echo Tests OK
) else (
	echo Tests failed
)
echo ============================

exit /B %ERRORLEVEL%