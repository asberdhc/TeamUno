FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["CartService.csproj", ""]
RUN dotnet restore "CartService.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "CartService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CartService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CartService.dll"]