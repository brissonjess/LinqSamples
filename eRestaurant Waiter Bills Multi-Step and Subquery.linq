<Query Kind="Statements">
  <Connection>
    <ID>8751cd65-60c5-4775-94a1-1328b8a2efd6</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//find the waiter with the most bills
//multiple step solution
var maxbills = (from x in Waiters
				select x.Bills.Count()).Max();

var BestWaiter = from x in Waiters
				where x.Bills.Count ( )== maxbills
				select new{
						Name = x.FirstName + " " + x.LastName};

BestWaiter.Dump();
//subquery style
var BestWaiterSubQuery = from x in Waiters
				where x.Bills.Count ( )== (from y in Waiters
											select y.Bills.Count()).Max()
				select new{
						Name = x.FirstName + " " + x.LastName};

BestWaiterSubQuery.Dump();
//create a dataset which contains the summary bill info by waiter	
var WaiterBills = from x in Waiters
				 orderby x.LastName, x.FirstName
				 select new {
				 	Name = x.LastName + ", " + x.FirstName,
					TotalBillCount = x.Bills.Count(),
					BillInfo = (from y in x.Bills
								where y.BillItems.Count () > 0
								select new{
										BillID = y.BillID,
										BillDate = y.BillDate,
										TableID = y.TableID,
										Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)
										}
								)
							};
WaiterBills.Dump();