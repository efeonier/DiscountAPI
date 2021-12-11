FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DiscountAPI.API/DiscountAPI.API.csproj", "DiscountAPI.API/"]
RUN dotnet restore "DiscountAPI.API/DiscountAPI.API.csproj"
COPY . .
WORKDIR "/src/DiscountAPI.API"
RUN dotnet build "DiscountAPI.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscountAPI.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiscountAPI.API.dll"]
