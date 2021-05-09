echo %CD%
cd ./AutomationNC/AutomationNC && dotnet publish --output "C:/QuangCaoFB420" --runtime win-x64 --configuration Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true
cd ../../