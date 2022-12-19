
dotnet nuget trust remove nuget --configfile ../src/nuget.config
Write-Host "Updated trusted package authors"
Write-Host "Cleared existing trusted package authors"

[string[]]$trustedAuthors = Get-Content -Path 'trusted-nuget-authors.txt'
$joinedTrustedAuthors = $trustedAuthors -join ";"
dotnet nuget trust source nuget --owners "$($joinedTrustedAuthors)" --configfile ../src/nuget.config
Write-Host "Updated trusted package authors"

Write-Host "Done - press enter to close"
Read-Host