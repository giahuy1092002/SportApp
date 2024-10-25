using SportApp_Business;
using System.Reflection;
using MediatR;
using SportApp_Business.Hubs;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessService(builder.Configuration);
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddSignalR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
});
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHub<GetSchedulerHub>("/getschedulerhub");
});
app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.Run();
