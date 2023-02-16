.\Lab1_5.exe
@echo %errorlevel%
@pause

.\Lab1_5.exe 1.txt
@echo %errorlevel%
@pause

.\Lab1_5.exe 1.txt 2.txt
@echo %errorlevel%
@pause

.\Lab1_5.exe Input3.txt Output3.txt
@echo %errorlevel%
@pause

.\Lab1_5.exe Input.txt Output.txt
@echo %errorlevel%
@pause

.\Lab1_5.exe Sample.txt SampleOutput.txt
@echo %errorlevel%
@pause

.\Lab1_5.exe Input2.txt Output2.txt
@echo %errorlevel%
@pause
