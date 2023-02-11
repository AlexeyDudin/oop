@rem Ошибка параметров командной строки
Lab1.exe 
@echo %errorlevel%
@pause
@cls
Lab1.exe 1.txt
@echo %errorlevel%
@pause
@cls
Lab1.exe 1.txt 2.txt 3.txt 111 222
@echo %errorlevel%
@pause
@cls

@rem Отсутсвует файл для чтения
Lab1.exe 11.txt 2.txt 11 123
@echo %errorlevel%
@pause
@cls

@rem Отсутствует искомая строка
Lab1.exe 1.txt out.txt qqq 1q2w
@echo %errorlevel%
@pause
@cls

@rem Пример с многократным вхождением искомой строки в строку-заменитель 
Lab1.exe 1.txt out.txt ма мама
@echo %errorlevel%
@pause
@cls

@rem Пример с заменой подстроки <1231234> внутри текста <12312312345>
Lab1.exe 1.txt out.txt 1231234 111222
@echo %errorlevel%
@pause
@cls

@pause