<# :
@echo OFF
setlocal
set SCRIPT=%~f0
set ARGS=
:PARSE
if "%~1"=="" goto :ENDPARSE
if NOT "%ARGS%"=="" set ARGS=%ARGS%,'%~1'
if "%ARGS%"=="" set ARGS='%~1'
shift
goto :PARSE
:ENDPARSE
REM passes an extra blank argument
powershell.exe /noprofile /executionpolicy bypass "&{[ScriptBlock]::Create((get-content '%SCRIPT%') -join """`n""").Invoke(@(%ARGS%))}"
goto :EOF
#>

[int]$cnt
foreach ($cnt in 0..$args.length) {
  write-output ('arg[{0}] = "{1}"' -f $cnt, $args[$cnt])
}

<#
REM http://edgylogic.com/blog/powershell-and-external-commands-done-right/
REM http://stackoverflow.com/questions/14286457/using-parameters-in-batch-files-at-dos-command-line
REM a longer, somewhat less crypic alternative of: http://forum.oszone.net/thread-320616.html
REM powershell /noprofile /executionpolicy bypass "&{[ScriptBlock]::Create((Get-Content '%~f0') -join [Char]10).Invoke(@(&{$args}%*))}"
#>
