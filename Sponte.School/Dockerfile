#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Sponte.School/Sponte.School.csproj", "Sponte.School/"]
RUN dotnet restore "Sponte.School/Sponte.School.csproj"
COPY . .
WORKDIR "/src/Sponte.School"
RUN dotnet build "Sponte.School.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sponte.School.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sponte.School.dll"]