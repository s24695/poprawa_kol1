using poprawa_kol1.Repositories.Author;
using poprawa_kol1.Repositories.Library;
using poprawa_kol1.Services.Author;
using poprawa_kol1.Services.Library;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//injections
builder.Services.AddScoped<ILibraryRepo, LibraryRepo>();
builder.Services.AddScoped<ILibraryService, LibraryService>();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAuthorRepo, AuthorRepo>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
