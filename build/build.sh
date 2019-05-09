#!/bin/bash -xe 

echo "Clearing old packages"

npm install
npm install -g gulp 
npm install -g autorest

currentBranch=$(git rev-parse --abbrev-ref HEAD)
echo "Building branch $currentBranch"

testProject="agoda.csharp.client.test\\agoda.csharp.client.test.csproj"

dotnet sln remove $testProject
dotnet build
# This will create a tar file that can be used in conjunction with the autorest generate command to generate clients for running tests
name=$(npm pack)
package=${name##*$'\n'}
echo "Package created $package"
dotnet sln add $testProject 

# autorest --reset 
autorest --use=$package --csharp --input-file=..\swagger.json --output-folder=.\agoda.csharp.client.test\Client --namespace=Agoda.Csharp.Client.Test

dotnet test
