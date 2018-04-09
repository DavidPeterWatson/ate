dotnet publish -c release -r osx.10.12-x64

sudo chmod +x ./bin/release/netcoreapp2.0/osx.10.12-x64/ate

sudo rm -r /Library/ate

sudo mv ./bin/release/netcoreapp2.0/osx.10.12-x64 /Library/ate