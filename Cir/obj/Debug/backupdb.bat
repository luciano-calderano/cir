IF NOT EXIST Y:\ GOTO NO_Y_DIR
C:\wamp\bin\mysql\mysql5.6.17\bin\mysqldump -u root cir_ok > Y:\copiaDB.%1.sql
:NO_Y_DIR