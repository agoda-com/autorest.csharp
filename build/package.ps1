dotnet sln remove agoda.csharp.client.test\agoda.csharp.client.test.csproj
dotnet build
npm pack

# This will create a tar file that can be used in conjunction with the autorest generate command to generate clients for running tests
