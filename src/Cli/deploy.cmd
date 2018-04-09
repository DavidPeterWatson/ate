dotnet publish -c release -r win10-x64

xcopy ".\bin\release\netcoreapp2.0\win10-x64" "C:\Program Files\ate" /Y