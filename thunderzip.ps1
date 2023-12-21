dotnet build -c release

foreach ($file in Get-ChildItem -Filter *.csproj){$name=$file.Basename}

Compress-Archive -Path "icon.png","README.md","manifest.json","bin\release\netstandard2.1\$name.dll" -DestinationPath "$name.zip" -Force