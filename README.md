# tecom_test_task
This is a test OData Connected Service. Before starting, change the connection string in `TecomTestContext.cs` to your actual database password:
```
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("User ID=postgres;Password=YOUR_PASSWORD;Server=localhost;Port=5432;Database=tecom_test;Integrated Security=true;Pooling=true;");
