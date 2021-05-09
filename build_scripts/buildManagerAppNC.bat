echo %CD%
cd ./ManagerAppNC/ManagerAppNC && dotnet publish --output "C:/QuangCaoFB420" --runtime win-x64 --configuration Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true
cd ../../