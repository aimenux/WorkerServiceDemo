# WorkerServiceDemo
```
Using worker service template in order to create long-running cross-platform services
```

> In this repo, i m building a long running background service based on [worker service template](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-5.0&tabs=visual-studio#worker-service-template).
>
> The worker display configuration features based on 3 strategies :
>
> :one: `ConfigurationOptionsService` : static reading of configuration features
> :two: `ConfigurationOptionsSnapshotService` : dynamic reading of configuration features
> :three: `ConfigurationOptionsMonitorService` : dynamic reading of configuration features
>
> The worker could be published and deployed either on windows or linux. 
>
> In order to deploy the worker as a windows service, type the following commands :
>
> :white_check_mark: Build in release mode : `dotnet build -c release`
>
> :white_check_mark: Publish to some folder : `dotnet publish -o [PATH-TO-PUBLISHED-FILES]`
>
> :white_check_mark: Create windows service : `C:\Windows\System32\sc create [SERVICE-NAME] binPath=[PATH-TO-PUBLISHED-FILES]\App.exe`
>
> :white_check_mark: Delete windows service : `C:\Windows\System32\sc delete [SERVICE-NAME]`
>

**`Tools`** : vs19, net 5.0
