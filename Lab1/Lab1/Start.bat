@rem �訡�� ��ࠬ��஢ ��������� ��ப�
@call .\Lab1.exe 
@IF NOT errorlevel 1 goto endErr
@call .\Lab1.exe 1.txt
@IF NOT errorlevel 1 goto endErr
@call .\Lab1.exe 1.txt 2.txt 3.txt 111 222
@IF NOT errorlevel 1 goto endErr

@rem �訡�� ������ 䠩��
@call .\Lab1.exe 11.txt 2.txt 11 123
@IF NOT errorlevel 2 goto endErr

@rem �� ��������� �����ப� � ��ப�
@call .\Lab1.exe 1.txt out.txt qqq 1q2w
@IF NOT errorlevel 8 goto endErr

@rem ������ � ४��ᨥ� 
@call .\Lab1.exe 1.txt out.txt �� ����
@IF NOT errorlevel 0 goto endErr

@rem ������ �����ப� <1231234> � ��ப� <12312312345>
@call .\Lab1.exe 1.txt out.txt 1231234 111222
@IF errorlevel 0 goto sayOk

:endErr
@echo "�訡�� � ���!"
@goto end

:sayOk
@cls
@echo "Test ok"
@goto end

:end
@pause