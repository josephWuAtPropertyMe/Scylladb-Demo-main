// See https://aka.ms/new-console-template for more information
using Cassandra;

Console.WriteLine("Hello, World!");

var authProvider = new PlainTextAuthProvider("username", "password");
var queryOptions = new QueryOptions()
    .SetPageSize(1000);

Cluster cluster = Cluster.Builder()
    .AddContactPoint("192.168.1.100")
    .WithPort(9042)
    .WithQueryOptions(queryOptions)
    .WithAuthProvider(authProvider)
    .Build();

var s = cluster.AllHosts();
ISession session = cluster.Connect("demo_keyspace");



var rows = session.Execute("SELECT * FROM messages");

foreach (var row in rows)
{
    Console.WriteLine(row[0] + "," + row[1] + "," + row[2] + "," + row[3]);
}

Console.WriteLine("Break");