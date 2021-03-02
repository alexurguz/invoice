FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY Invoice.Api/*.csproj ./Invoice.Api/
COPY Invoice.Core/*.csproj ./Invoice.Core/
COPY Invoice.Infrastructure/*.csproj ./Invoice.Infrastructure/
COPY Invoice.Common/*.csproj ./Invoice.Common/
#
RUN dotnet restore
#
# copy everything else and build app
COPY Invoice.Api/. ./Invoice.Api/
COPY Invoice.Core/. ./Invoice.Core/
COPY Invoice.Infrastructure/. ./Invoice.Infrastructure/
COPY Invoice.Common/. ./Invoice.Common/
#
WORKDIR /app/Invoice.Api
RUN dotnet publish -c Release -o out
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
#
COPY --from=build /app/Invoice.Api/out ./
ENTRYPOINT ["dotnet", "Invoice.Api.dll"]