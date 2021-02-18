![.NET 5](https://github.com/aimenux/WorkerServiceDemo/workflows/.NET%205/badge.svg)

# WorkerServiceDemo
```
Using worker service template in order to create long-running cross-platform services
```

> In this repo, i m building a long running background service based on [worker service template](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-5.0&tabs=visual-studio#worker-service-template).
>
> Worker services are a great way to create cross-plateform services that can be deployed on :
>
> :pushpin: windows
>
> :pushpin: linux
>
> :pushpin: docker
>
> :pushpin: [azure container instance](https://devblogs.microsoft.com/aspnet/dotnet-core-workers-in-azure-container-instances/)
>
> In this repo, the worker display features from configuration file based on 3 strategies :
>
> :one: `ConfigurationOptionsService` : static reading of configuration features
>
> :two: `ConfigurationOptionsSnapshotService` : dynamic reading of configuration features
>
> :three: `ConfigurationOptionsMonitorService` : dynamic reading of configuration features
>
> In order to deploy the worker as a windows service, type the following commands in your terminal :
>
> :white_check_mark: Build in release mode : `dotnet build -c release`
>
> :white_check_mark: Publish to some folder : `dotnet publish -o [PATH-TO-FOLDER]`
>
> :white_check_mark: Create windows service : `sc create [SERVICE-NAME] binPath=[PATH-TO-FOLDER]\App.exe`
>
> :white_check_mark: Delete windows service : `sc delete [SERVICE-NAME]`
>

**`Tools`** : vs19, net 5.0
