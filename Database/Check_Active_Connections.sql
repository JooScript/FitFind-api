USE master;
GO

SELECT 
    DB_NAME(s.database_id) AS DatabaseName,
    COUNT(*) AS ActiveConnections
FROM sys.dm_exec_sessions s
WHERE s.database_id > 0
AND DB_NAME(s.database_id) = 'E_Commerce'  
GROUP BY s.database_id;

SELECT 
    DB_NAME(database_id) AS DatabaseName,
    COUNT(*) AS ActiveConnections
FROM sys.dm_exec_sessions
WHERE database_id > 0
GROUP BY database_id
ORDER BY ActiveConnections DESC;