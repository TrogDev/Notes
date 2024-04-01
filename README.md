# Notes
Cайт для создания заметок (Авторизация, CRUD, экспорт в Excel). Разработана серверная и клиентская часть, проект развёртывается с помощью docker-compose

## Содержание
- [Технологии](#технологии)
- [Использование](#использование)

## Технологии
- .NET 8.0
- ASP.NET webapi
- EPPlus
- EntityFramework
- Identity
- MediatR
- PostgreSQL
- Vue.js
- Nginx

## Использование
- Склонируйте репозиторий
```sh
$ git clone https://github.com/TrogDev/Notes/
```

- Билд контейнеров
```sh
docker-compose build
```

- Запустите сервер, он будет доступен на 80 порту
```sh
docker-compose up -d
```
