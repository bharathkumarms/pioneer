#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 50701
EXPOSE 44325

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["js.pioneer.webapi/js.pioneer.webapi.csproj", "js.pioneer.webapi/"]
RUN dotnet restore "js.pioneer.webapi/js.pioneer.webapi.csproj"
COPY . .
WORKDIR "/src/js.pioneer.webapi"
RUN dotnet build "js.pioneer.webapi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "js.pioneer.webapi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "js.pioneer.webapi.dll"]