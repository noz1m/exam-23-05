using Infrastructure.Data;
using Infrastructure.Interface;
using Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IClapService, ClapService>();
builder.Services.AddScoped<ICommentService, CommentService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(n => n.SwaggerEndpoint("/swagger/v1/swagger.json", "My App"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();