@echo off
cd %~dp0

echo ::::::::::::::::::::::::::::::::::::::::::::::::
echo.
echo npm �������� by:ceet@vip.qq.com
echo.
echo ::::::::::::::::::::::::::::::::::::::::::::::::
echo.
echo.
echo 1����� node �汾
echo.
echo 2����� npm �汾
echo.
echo 3����ѯ npm �İ������help��
echo.
echo 4��ȫ�ְ�װ package �µİ��ļ� ��npm install��
echo.
echo 5��������ǰ��Ŀ��Ĭ��Ϊ http://localhost:10000��
echo.
echo 6�������ǰ��Ŀ�������Ĵ���Ĭ���� dist �ļ����£�
echo.
echo.
echo ::::::::::::::::::::::::::::::::::::::::::::::::
echo.
echo.
set /p a=ѡ������ �����س�ȷ����
if "%a%"=="1" start cmd /k "node -v"
if "%a%"=="2" start cmd /k "npm -v"
if "%a%"=="3" start cmd /k "npm help"
if "%a%"=="4" start cmd /k "npm install"
if "%a%"=="5" start cmd /k "npm run serve"
if "%a%"=="6" start cmd /k "npm run build"
 
pause