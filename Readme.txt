Начинаем с миграций: docker build -f dockerfile-migrator -t reviewapp-migrator .
Применяем миграции: docker-compose -f docker-compose-migrator.yml


Сборка образа докера: docker build -f dockerfile -t reviewapp .