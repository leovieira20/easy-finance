using Serilog;

var builder = WebApplication.CreateBuilder(args);

var seqServerProtocol = builder.Configuration["SERVICE:SEQ:PROTOCOL"];
var seqServerHost = builder.Configuration["SERVICE:SEQ:HOST"];
var seqServerPort = builder.Configuration["SERVICE:SEQ:PORT"];
var seqServerUrl = $"{seqServerProtocol}://{seqServerHost}:{seqServerPort}";

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    .WriteTo.Seq(seqServerUrl)
    .Enrich.WithProperty("ApplicationName", "EasyFinance.Web")
    .CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();