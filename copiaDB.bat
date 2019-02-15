@echo off
@for /F "tokens=1-4 delims=/ " %%i in ('date /t') do set WD=%%i

C:\wamp\bin\mysql\mysql5.6.17\bin\mysqldump -u root cir > y:\copiaDatabase.%WD%.sql
C:\wamp\bin\mysql\mysql5.6.17\bin\mysqldump -u root cir > z:\copiaDatabase.sql
C:\wamp\bin\mysql\mysql5.6.17\bin\mysqldump -u root cir > c:\copiaDatabase.sql
