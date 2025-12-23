#!/bin/bash
set -e
set +H

echo "Waiting for SQL Server..."

until /opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P "$SA_PASSWORD" -Q "SELECT 1" > /dev/null 2>&1
do
  sleep 2
done

echo "SQL Server is ready"

echo "Creating database..."
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P "$SA_PASSWORD" -Q "
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = '$DB_NAME')
BEGIN
    CREATE DATABASE [$DB_NAME];
END
"

echo "Creating login..."
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P "$SA_PASSWORD" -Q "
IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = '$DB_USER')
BEGIN
    CREATE LOGIN [$DB_USER] WITH PASSWORD = '$DB_PASSWORD';
END
"

echo "Creating user and permissions..."
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P "$SA_PASSWORD" -Q "
USE [$DB_NAME];
IF NOT EXISTS (SELECT name FROM sys.database_principals WHERE name = '$DB_USER')
BEGIN
    CREATE USER [$DB_USER] FOR LOGIN [$DB_USER];
END
ALTER ROLE db_datareader ADD MEMBER [$DB_USER];
ALTER ROLE db_datawriter ADD MEMBER [$DB_USER];
ALTER ROLE db_ddladmin ADD MEMBER [$DB_USER];
"

echo "Creating tables..."
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P "$SA_PASSWORD" -i /scripts/createTables.sql

echo "Creating constraints..."
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P "$SA_PASSWORD" -i /scripts/createConstrains.sql

echo "Seeding default data..."
/opt/mssql-tools/bin/sqlcmd -S sqlserver -U sa -P "$SA_PASSWORD" -d "$DB_NAME" -i /scripts/seed.sql
echo "Default data inserted"

echo "Database initialization completed"
