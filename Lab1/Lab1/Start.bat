﻿@rem �訡�� ��ࠬ��஢ ��������� ��ப�
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

@rem �������� 䠩� ��� �⥭��
Lab1.exe 11.txt 2.txt 11 123
@echo %errorlevel%
@pause
@cls

@rem ��������� �᪮��� ��ப�
Lab1.exe 1.txt out.txt qqq 1q2w
@echo %errorlevel%
@pause
@cls

@rem �ਬ�� � ��������� �宦������ �᪮��� ��ப� � ��ப�-������⥫� 
Lab1.exe 1.txt out.txt �� ����
@echo %errorlevel%
@pause
@cls

@rem �ਬ�� � ������� �����ப� <1231234> ����� ⥪�� <12312312345>
Lab1.exe 1.txt out.txt 1231234 111222
@echo %errorlevel%
@pause
@cls

@pause