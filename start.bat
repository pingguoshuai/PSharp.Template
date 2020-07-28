@echo on
dotnet clean
dotnet build
set folder = ApiHost
set current = %cd%
start %cd%\sample\PSharp.Template.ApiHost\start.bat
start %cd%\sample\UI\Manage\start.bat
pause