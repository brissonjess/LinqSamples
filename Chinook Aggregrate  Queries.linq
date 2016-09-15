<Query Kind="Expression">
  <Connection>
    <ID>4fd07e05-6bb5-40ea-b6f1-4438a265085d</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//sample for entity subset
//sample of entity navigation from child to parent on Where
//reminder that code is C# and thus appropriate methods can be used .Equals()
from x in Customers
where x.SupportRepIdEmployee.FirstName.Equals("Jane") &&
x.SupportRepIdEmployee.LastName.Equals("Peacock")
select new{
		Name  = x.LastName + ", " + x.FirstName,
		City = x.City,
		State = x.State,
		Phone = x.Phone,
		Email = x.Email
}

//use of aggregrates in queries
//Count() count the number of instances of the collection reference
//Sum() totals a specific field/expression, thus you will likely need to use a delegate
//       to indicate the collection instance attribute to be used.
//Average() averages a specific field/expression, thus you will likely need to use a delegate
//       to indicate the collection instance attribute to be used.
from x in Albums
orderby x.Title
where x.Tracks.Count() > 0
select new{
		Title = x.Title,
		NumberOfAlbumTracks = x.Tracks.Count(),
		TotalAlbumPrice = x.Tracks.Sum(y => y.UnitPrice),
		AverageTrackLengthInSecondsA = (x.Tracks.Average(y => y.Milliseconds))/1000,
		AverageTrackLengthInSecondsB = x.Tracks.Average(y => y.Milliseconds/1000)
}