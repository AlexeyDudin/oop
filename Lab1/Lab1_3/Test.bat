@rem сделать проверку с эталоном
.\Lab1_3.exe
@echo %errorlevel%
@pause

.\Lab1_3.exe 11.txt
@echo %errorlevel%
@pause

.\Lab1_3.exe BadFile1.txt
@echo %errorlevel%
@pause

.\Lab1_3.exe BadFile2.txt
@echo %errorlevel%
@pause

.\Lab1_3.exe BadFile3.txt
@echo %errorlevel%
@pause

.\Lab1_3.exe Input.txt
@echo %errorlevel%
@pause