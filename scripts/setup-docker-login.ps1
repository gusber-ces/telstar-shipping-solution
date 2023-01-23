trap {
    Write-Host "`n$_ - press enter to close" -ForegroundColor Red
    Read-Host
    return -1
}

$repo = 'ncdotnet'

Write-Host "This script will setup your connection to the '$repo' Docker repositories."
Write-Host
Write-Host "Please enter your NCDMZ credentials"
$username = Read-Host "Username" | % { $_ -replace "ncdmz\\" }
$securedValue = Read-Host "Password" -AsSecureString
$bstr = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($securedValue)
$password = [System.Runtime.InteropServices.Marshal]::PtrToStringAuto($bstr)
Write-Host

$password | docker login "$repo-release-docker.repo.netcompany.com" --username "$username" --password-stdin
if ($LastExitCode -eq 0) {
    Write-Host "Authenticated with Artifactory docker registry: $repo-release-docker.repo.netcompany.com"
} else {
    throw "Failed to authenticate with Artifactory docker registry: $repo-release-docker.repo.netcompany.com"
}

$password | docker login "$repo-dev-docker.repo.netcompany.com" --username "$username" --password-stdin
if ($LastExitCode -eq 0) {
    Write-Host "Authenticated with Artifactory docker registry: $repo-dev-docker.repo.netcompany.com"
} else {
    throw "Failed to authenticate with Artifactory docker registry: $repo-dev-docker.repo.netcompany.com"
}

Write-Host "`nDone - press enter to close" -ForegroundColor Green
Read-Host
