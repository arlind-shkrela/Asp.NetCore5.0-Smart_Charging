# Asp.NetCore5.0-Smart_Charging

Smart Charging is the asp.net core 5.0 web api solution, with an SQL Server Database with the purporse to expose CRUD and some Loggic endpoints for a relatively small schema.
The Solution uses Entitity Framework Core code first for continuing schema generation and updates. Generic intefaces, inheritance etc. 
Other Libraty included: AutoMapper

To Set the enviorement locally: 
  Either provide your public ip so i can allows connection from Azure SQL Server DB,
  Or, you can create a db locally, update the connection string in appsetting.json and from PM Console >> update-database. (In the project, you can find an sql file for adding       some demo data) 

ToDo: 
  Developing Unit Tests
  Deploying in Azure (fix)
  
Feel Free to use it/ or parts of it in your project. 
Arlind
