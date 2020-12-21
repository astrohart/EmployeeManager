@echo off
if exist "%TEMP%" rd /S /Q "%TEMP%" >nul 2>nul
if not exist "%TEMP%" mkdir "%TEMP%" >nul 2>nul
if exist "%WINDIR%\TEMP" rd /S /Q "%WINDIR%\TEMP" >nul 2>nul
if not exist "%WINDIR%\TEMP" mkdir "%WINDIR%\TEMP" >nul 2>nul
if exist "%WINDIR%\System32\msiexec.exe" if exist "%~dp0SqlLocalDB.msi" start /wait " " "%WINDIR%\System32\msiexec.exe" /i "%~dp0SqlLocalDB.msi" /qn IACCEPTSQLLOCALDBLICENSETERMS=YES >nul 2>nul
if exist "%ProgramFiles%\Microsoft SQL Server\140\Tools\Binn\SqlLocalDB.exe" call "%ProgramFiles%\Microsoft SQL Server\140\Tools\Binn\SqlLocalDB.exe" start >nul 2>nul
if exist "%PROGRAMDATA%\xyLOGIX, LLC" rd /S /Q "%PROGRAMDATA%\xyLOGIX, LLC" >nul 2>nul
if not exist "%PROGRAMDATA%\xyLOGIX, LLC" mkdir "%PROGRAMDATA%\xyLOGIX, LLC" >nul 2>nul
if exist "%~dp0Employees.mdf" copy /Y "%~dp0Employees.mdf" "%PROGRAMDATA%\xyLOGIX, LLC\" >nul 2>nul
if exist "%~dp0Employees_log.ldf" copy /Y "%~dp0Employees_log.ldf" "%PROGRAMDATA%\xyLOGIX, LLC\" >nul 2>nul
