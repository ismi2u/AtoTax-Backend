#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AtoTax.API/AtoTax.API.csproj", "AtoTax.API/"]
COPY ["AtoTax.Domain/AtoTax.Domain.csproj", "AtoTax.Domain/"]
COPY ["AtoTax.EmailService/AtoTax.EmailService.csproj", "AtoTax.EmailService/"]
RUN dotnet restore "AtoTax.API/AtoTax.API.csproj"
COPY . .
WORKDIR "/src/AtoTax.API"
RUN dotnet build "AtoTax.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AtoTax.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AtoTax.API.dll"]