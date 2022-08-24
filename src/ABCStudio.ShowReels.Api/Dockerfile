FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ABCStudio.ShowReels.Api/ABCStudio.ShowReels.Api.csproj", "ABCStudio.ShowReels.Api/"]
COPY ["ABCStudio.ShowReels.Core/ABCStudio.ShowReels.Core.csproj", "ABCStudio.ShowReels.Core/"]
COPY ["ABCStudio.ShowReels.Infrastructure/ABCStudio.ShowReels.Infrastructure.csproj", "ABCStudio.ShowReels.Infrastructure/"]
COPY ["ABCStudio.ShowReels.Application/ABCStudio.ShowReels.Application.csproj", "ABCStudio.ShowReels.Application/"]
RUN dotnet restore "ABCStudio.ShowReels.Api/ABCStudio.ShowReels.Api.csproj"
COPY . .
WORKDIR "/src/ABCStudio.ShowReels.Api"
RUN dotnet build "ABCStudio.ShowReels.Api.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "ABCStudio.ShowReels.Api.csproj" -c Debug -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ABCStudio.ShowReels.Api.dll"]
