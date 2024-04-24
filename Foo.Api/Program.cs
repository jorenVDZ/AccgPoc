using Foo.Api.Mutations;
using Foo.Api.Queries;
using Foo.Infrastructure.Repositories;
using Foo.Infrastructure.Repositories.Interfaces;
using MassTransit;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddGraphQLServer()
  .AddMutationType<Mutation>()
  .AddQueryType<Query>()
  .AddSorting();

builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();

    x.SetInMemorySagaRepositoryProvider();

    var entryAssembly = Assembly.GetEntryAssembly();
    x.AddConsumers(entryAssembly);
    x.AddSagaStateMachines(entryAssembly);
    x.AddSagas(entryAssembly);  
    x.AddActivities(entryAssembly);

    x.UsingAzureServiceBus((context, cfg) =>
    {
        cfg.Host("Endpoint=sb://accgpoc.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=NGUhTC9gVOnjxahTyWRb+0GCMOlWxDmf++ASbAPp/b8=");
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddScoped<IFooRepository, MockFooRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGraphQL();

app.Run();
