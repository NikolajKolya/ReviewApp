Начинаем с миграций: docker build -f dockerfile-migrator -t reviewapp-migrator .
Применяем миграции: docker-compose up


Сборка образа докера: docker build -f dockerfile-reviewapp -t reviewapp .