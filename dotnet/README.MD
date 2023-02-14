# Instalando o .NET 6 runtime no Linux

instalação para ubuntu

Para outras distribuiçoes ou quaisquer duvidas pode ser acessado a [Documentação oficial](https://learn.microsoft.com/pt-br/dotnet/core/install/linux)



```
wget https://packages.microsoft.com/config/ubuntu/22.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

Atualize o gerenciador de pacotes do seu sistema:


```
sudo apt-get update
```

Instale o .NET runtime:

```
sudo apt-get install -y dotnet-runtime-6.0
```

# Rodar o projeto

Disponibilizei o projeto compilado em um executavel ``Interop.Core`` para uma build linux-x64 na pasta ``build``

Basta navegar para a pasta ``build`` e definir as permissões para o arquivo usando 
```
chmod 777 ./Interop.Core
```

E agora pode-se executar o arquivo
```
./Interop.Core "Alguma mensagem para enviar para o firebase"
```

## Recompilar o projeto (Não recomendado)
*não consegui instalar o sdk no lab, então não sei se funciona, mas era pra ser algo assim*

Para isso será necessario instalar o sdk do dotnet 6

```
dotnet restore "Interop.Core/Interop.Core.csproj"
```
```
dotnet build "Interop.Core.csproj" -c Release -o /build
```
```
dotnet publish "Interop.Core.csproj" -c Release -o /publish
```
```
dotnet Interop.Core.dll
```