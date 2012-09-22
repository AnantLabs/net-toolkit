@echo off
echo Build Shaders
echo =============
echo.

call "%~1\shader_compile.bat" "NET.Tools.WPF.Effects\Shader\NegativeShader"
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\HDRShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\MirrowShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\BlackWhiteShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\ReliefShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\WaveShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\GrayscaleShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\MotionBlurShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
Call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\ColorShiftShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\AlphaShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\PixelShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\TransparentColorShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\TransparentImageShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\DarkenImageShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\LightenImageShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\DifferenceImageShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\MultiplyImageShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\NegationDifferenceImageShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\OverlayHardlightImageShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\OverlaySoftlightImageShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\ExclusionImageShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\SkyShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\SkyColorShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\ColorSnowShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\BlackWhiteSnowShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\Shader\ImageShiftShader
if NOT "%ERRORLEVEL%" == "0" ( goto end )

call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\BandedSwirl           
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\Bloom                 
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\BrightExtract
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\ColorKeyAlpha         
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\ColorTone             
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\ContrastAdjust
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\DirectionalBlur       
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\Embossed              
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\Gloom
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\GrowablePoissonDisk   
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\InvertColor           
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\LightStreak
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\Magnify               
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\Monochrome            
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\Pinch
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\Pixelate              
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\Ripple                
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\Sharpen
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\SmoothMagnify         
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\Swirl                 
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\ToneMapping
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\ToonShader           
if NOT "%ERRORLEVEL%" == "0" ( goto end )
call "%~1\shader_compile.bat" NET.Tools.WPF.Effects\CodeComplex\Shader\ZoomBlur
if NOT "%ERRORLEVEL%" == "0" ( goto end )

:end

echo.
echo ============================
if "%ERRORLEVEL%" == "0" (
	echo Build successfully
) else (
	echo Build failed
)
echo ============================

exit /B %ERRORLEVEL%