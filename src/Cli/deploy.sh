#!/bin/bash
# Build and deploy

dotnet build -c release -r ubuntu.16.04-x64

sudo rm -r /usr/bin/ate

sudo mv ./bin/release/netcoreapp2.0/ubuntu.16.04-x64 /usr/bin/ate