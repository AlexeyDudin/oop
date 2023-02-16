.\Lab1_4.exe
@echo %errorlevel%
@pause

.\Lab1_4.exe 1
@echo %errorlevel%
@pause

.\Lab1_4.exe 1 2 3
@echo %errorlevel%
@pause

.\Lab1_4.exe pack 111.txt 1.bin
@echo %errorlevel%
@pause

.\Lab1_4.exe pack Test1.txt Test1.bin
@echo %errorlevel%
@pause

.\Lab1_4 pack Test2.txt Test2.bin
@echo %errorlevel%
@pause

.\Lab1_4.exe pack Test.txt Test.bin
@echo %errorlevel%
@pause

.\Lab1_4.exe unpack Test1.bin Test1_unpacked.txt
@echo %errorlevel%
@fc Test1.txt Test1_unpacked.txt
@pause

.\Lab1_4.exe unpack Test.bin Test_unpacked.txt
@echo %errorlevel%
@fc Test.txt Test_unpacked.txt
@pause

.\Lab1_4.exe unpack Test3.bin Test3_unpacked.txt
@echo %errorlevel%
@pause