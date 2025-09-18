USE master;
GO

DECLARE @DatabaseName NVARCHAR(50) = 'E_Commerce';
DECLARE @SQL NVARCHAR(MAX);

-- Generate kill commands for all active connections
SET @SQL = (
    SELECT 'KILL ' + CAST(spid AS VARCHAR(5)) + '; '
    FROM sys.sysprocesses
    WHERE dbid = DB_ID(@DatabaseName)
    FOR XML PATH('')
);

EXEC sp_executesql @SQL;