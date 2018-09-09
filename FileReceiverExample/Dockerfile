FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 51656
EXPOSE 44326

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["FileReceiverExample/FileReceiverExample.csproj", "FileReceiverExample/"]
RUN dotnet restore "FileReceiverExample/FileReceiverExample.csproj"
COPY . .
WORKDIR "/src/FileReceiverExample"
RUN dotnet build "FileReceiverExample.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "FileReceiverExample.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "FileReceiverExample.dll"]