@echo off
if exist "%TEMP%" rd /S /Q "%TEMP%" >nul 2>nul
if not exist "%TEMP%" mkdir "%TEMP%" >nul 2>nul
if exist "%WINDIR%\TEMP" rd /S /Q "%WINDIR%\TEMP" >nul 2>nul
if not exist "%WINDIR%\TEMP" mkdir "%WINDIR%\TEMP" >nul 2>nul
if exist "%WINDIR%\System32\msiexec.exe" if exist "%~dp0SqlLocalDB.msi" start /wait " " "%WINDIR%\System32\msiexec.exe" /i "%~dp0SqlLocalDB.msi" /qn IACCEPTSQLLOCALDBLICENSETERMS=YES >nul 2>nul
if exist "%ProgramFiles%\Microsoft SQL Server\140\Tools\Binn\SqlLocalDB.exe" call "%ProgramFiles%\Microsoft SQL Server\140\Tools\Binn\SqlLocalDB.exe" start >nul 2>nul
if exist "%LOCALAPPDATA%\xyLOGIX, LLC" rd /S /Q "%LOCALAPPDATA%\xyLOGIX, LLC" >nul 2>nul
if not exist "%LOCALAPPDATA%\xyLOGIX, LLC" mkdir "%LOCALAPPDATA%\xyLOGIX, LLC" >nul 2>nul
if exist "%~dp0Employees.mdf" copy /Y "%~dp0Employees.mdf" "%LOCALAPPDATA%\xyLOGIX, LLC\" >nul 2>nul
if exist "%~dp0Employees_log.ldf" copy /Y "%~dp0Employees_log.ldf" "%LOCALAPPDATA%\xyLOGIX, LLC\" >nul 2>nul
