
MSBuild.exe MyProj.csproj /property:Configuration=Debug

MSTest.exe /container:TheAssemblyContainingYourClass /test: is the filter which uses the full name of the class when filtering