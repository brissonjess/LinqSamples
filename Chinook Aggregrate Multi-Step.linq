<Query Kind="Statements">
  <Connection>
    <ID>03e2069a-f1a2-419a-8737-9f7911297712</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

var maxcount = (from k in MediaTypes
		select k.Tracks.Count()).Max();
maxcount.Dump();
var popularMedia = from y in MediaTypes
where y.Tracks.Count () == maxcount
select new{
			Name=y.Name,
			TTracks = y.Tracks.Count()
};
popularMedia.Dump();


var x = from k in MediaTypes
where k.Tracks.Count ()== (from y in MediaTypes
							select 
							y.Tracks.Count()).Max()
select new {
		Name = k.Name,
		TTracks = k.Tracks.Count()
};
x.Dump();



