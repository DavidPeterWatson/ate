
docker volume create sqlexpress

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=password' -e 'MSSQL_PID=Express' --name 'sqlexpress' -v sqlexpress:/var/opt/mssql -p 1433:1433 -d microsoft/mssql-server-linux:latest

sudo docker cp database.bak sqlexpress:/var/opt/mssql/backup

sudo docker exec -it sqlexpress /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'password' -Q 'RESTORE FILELISTONLY FROM DISK = "/var/opt/mssql/backup/database.bak"' | tr -s ' ' | cut -d ' ' -f 1-2

sudo docker exec -it sqlexpress /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'password' -Q 'RESTORE DATABASE CANTRACK FROM DISK = "/var/opt/mssql/backup/CANTRACK.bak" WITH MOVE "CANTRACK" TO "/var/opt/mssql/data/CANTRACK.mdf", MOVE "CANTRACK_Log" TO "/var/opt/mssql/data/CANTRACK.ldf"'

sudo docker exec -it sqlexpress /opt/mssql-tools/bin/sqlcmd \
   -S localhost -U SA -P 'password' \
   -Q 'SELECT Name FROM sys.Databases' 

sudo nano /etc/environment 
/opt/mssql-tools/bin/

sqlcmd -S localhost -U SA -P '4367SqL!!!' -Q 'SELECT Name FROM sys.Databases'