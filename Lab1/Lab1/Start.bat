@rem �訡�� ��ࠬ��஢ ��������� ��ப�
@call .\Lab1.exe > tmp.txt
@IF NOT errorlevel 1 goto endErr
@fc .\tmp.txt .\EthalonBadCommand.txt
@call .\Lab1.exe 1.txt > tmp.txt
@IF NOT errorlevel 1 goto endErr
@fc .\tmp.txt .\EthalonBadCommand.txt
@call .\Lab1.exe 1.txt 2.txt 3.txt 111 222 > tmp.txt
@IF NOT errorlevel 1 goto endErr
@fc .\tmp.txt .\EthalonBadCommand.txt

@rem �訡�� ������ 䠩��
@call .\Lab1.exe 11.txt 2.txt 11 123 > tmp.txt
@IF NOT errorlevel 2 goto endErr
@fc .\tmp.txt .\EthalonBadOpenFile.txt

@rem �� ��������� �����ப� � ��ப�
@call .\Lab1.exe 1.txt out.txt qqq 1q2w > tmp.txt
@IF NOT errorlevel 8 goto endErr
@fc .\tmp.txt .\EthalonNoSearchString.txt

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