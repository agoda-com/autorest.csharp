"Clearing old packages"

# npm version patch -f
$currentBranch = git rev-parse --abbrev-ref HEAD
If ($currentBranch -eq "tests") {
	$testProject = "agoda.csharp.client.test\agoda.csharp.client.test.csproj"
}
Else {
	 $testProject =	"autorest.csharp.test\autorest.csharp.test.csproj"
}

dotnet sln remove $testProject
dotnet build
$c = npm pack
$b = $c -split "\n"
$gz = $b[$b.length - 1]
"Package created $gz"
dotnet sln add $testProject 

# autorest --reset 
# autorest --use=http://localhost:8080/$gz --csharp --input-file=..\swagger.json --output-folder=.\agoda.csharp.client.test\Client --namespace=Agoda.Csharp.Client.Test
# This will create a tar file that can be used in conjunction with the autorest generate command to generate clients for running tests
dotnet test
# rmrf agoda.csharp.client.test
# git checkout .
