dotnet build -c release -r ubuntu.16.04-x64
rm -r "/usr/bin/ate"
mv "./bin/release/netcoreapp2.0/ubuntu.16.04-x64" "/usr/bin/ate"