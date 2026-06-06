@echo off
setlocal

pushd "%~dp0"

dotnet restore MyResource.sln
if errorlevel 1 exit /b %errorlevel%

dotnet build MyResource.sln --configuration Release --no-restore -m:1
if errorlevel 1 exit /b %errorlevel%

echo.
echo Build complete. The deployable FiveM resource is in "%CD%\resource".

popd
endlocal
