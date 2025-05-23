# Экзаменационное задание: REST API для платформы публикации статей

## 🎯 Цель проекта

Разработать REST API для платформы публикации статей, используя Clean Architecture, асинхронное программирование и Dapper для работы с PostgreSQL.

## 📚 Технологический стек

- ASP.NET Core WebAPI (.NET 8+)
- Dapper
- PostgreSQL
- Swagger/OpenAPI
- ApiResponse Pattern

## 📂 Структура базы данных

### 1. Таблица `users` – Пользователи
| Поле               | Тип данных                | Описание                                         |
| ------------------ | ------------------------- | ------------------------------------------------ |
| `id`               | SERIAL PRIMARY KEY        | Уникальный идентификатор пользователя            |
| `username`         | VARCHAR(50) NOT NULL      | Имя пользователя                                 |
| `email`            | VARCHAR(150) NOT NULL     | Электронная почта                                |
| `password_hash`    | VARCHAR(256) NOT NULL     | Хеш пароля                                       |
| `bio`              | TEXT                      | О себе                                           |
| `created_at`       | TIMESTAMP NOT NULL        | Дата регистрации                                 |

### 2. Таблица `articles` – Статьи
| Поле           | Тип данных                | Описание                                         |
| -------------- | ------------------------- | ------------------------------------------------ |
| `id`           | SERIAL PRIMARY KEY        | Уникальный идентификатор статьи                  |
| `user_id`      | INTEGER NOT NULL          | ID автора                                        |
| `title`        | VARCHAR(255) NOT NULL     | Заголовок статьи                                 |
| `content`      | TEXT NOT NULL             | Содержание статьи                                |
| `description`  | VARCHAR(500)              | Краткое описание                                 |
| `created_at`   | TIMESTAMP NOT NULL        | Дата создания                                    |
| `status`       | VARCHAR(20)               | Статус (черновик, опубликована)                  |

### 3. Таблица `comments` – Комментарии
| Поле           | Тип данных                | Описание                                         |
| -------------- | ------------------------- | ------------------------------------------------ |
| `id`           | SERIAL PRIMARY KEY        | Уникальный идентификатор комментария             |
| `article_id`   | INTEGER NOT NULL          | ID статьи                                        |
| `user_id`      | INTEGER NOT NULL          | ID автора комментария                            |
| `content`      | TEXT NOT NULL             | Текст комментария                                |
| `created_at`   | TIMESTAMP NOT NULL        | Дата создания                                    |

### 4. Таблица `claps` – Хлопки
| Поле           | Тип данных                | Описание                                         |
| -------------- | ------------------------- | ------------------------------------------------ |
| `id`           | SERIAL PRIMARY KEY        | Уникальный идентификатор хлопка                  |
| `article_id`   | INTEGER NOT NULL          | ID статьи                                        |
| `user_id`      | INTEGER NOT NULL          | ID пользователя                                  |
| `count`        | INTEGER NOT NULL          | Количество хлопков (от 1 до 50)                  |
| `created_at`   | TIMESTAMP NOT NULL        | Дата создания                                    |

## 📝 API Endpoints

### CRUD операции для Users

1. **Получение всех пользователей**
   * **Endpoint:** GET /api/users
   * **Метод:** Task<ApiResponse<List<User>>> GetAllAsync()

2. **Получение пользователя по ID**
   * **Endpoint:** GET /api/users/{id}
   * **Метод:** Task<ApiResponse<User>> GetByIdAsync(int id)

3. **Создание пользователя**
   * **Endpoint:** POST /api/users
   * **Метод:** Task<ApiResponse<bool>> CreateAsync(User request)

4. **Обновление пользователя**
   * **Endpoint:** PUT /api/users/{id}
   * **Метод:** Task<ApiResponse<bool>> UpdateAsync(int id, User request)

5. **Удаление пользователя**
   * **Endpoint:** DELETE /api/users/{id}
   * **Метод:** Task<ApiResponse<bool>> DeleteAsync(int id)

[Аналогичные CRUD операции должны быть реализованы для Articles, Comments и Claps]

## 📊 SQL запросы (StatisticService)

1. **Поиск статей пользователя**
   * **Задание:** Получить все статьи конкретного пользователя
   * **Метод:** GetUserArticlesAsync

2. **Последние комментарии к статье**
   * **Задание:** Получить 5 последних комментариев к статье
   * **Метод:** GetArticleRecentCommentsAsync

3. **Количество хлопков статьи**
   * **Задание:** Подсчитать общее количество хлопков для статьи
   * **Метод:** GetArticleClapsCountAsync

4. **Последние опубликованные статьи**
   * **Задание:** Получить 10 последних опубликованных статей с именами авторов
   * **Метод:** GetRecentArticlesAsync

5. **Статистика пользователя**
   * **Задание:** Получить количество статей и комментариев пользователя
   * **Метод:** GetUserStatsAsync

## 📊 SQL запросы для заполнения таблиц

### 1. Заполнение таблицы Users

```sql
INSERT INTO users (username, email, password_hash, bio, created_at) VALUES
('john_doe', 'john@example.com', 'hash1', 'Software Developer', '2024-01-01'),
('jane_smith', 'jane@example.com', 'hash2', 'Content Writer', '2024-01-02'),
('bob_wilson', 'bob@example.com', 'hash3', 'Tech Enthusiast', '2024-01-03'),
('alice_brown', 'alice@example.com', 'hash4', 'UI Designer', '2024-01-04'),
('mike_jones', 'mike@example.com', 'hash5', 'Product Manager', '2024-01-05'),
('sarah_davis', 'sarah@example.com', 'hash6', 'Tech Blogger', '2024-01-06'),
('tom_miller', 'tom@example.com', 'hash7', 'Student', '2024-01-07'),
('emma_wilson', 'emma@example.com', 'hash8', 'Software Engineer', '2024-01-08'),
('james_taylor', 'james@example.com', 'hash9', 'Web Developer', '2024-01-09'),
('lisa_anderson', 'lisa@example.com', 'hash10', 'Data Scientist', '2024-01-10');
```


### 2. Заполнение таблицы Articles
```sql
INSERT INTO articles (user_id, title, content, description, created_at, status) VALUES
(1, 'Getting Started with C#', 'Content 1', 'Basic C# tutorial', '2024-01-15', 'published'),
(2, 'Web Development Tips', 'Content 2', 'Essential web dev tips', '2024-01-16', 'published'),
(3, 'SQL Basics', 'Content 3', 'Introduction to SQL', '2024-01-17', 'published'),
(4, 'UI Design Principles', 'Content 4', 'Basic UI concepts', '2024-01-18', 'published'),
(5, 'Product Management 101', 'Content 5', 'PM basics', '2024-01-19', 'published'),
(1, 'Advanced C# Topics', 'Content 6', 'Advanced tutorial', '2024-01-20', 'draft'),
(2, 'Frontend Frameworks', 'Content 7', 'Framework comparison', '2024-01-21', 'published'),
(3, 'Database Design', 'Content 8', 'DB design principles', '2024-01-22', 'published'),
(4, 'UX Best Practices', 'Content 9', 'UX guidelines', '2024-01-23', 'published'),
(5, 'Agile Methodology', 'Content 10', 'Agile basics', '2024-01-24', 'published');
```

### 3. Заполнение таблицы Comments
```sql
INSERT INTO comments (article_id, user_id, content, created_at) VALUES
(1, 2, 'Great article!', '2024-01-25'),
(1, 3, 'Very helpful', '2024-01-25'),
(2, 1, 'Nice tips', '2024-01-26'),
(2, 4, 'Useful info', '2024-01-26'),
(3, 5, 'Well explained', '2024-01-27'),
(3, 1, 'Thanks for sharing', '2024-01-27'),
(4, 2, 'Interesting points', '2024-01-28'),
(4, 3, 'Good examples', '2024-01-28'),
(5, 4, 'Clear explanation', '2024-01-29'),
(5, 5, 'Very informative', '2024-01-29');
```

### 4. Заполнение таблицы Claps
```sql
INSERT INTO claps (article_id, user_id, count, created_at) VALUES
(1, 2, 5, '2024-01-25'),
(1, 3, 3, '2024-01-25'),
(2, 1, 4, '2024-01-26'),
(2, 4, 2, '2024-01-26'),
(3, 5, 5, '2024-01-27'),
(3, 1, 3, '2024-01-27'),
(4, 2, 4, '2024-01-28'),
(4, 3, 2, '2024-01-28'),
(5, 4, 5, '2024-01-29'),
(5, 5, 3, '2024-01-29');
```