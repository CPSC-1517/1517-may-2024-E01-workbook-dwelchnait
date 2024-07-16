<Query Kind="Program">
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

void Main()
{
	//Regions.OrderBy(r => r.RegionDescription).Where (r => r.RegionID > 4)
	int regionid = 4; //this is like my incoming parameter to my service method
	
	//two ways to view your results
	//both use the LinqPad method .Dump()
	//a) add the .Dump() to the end of your query
	Regions.Where(r => r.RegionID == regionid).Dump();
	
	//b) save the results of your query in a variable, then dump the variable
	var results = Regions.Where(r => r.RegionID == regionid);
	results.Dump();
	
}

// You can define other methods, fields, classes and namespaces here