@call .\Lab1_2.exe
@IF NOT %errorlevel% 2 GOTO endErr

@call .\Lab1_2.exe -h
@IF NOT %errorlevel% 1 GOTO endErr

@call .\Lab1_2.exe 1 2 12
@if NOT %errorlevel% 8 GOTO endErr

@call .\Lab1_2.exe 2 1 12 >> tmp
@rem fc tmp ethalon_file
@echo %errorlevel%
@pause

.\Lab1_2.exe 2 8 12
@echo %errorlevel%
@pause

.\Lab1_2.exe 8 10 12
@echo %errorlevel%
@pause

.\Lab1_2.exe 10 16 2147483647
@echo %errorlevel%
@pause

.\Lab1_2.exe 10 16 -2147483648
@echo %errorlevel%
@pause

.\Lab1_2.exe 10 8 2147483647
@echo %errorlevel%
@pause

.\Lab1_2.exe 10 8 -2147483648
@echo %errorlevel%
@pause

.\Lab1_2.exe 10 2 0
@echo %errorlevel%
@pause

:endErr
@echo "Ошибка в тесте!"
@goto end

:end
pause