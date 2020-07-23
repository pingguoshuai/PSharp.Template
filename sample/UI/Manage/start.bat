@echo off
cd %~dp0

echo ::::::::::::::::::::::::::::::::::::::::::::::::
echo.
echo npm 常用命令 by:ceet@vip.qq.com
echo.
echo ::::::::::::::::::::::::::::::::::::::::::::::::
echo.
echo.
echo 1、检查 node 版本
echo.
echo 2、检查 npm 版本
echo.
echo 3、查询 npm 的帮助命令（help）
echo.
echo 4、全局安装 package 下的包文件 （npm install）
echo.
echo 5、启动当前项目（默认为 http://localhost:10000）
echo.
echo 6、打包当前项目（打包后的代码默认在 dist 文件夹下）
echo.
echo.
echo ::::::::::::::::::::::::::::::::::::::::::::::::
echo.
echo.
set /p a=选择命令 （按回车确定）
if "%a%"=="1" start cmd /k "node -v"
if "%a%"=="2" start cmd /k "npm -v"
if "%a%"=="3" start cmd /k "npm help"
if "%a%"=="4" start cmd /k "npm install"
if "%a%"=="5" start cmd /k "npm run serve"
if "%a%"=="6" start cmd /k "npm run build"
 
pause