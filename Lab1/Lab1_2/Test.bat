.\Lab1_2.exe
@echo %errorlevel%
@pause

.\Lab1_2.exe -h
@echo %errorlevel%
@pause

.\Lab1_2.exe 1 2 12
@echo %errorlevel%
@pause

.\Lab1_2.exe 2 1 12
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