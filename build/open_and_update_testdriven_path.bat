@echo off
cls
powershell .\tools\psake\psake.ps1 .\open.ps1 update_test_driven
open.bat

