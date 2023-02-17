@rem Ошибка параметров командной строки
@call .\Lab1.exe > tmp.txt
@IF NOT errorlevel 1 goto endErr
@fc .\tmp.txt .\EthalonBadCommand.txt
@call .\Lab1.exe 1.txt > tmp.txt
@IF NOT errorlevel 1 goto endErr
@fc .\tmp.txt .\EthalonBadCommand.txt
@call .\Lab1.exe 1.txt 2.txt 3.txt 111 222 > tmp.txt
@IF NOT errorlevel 1 goto endErr
@fc .\tmp.txt .\EthalonBadCommand.txt

@rem Ошибка открытия файла
@call .\Lab1.exe 11.txt 2.txt 11 123 > tmp.txt
@IF NOT errorlevel 2 goto endErr
@fc .\tmp.txt .\EthalonBadOpenFile.txt

@rem Не существующая подстрока в строке
@call .\Lab1.exe 1.txt out.txt qqq 1q2w > tmp.txt
@IF NOT errorlevel 8 goto endErr
@fc .\tmp.txt .\EthalonNoSearchString.txt

@rem Замена с рекурсией 
@call .\Lab1.exe 1.txt out.txt ма мама
@IF NOT errorlevel 0 goto endErr

@rem Замена подстроки <1231234> в строке <12312312345>
@call .\Lab1.exe 1.txt out.txt 1231234 111222
@IF errorlevel 0 goto sayOk

:endErr
@echo "Ошибка в тесте!"
@goto end

:sayOk
@cls
@echo "Test ok"
@goto end

:end
@pause