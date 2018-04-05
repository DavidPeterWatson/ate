#!/bin/bash
# Build and deploy

dotnet publish -c release -r ubuntu.16.04-x64

sudo chmod +x ./bin/release/netcoreapp2.0/ubuntu.16.04-x64/ate

sudo rm -r /lib/ate

sudo mv ./bin/release/netcoreapp2.0/ubuntu.16.04-x64 /lib/ate