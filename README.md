# Asp.NetCore5.0-Smart_Charging

Other Libraty included: AutoMapper
Smart Charging is the asp.net core 5.0 web api solution, with an SQL Server Database with the purpose to expose CRUD and some Logic endpoints for a relatively small schema.The Solution uses Entity Framework Core code first for continuing schema generation and updates. Generic interfaces, inheritance etc.<br />
Other Library included: AutoMapper

Hostet in Azure together with sql db: https://smartchargingapi.azurewebsites.net/swagger/index.html

To Set the environment locally: 
- ~~Either provide your public ip so I can allows connection from Azure SQL Server DB~~, <br /> 
  (UPDATE,I Just allowed public connection with azure sql db, so you can use the following connection string in order to have a look at db locally or ssms)
- Or, you can create a db locally, update the connection string in appsetting.json and from PM Console >> update-database. (In the project, you can find a sql file for adding       some demo data) 

ToDo: 
- Developing Unit Tests
  
Feel Free to use it/ or parts of it in your project. 
Arlind
