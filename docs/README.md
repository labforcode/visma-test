## To create a special network in bridge mode
docker network create --gateway 172.18.0.1 --subnet 172.18.0.0/16 dev-local

## To create the volume
docker volume create pg-visma

## To run the Postgres container for the Visma API
docker run -ti --network=dev-local --ip 172.18.0.177 -p 5432:5432 --name pg-visma -e "POSTGRES_PASSWORD=V1sm@07" -v /var/lib/docker/volumes/pg-vismal/_data:/var/lib/postgresql/data -d postgres

## To run the PgAdmin container
docker run -ti --network=dev-local --ip 172.18.0.3 -p 15432:80 --name pgadmin -e "PGADMIN_DEFAULT_EMAIL=test@visma.com" -e "PGADMIN_DEFAULT_PASSWORD=V1sm4@7" -v /var/lib/docker/volumes/pg-admin/_data:/var/lib/pg-admin/data -d dpage/pgadmin4

## To create Migration

1 - Set the Infra.Data project as the main one to be executed

2- Using PowerShell, enter the folder YOUR_PATH\src\Visma.Infra.Data

3 - Run the command below to set the Environment in which you want to perform the Migration
$Env:ASPNETCORE_ENVIRONMENT = "Production"
$Env:ASPNETCORE_ENVIRONMENT = "Development"

4 - Then, execute the command below to generate the Migration, according to the previously set environment
dotnet ef migrations add DatabaseFirstCore --context CoreContext -s YOUR_PATH\src\Visma.Api --verbose
dotnet ef migrations add DatabaseFirstLog --context LogContext -s YOUR_PATH\src\Visma.Api --verbose

5 - After generating the Migration, run the command below to update the DataBase
dotnet ef database update --context CoreContext -s YOUR_PATH\src\Visma.Api --verbose
dotnet ef database update --context LogContext -s YOUR_PATH\src\Visma.Api --verbose


## Run docker in production mode (local only)
1- docker build -t visma/test-prd -f src/Visma.Api/Dockerfile .
2- docker run -ti --network=dev-local --ip 172.18.0.50 --name visma-test-prd -d -e ASPNETCORE_ENVIRONMENT=Production -p 40000:80 --rm visma/test-prd


## Run docker in development mode (local only)
1- docker build -t visma/test-dev -f src/Visma.Api/Dockerfile.Development .
2- docker run -ti --network=dev-local --ip 172.18.0.70 --name visma-test-dev -d -e ASPNETCORE_ENVIRONMENT=Development -p 40001:80 --rm visma/test-dev

