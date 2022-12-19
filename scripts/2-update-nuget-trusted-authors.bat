@echo off
powershell -Command "& {Start-Process Powershell.exe -WorkingDirectory %~dp0 -ArgumentList '-ExecutionPolicy Bypass -Command "cd %~dp0; ./%~n0.ps1; "'}
