FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS http://+:80
ENV ASPNETCORE_ENVIRONMENT: "Production"

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /
COPY ["src/Visma.Api/Visma.Api.csproj", "src/Visma.Api/"]
COPY ["src/Visma.Core.Infra.CrossCutting.Common/Visma.Core.Infra.CrossCutting.Common.csproj", "src/Visma.Core.Infra.CrossCutting.Common/"]
COPY ["src/Visma.Core.Infra.CrossCutting.IoC/Visma.Core.Infra.CrossCutting.IoC.csproj", "src/Visma.Core.Infra.CrossCutting.IoC/"]
COPY ["src/Visma.Core.Infra.CrossCutting.Logging/Visma.Core.Infra.CrossCutting.Logging.csproj", "src/Visma.Core.Infra.CrossCutting.Logging/"]
COPY ["src/Visma.Core.Infra.CrossCutting.Security/Visma.Core.Infra.CrossCutting.Security.csproj", "src/Visma.Core.Infra.CrossCutting.Security/"]
COPY ["src/Visma.HR.Application/Visma.HR.Application.csproj", "src/Visma.HR.Application/"]
COPY ["src/Visma.HR.Domain/Visma.HR.Domain.csproj", "src/Visma.HR.Domain/"]
COPY ["src/Visma.HR.Domain.Core/Visma.HR.Domain.Core.csproj", "src/Visma.HR.Domain.Core/"]
COPY ["src/Visma.HR.Infra.CrossCutting.Bus/Visma.HR.Infra.CrossCutting.Bus.csproj", "src/Visma.HR.Infra.CrossCutting.Bus/"]
COPY ["src/Visma.HR.Infra.CrossCutting.Common/Visma.HR.Infra.CrossCutting.Common.csproj", "src/Visma.HR.Infra.CrossCutting.Common/"]
COPY ["src/Visma.HR.Infra.CrossCutting.IoC/Visma.HR.Infra.CrossCutting.IoC.csproj", "src/Visma.HR.Infra.CrossCutting.IoC/"]
COPY ["src/Visma.HR.Infra.Data/Visma.HR.Infra.Data.csproj", "src/Visma.HR.Infra.Data/"]

RUN dotnet restore "src/Visma.Api/Visma.Api.csproj"
COPY . .
WORKDIR "/src/Visma.Api"
RUN dotnet build "Visma.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Visma.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Visma.Api.dll"]