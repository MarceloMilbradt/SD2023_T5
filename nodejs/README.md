# Instalando o Node.js no Linux

Primeiramente instale o curl

```
sudo apt-get install curl
```

Adicione o repositório do Node

```
curl -fsSL https://deb.nodesource.com/setup_19.x | sudo -E bash - &&\
```

Instale o Node

```
sudo apt-get install -y nodejs
```

Para rodar o projeto será nescessário instalar o axios,

Primeiramente instale o npm

```
sudo apt install npm
```

Instale o axios

```
npm install axios
```

# Rodar o projeto

Execute o arquivo script.js com o Node

```
node script.js
```