<Query Kind="Expression">
  <Connection>
    <ID>b0fe6822-3d30-4c85-b258-04c790d7c843</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>WestWind</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

Employees
   .Where(x => x.LastName.Contains("o") 
            && x.HomePhone.Contains("206"))
   .OrderByDescending(x => x.LastName )