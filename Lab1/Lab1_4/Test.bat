@echo "Проверка параметров командной строки"
@call .\Lab1_4.exe
@IF NOT %errorlevel% == 2 GOTO badEnd

@call .\Lab1_4.exe 1
@if not %errorlevel% == 2 goto badEnd

@call .\Lab1_4.exe 1 2 3
@if not %errorlevel% == 2 goto badEnd

@cls
@echo "Проверка на подачу несуществующего файла"
@call .\Lab1_4.exe pack 111.txt 1.bin
@if not %errorlevel% == 3 goto badEnd

@cls
@echo "Запаковка файла Test1.txt"
@call .\Lab1_4.exe pack Test1.txt Test1.bin
@if not %errorlevel% == 0 goto badEnd
@fc Test1.bin EthalonTest1.bin
@if not %errorlevel% == 0 goto badEnd

@cls
@echo "Запаковка файла Test2.txt, содержащего переполнение"
@call .\Lab1_4 pack Test2.txt Test2.bin
@if not %errorlevel% == 1 goto badEnd

@cls
@echo "Запаковка файла Test1.txt"
@call .\Lab1_4.exe pack Test.txt Test.bin
@if not %errorlevel% == 0 goto badEnd
@fc Test.bin EthalonTest.bin
@if not %errorlevel% == 0 goto badEnd

@cls
@echo "Распаковка файла Test1.bin"
@call .\Lab1_4.exe unpack Test1.bin Test1_unpacked.txt
@if NOT %errorlevel% == 0 goto badEnd
@fc Test1.txt Test1_unpacked.txt
@if not %errorlevel% == 0 goto badEnd

@cls
@echo "Распаковка файла Test.txt"
@call .\Lab1_4.exe unpack Test.bin Test_unpacked.txt
@if not %errorlevel% == 0 goto badEnd
@fc Test.txt Test_unpacked.txt
@if not %errorlevel% == 0 goto badEnd

@echo "Все тесты пройдены"
@rem call .\Lab1_4.exe unpack Test3.bin Test3_unpacked.txt
@rem @if not %errorlevel% == 0 goto badEnd
@rem @fc Test3.txt Test3_unpacked.txt
@rem @if not %errorlevel% == 0 goto badEnd
@goto end

:badEnd
@echo "Что-то пошло не так!"
@echo %errorlevel%
@pause
@goto end

:end