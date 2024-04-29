## Migration

1 - Setar o projeto de Infra.Data como principal a ser executado

2- Pelo PowerShell, entrar na pasta D:\lab4code\estudos\backend\c#\VismaTest\Test\src\Visma.Infra.Data

3 - Executar o comando abaixo para setar o Ambiente em que deseja fazer o Migration
$Env:ASPNETCORE_ENVIRONMENT = "Production"
$Env:ASPNETCORE_ENVIRONMENT = "Development"


4 - Então, executar o comando abaixo para gerar o Migration, de acordo com o ambiente setado anteriormente
dotnet ef migrations add development --context CoreContext -s D:\lab4code\estudos\backend\c#\VismaTest\Test\src\Visma.Api --verbose
dotnet ef migrations add development --context LogContext -s D:\lab4code\estudos\backend\c#\VismaTest\Test\src\Visma.Api --verbose

5 - Após a geração do Migration, executar o comando abaixo para atualizar a DataBase
dotnet ef database update --context CoreContext -s D:\lab4code\estudos\backend\c#\VismaTest\Test\src\Visma.Api --verbose
dotnet ef database update --context LogContext -s D:\lab4code\estudos\backend\c#\VismaTest\Test\src\Visma.Api --verbose


## Criar uma rede especial em modo bridge
docker network create --gateway 172.18.0.1 --subnet 172.18.0.0/16 dev-local

## Criar o volume
docker volume create pg-visma


## Executar o container do Postgres para a API Tecnomyl
docker run -ti --network=dev-local --ip 172.18.0.177 -p 5432:5432 --name pg-visma -e "POSTGRES_PASSWORD=V1sm@07" -v /var/lib/docker/volumes/pg-vismal/_data:/var/lib/postgresql/data -d postgres

TO DO - passar esse texto para inglês
