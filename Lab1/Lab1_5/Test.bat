@echo "Проверка параметров командной строки"
@call .\Lab1_5.exe
@if NOT %errorlevel% == 2 goto badEnd

@call .\Lab1_5.exe 1.txt
@if NOT %errorlevel% == 2 goto badEnd

@cls
@echo "Проверка на не существующий файл"
.\Lab1_5.exe 1.txt 2.txt
@if NOT %errorlevel% == 3 GOTO badEnd

@cls
@echo "Проверка пустого файла"
@call .\Lab1_5.exe Input3.txt Output3.txt
@if NOT %errorlevel% == 0 GOTO badEnd
@fc EthalonOutput3.txt Output3.txt
@if NOT %errorlevel% == 0 GOTO badEnd

@cls
@echo "Проверка моих входных данных"
@call .\Lab1_5.exe Input.txt Output.txt
@if not %errorlevel% == 0 goto badEnd
@fc EthalonOutput.txt Output.txt
@if NOT %errorlevel% == 0 GOTO badEnd

@call .\Lab1_5.exe Input2.txt Output2.txt
@if not %errorlevel% == 0 goto badEnd
@fc EthalonOutput2.txt Output2.txt
@if NOT %errorlevel% == 0 GOTO badEnd

@cls
@echo "Проверка примера из архива"
@call .\Lab1_5.exe Sample.txt SampleOutput.txt
@if NOT %errorlevel% == 0 goto badEnd
@fc EthalonSample.txt SampleOutput.txt
@if NOT %errorlevel% == 0 GOTO badEnd

@cls
@echo "Все тесты пройдены"
goto end

:badEnd
@echo "Что-то пошло не так!"
@echo %errorlevel%
@goto end

:end
@pause