@echo "�஢�ઠ ��ࠬ��஢ ��������� ��ப�"
@call .\Lab1_4.exe
@IF NOT %errorlevel% == 2 GOTO badEnd

@call .\Lab1_4.exe 1
@if not %errorlevel% == 2 goto badEnd

@call .\Lab1_4.exe 1 2 3
@if not %errorlevel% == 2 goto badEnd

@cls
@echo "�஢�ઠ �� ������ ���������饣� 䠩��"
@call .\Lab1_4.exe pack 111.txt 1.bin
@if not %errorlevel% == 3 goto badEnd

@cls
@echo "��������� 䠩�� Test1.txt"
@call .\Lab1_4.exe pack Test1.txt Test1.bin
@if not %errorlevel% == 0 goto badEnd
@fc Test1.bin EthalonTest1.bin
@if not %errorlevel% == 0 goto badEnd

@cls
@echo "��������� 䠩�� Test2.txt, ᮤ�ঠ饣� ��९�������"
@call .\Lab1_4 pack Test2.txt Test2.bin
@if not %errorlevel% == 1 goto badEnd

@cls
@echo "��������� 䠩�� Test1.txt"
@call .\Lab1_4.exe pack Test.txt Test.bin
@if not %errorlevel% == 0 goto badEnd
@fc Test.bin EthalonTest.bin
@if not %errorlevel% == 0 goto badEnd

@cls
@echo "��ᯠ����� 䠩�� Test1.bin"
@call .\Lab1_4.exe unpack Test1.bin Test1_unpacked.txt
@if NOT %errorlevel% == 0 goto badEnd
@fc Test1.txt Test1_unpacked.txt
@if not %errorlevel% == 0 goto badEnd

@cls
@echo "��ᯠ����� 䠩�� Test.txt"
@call .\Lab1_4.exe unpack Test.bin Test_unpacked.txt
@if not %errorlevel% == 0 goto badEnd
@fc Test.txt Test_unpacked.txt
@if not %errorlevel% == 0 goto badEnd

@echo "�� ���� �ன����"
@rem call .\Lab1_4.exe unpack Test3.bin Test3_unpacked.txt
@rem @if not %errorlevel% == 0 goto badEnd
@rem @fc Test3.txt Test3_unpacked.txt
@rem @if not %errorlevel% == 0 goto badEnd
@goto end

:badEnd
@echo "��-� ��諮 �� ⠪!"
@echo %errorlevel%
@pause
@goto end

:end