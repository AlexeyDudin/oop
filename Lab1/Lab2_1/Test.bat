@rem �஢�ઠ �� ���⮩ �室��� 䠩�
@call Lab2_1.exe < Empty.txt > EmptyRes.txt
@if NOT %errorlevel% == 0 GOTO endErr
@fc EmptyRes EthalonEmptyRes.txt
@if NOT %errorlevel% == 0 GOTO endErr



:endErr
@echo %errorlevel%

:end
@pause