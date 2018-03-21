echo

sqlcmd -S %1 -e -U sa -P password -d NetworkCommunicationMonitor -i DeleteTables.sql
sqlcmd -S %1 -e -U sa -P password -d NetworkCommunicationMonitor -i CreateTables.sql
sqlcmd -S %1 -e -U sa -P password -d NetworkCommunicationMonitor -i PopulateTables.sql