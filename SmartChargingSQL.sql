/****** Script for SelectTopNRows command from SSMS  ******/
  SELECT TOP (1000) [Id]
      ,[Name]
      ,[Capacity]
  FROM [dbo].[Groups]
  
  SELECT TOP (1000) [Id]
      ,[Name]
      ,[GroupId]
      ,[ConnectorId]
  FROM [dbo].[ChargeStations]

  SELECT TOP (1000) [Id]
      ,[Max_Current]
  FROM [dbo].[Connectors]



--  insert into [dbo].[ChargeStations] (Name, GroupId, ConnectorId) values ('Charge Station 7', 5,1)

--  update [dbo].[ChargeStations]  set ConnectorId = 2 where Id =11

-- update [dbo].[Groups] set Capacity = 1500 where Id = 5
--update [dbo].[Groups] set Capacity = 1200 where Id = 1
--update [dbo].[Groups] set Capacity = 1400 where Id = 4
--update [dbo].[Groups] set Capacity = 1500 where Id = 5
--update [dbo].[Groups] set Capacity = 1200 where Id = 7
--update [dbo].[Groups] set Capacity = 1300 where Id = 8
--update [dbo].[Groups] set Capacity = 1600 where Id = 9
--update [dbo].[Groups] set Capacity = 1600 where Id = 10
--update [dbo].[Groups] set Capacity = 1500 where Id = 11


  --update [dbo].[ChargeStations] set Name = 'Charge Station 5' where Id = 5

  --update [dbo].[Connectors] set [Max_Current] = 200 where Id = 1
  --update [dbo].[Connectors] set [Max_Current] = 150 where Id = 2   
  --update [dbo].[Connectors] set [Max_Current] = 100 where Id = 3 
  --update [dbo].[Connectors] set [Max_Current] = 200 where Id = 4 
  --update [dbo].[Connectors] set [Max_Current] = 100 where Id = 5 
  --update [dbo].[Connectors] set [Max_Current] = 200 where Id = 6 
  --update [dbo].[Connectors] set [Max_Current] = 250 where Id = 7 
  --update [dbo].[Connectors] set [Max_Current] = 100 where Id = 8 
  --update [dbo].[Connectors] set [Max_Current] = 200 where Id = 9 
  --  update [dbo].[Connectors] set [Max_Current] = 150 where Id = 10 
  --update [dbo].[Connectors] set [Max_Current] = 200 where Id = 11
  --  update [dbo].[Connectors] set [Max_Current] = 100 where Id = 12