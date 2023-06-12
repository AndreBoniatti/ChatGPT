using System.Net.Http.Headers;
using PPI.Clients;
using PPI.Clients.Contracts;
using PPI.Data.Context.Extensions;
using PPI.Data.Repositories;
using PPI.Data.Repositories.Contracts;

var MyAllowSpecificOrigins = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins(
                "http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
        });
});

builder.Services.AddDataContext(builder.Configuration.GetConnectionString("Database") ?? "");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IQuestionRepository, QuestionRepository>();
builder.Services.AddTransient<IAnswerRepository, AnswerRepository>();

builder.Services.AddHttpClient<IOpenAIClient, OpenAIClient>(opt =>
{
    opt.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", builder.Configuration["OpenAIApi:Token"]);
    opt.BaseAddress = new Uri(builder.Configuration["OpenAIApi:Uri"]);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
