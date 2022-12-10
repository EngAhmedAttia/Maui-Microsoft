using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.Models;

var builder = WebApplication.CreateBuilder(args);
var SqliteConnection = builder.Configuration.GetConnectionString("SqliteConnection");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(SqliteConnection));



var app = builder.Build();


app.UseHttpsRedirection();

app.MapGet("api/todo", async (AppDbContext context) =>
{
    var items = await context.ToDoes.ToListAsync();
    return Results.Ok(items);
});

app.MapPost("api/todo", async (AppDbContext context, ToDo toDo) =>
{
    await context.AddAsync(toDo);
    await context.SaveChangesAsync();
    return Results.Created($"api/todo/{toDo.Id}", toDo);
});

app.MapPut("api/todo/{id}", async (AppDbContext context, int id, ToDo toDo) =>
{
    var toDoModel = await context.ToDoes.FirstOrDefaultAsync(t=> t.Id == id);
    if (toDo == null)
    {
        return Results.NotFound();
    }
    toDoModel.ToDoName=toDo.ToDoName;
    await context.SaveChangesAsync();
    return Results.NoContent();
});

app.MapDelete("api/todo/{id}", async (AppDbContext context, int id) =>
{
    var toDoModel = await context.ToDoes.FirstOrDefaultAsync(t => t.Id == id);
    if (toDoModel == null)
    {
        return Results.NotFound();
    }
   
    context.ToDoes.Remove(toDoModel);
    await context.SaveChangesAsync();
    return Results.NoContent();
});


app.Run();
