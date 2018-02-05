# NetworkCommunicationMonitor

### How do I get set up? ###
* Create the repo
      * Make sure the ids auto increment
* Need to setup an account to login from the application as. The current connection string uses User = sa and Password = password
   * Change sa password
      * In Management Studio, open Security > Logins then right click sa and select properties
      * In General, type the password in the password field and confirm it
   * Enable sa
      * In sa properties, select Status on the elft and click enable
   * Enable protocols
      * Open SQL Server Configuration Manager
      * On the left, open 'SQL Server Network Configuration', right click and activate all the protocols
   * Enable SQL Server authentication
      * Login via Windows Authentication
	   * Right click server and select Properties
	   * In security tab, select "SQL Server and Windows Authentication mode"
* Populate database with test data by running this command 
   > sqlcmd -S $hostname\$servername -e -U sa -P password -d NetworkCommunicationMonitor -i PopulateTables.sql
* To connect to the database so you can query it via command line
   > sqlcmd -S $hostname\$servername -e -U sa -P password -d NetworkCommunicationMonitor
   * After issuing a query you must type the word 'go' into the command line to run it