# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# копируем csproj и восстанавливаем зависимости
COPY task3api.csproj ./
RUN dotnet restore

# копируем всё и публикуем
COPY . .
RUN dotnet publish -c Release -o /app

# Этап запуска
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

# указываем точку входа
ENTRYPOINT ["dotnet", "task3api.dll"]
