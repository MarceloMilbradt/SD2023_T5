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

Disponibilizei o projeto compilado em um executavel ``T5.Interop.Client`` e ``T5.Interop.Listener``  para uma build linux-x64, linux-arm e uma build multiplataforma em .exe na pasta ``build``

usando o screen ou outra maquina, será necessario rodar ambos, client e listener (a ordem não interfere)

Basta navegar para a pasta ``build`` e definir as permissões para o arquivo usando 

O Client pode enviar mensagens para o MQTT, digite uma mensagem que ela irá ser enviada para o MQTT e aparecerá no Listener

```
chmod 777 ./T5.Interop.Client
```
```
chmod 777 ./T5.Interop.Listener
```

E agora pode-se executar o arquivo
```
./T5.Interop.Client
```
```
./T5.Interop.Listener
```
