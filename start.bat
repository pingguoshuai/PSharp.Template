@echo on
dotnet clean
dotnet build
start %cd%\sample\PSharp.Template.ApiHost\start.bat
start %cd%\sample\UI\Manage\start.bat
pause